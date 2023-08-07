using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Device.Location;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Timers;
using CloudFlare.DDNS.UpdateService.Common;
using CloudFlareDDNSLib;

namespace CloudFlare.DDNS.UpdateService
{
    public partial class CloudFlareDDNSSvc : ServiceBase
    {
        const string log_source = "CloudFlare DDNS Update Service Log";

        CloudFlareDDNSUpdateTaskConfig cfg;

        Timer tmr;

        public CloudFlareDDNSSvc()
        {
            InitializeComponent();

            if (!EventLog.SourceExists(log_source))
                EventLog.CreateEventSource(log_source, log_source);
        }

        protected override void OnStart(string[] args)
        {
            string appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string configFile = string.Format(@"{0}\Config.json", appPath);
            EventLog.WriteEntry(log_source, "Config File: " + configFile, 
                EventLogEntryType.Information);

            bool isDefault;
            cfg = ConfigHelper.GetSettings(configFile, out isDefault);

            //string info = string.Format("服务将每隔{0}分钟执行一次拉取！", execInterval);
            //EventLog.WriteEntry(log_source, info, EventLogEntryType.Information);

            tmr = new Timer();
            tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);
            tmr.Interval = cfg.CheckInterval * 60 * 1000;

            tmr.Start();

            System.Threading.ThreadPool.QueueUserWorkItem((inObj) => Sync(), null);
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
#if DEBUG
            //EventLog.WriteEntry(log_source, "开始执行同步！", EventLogEntryType.Information);
#endif
            Sync();
        }

        public void Sync()
        {
            string ipv4 = string.Empty, ipv6 = string.Empty;
            bool ipv4Ready = false, ipv6Ready = false;
            try
            {
                ipv4 = HttpRequestHelper.Get(cfg.IPV4AddrSourceUrl, null, null, null, true, null);
                ipv4Ready = true;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(log_source, "Get IPv4 Address Error!" + Environment.NewLine + ex.Message, EventLogEntryType.Error);
                //return;
            }

            try
            {
                ipv6 = HttpRequestHelper.Get(cfg.IPV6AddrSourceUrl, null, null, null, true, null);
                ipv6Ready = true;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(log_source, "Get IPv6 Address Error!" + Environment.NewLine + ex.Message, EventLogEntryType.Error);
                //return;
            }

            //loop all accout
            foreach (var account in cfg.AccountConfigList)
            {
                var api = new CloudFlareAPI(account.EMailAddr, account.APIKey);
                ZoneListResponseWrapper zoneRspWrapper = null;
                try
                {
                    zoneRspWrapper = api.GetCloudFlareZones();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(log_source, "api.GetCloudFlareZones() Error!" + Environment.NewLine + ex.Message, EventLogEntryType.Error);
                    return;
                }

                var zoneNameList = account.RecordConfigList.GroupBy(p => p.ZoneName).Select(p => p.Key).ToList();
                var matchedZoneNameList = zoneNameList.Join(zoneRspWrapper.DNSResultList,
                    i => i, j => j.Name, (i, j) => i).ToList();

                //unexpected zone in config
                var exceptZoneNameList = zoneNameList.Except(matchedZoneNameList).ToList();
                if (exceptZoneNameList.Count > 0)
                {
                    string zoneNames = string.Empty;
                    foreach (var i in exceptZoneNameList)
                    {
                        zoneNames += i;
                        zoneNames += ";";
                    }

                    EventLog.WriteEntry(log_source, "unexcepted zone in config: " + zoneNames, EventLogEntryType.Error);
                }

                var matchedZoneList = zoneNameList.Join(zoneRspWrapper.DNSResultList,
                    i => i, j => j.Name, (i, j) => j).ToList();
                List<DNSRecord> dnsRspWrapperList = new List<DNSRecord>();
                foreach (var i in matchedZoneList)
                {
                    DnsRecordListResponseWrapper dnsRecordRspWrapper = null;
                    try
                    {
                        dnsRecordRspWrapper = api.GetCloudFlareRecords(i.ID);
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(log_source, "api.GetCloudFlareRecords() Error!" + Environment.NewLine + ex.Message, EventLogEntryType.Error);
                        return;//continue?
                    }

                    dnsRspWrapperList.AddRange(dnsRecordRspWrapper.DnsRecordList);
                }

                foreach (var i in account.RecordConfigList)
                {
                    var matchedRecordList = dnsRspWrapperList.Where(p => p.Name == i.FullName && p.ZoneName == i.ZoneName).ToList();
                    if (matchedRecordList.Count == 0)
                    {
                        var errMsg = string.Format("{0}.{1} is not found in CloudFlare dns record list", i.RecordName, i.ZoneName);
                        EventLog.WriteEntry(log_source, errMsg, EventLogEntryType.Error);
                        continue;
                    }

                    //A/AAAA Check
                    var recordInfo = matchedRecordList.First();
                    if (recordInfo.RecordType != "A" && recordInfo.RecordType != "AAAA")
                    {
                        var errMsg = string.Format("{0}.{1} is not A/AAAA dns record", i.RecordName, i.ZoneName);
                        EventLog.WriteEntry(log_source, errMsg, EventLogEntryType.Error);
                        continue;
                    }

                    //IP Check
                    string updateIP = string.Empty;
                    if (recordInfo.RecordType == "A")
                    {
                        if (!ipv4Ready) continue;

                        if (recordInfo.IPAddr == ipv4)
                        {
                            var infoMsg = string.Format("{0}.{1} ip not changed, skip update", i.RecordName, i.ZoneName);
                            EventLog.WriteEntry(log_source, infoMsg, EventLogEntryType.Warning);
                            continue;//ip not changed
                        }
                        updateIP = ipv4;
                    }
                    else if (recordInfo.RecordType == "AAAA")
                    {
                        if (!ipv6Ready) continue;

                        if (recordInfo.IPAddr == ipv6)
                        {
                            var infoMsg = string.Format("{0}.{1} ip not changed, skip update", i.RecordName, i.ZoneName);
                            EventLog.WriteEntry(log_source, infoMsg, EventLogEntryType.Warning);
                            continue;//ip not changed
                        }
                        updateIP = ipv6;
                    }

                    DnsRecordUpdateResponseWrapper updateRspWrapper = null;
                    try
                    {
                        updateRspWrapper = api.updateCloudflareRecords(recordInfo, updateIP);
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(log_source, "api.updateCloudflareRecords() Error!" + Environment.NewLine + ex.Message, EventLogEntryType.Error);
                        continue;//continue?
                    }

                    string updateResultMsg = string.Format("{0}.{1} ip update {2}", i.RecordName, i.ZoneName, (updateRspWrapper.Success ? "OK" : "fail"));
                    EventLog.WriteEntry(log_source, updateResultMsg, (updateRspWrapper.Success ? EventLogEntryType.Information : EventLogEntryType.Error));
                }

            }

            
        }

        protected override void OnStop()
        {
            tmr.Dispose();
            EventLog.WriteEntry(log_source, "Service was Stoped!", EventLogEntryType.Warning);
        }

    }
}
