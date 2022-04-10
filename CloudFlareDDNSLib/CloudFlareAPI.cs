using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CloudFlareDDNSLib
{
    public class CloudFlareAPI
    {
        string _EmailAddr;
        string _APIKey;
        string _APIUrl = "https://api.cloudflare.com/client/v4";
        public CloudFlareAPI(string emailAddr, string apiKey)
        {
            _EmailAddr = emailAddr;
            _APIKey = apiKey;


            //解决“未能创建 SSL/TLS 安全通道”异常
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                                       | SecurityProtocolType.Tls
                                       | SecurityProtocolType.Tls11
                                       | SecurityProtocolType.Tls12;

        }

        /// <summary>
        /// Get the listed records from Cloudflare using their API
        /// </summary>
        /// <returns>JSON stream of records, null on error</returns>
        public DnsRecordListResponseWrapper GetCloudFlareRecords(string zoneID)
        {
            if (string.IsNullOrEmpty(zoneID)) throw new Exception("参数zoneID无效！");

            var url = _APIUrl + "/zones/" + zoneID + "/dns_records?page=1&per_page=50&order=type&direction=asc";
            var headerData = new WebHeaderCollection();
            //headerData.Add("Authorization", "Bearer " + Program.settingsManager.getSetting("APIKey").ToString().Trim());
            headerData.Add("X-Auth-Key", _APIKey);
            headerData.Add("X-Auth-Email", _EmailAddr);

            //Check if request still get value.
            string records = HttpRequestHelper.Get(url, null, headerData);

            var rt = JsonConvert.DeserializeObject<DnsRecordListResponseWrapper>(records);

            return rt;
        }

        public ZoneListResponseWrapper GetCloudFlareZones()
        {
            var headerData = new WebHeaderCollection();

            var url = _APIUrl + "/zones?status=active&page=1&per_page=50&order=status&direction=desc&match=all";
            //headerData.Add("Authorization", "Bearer " + Program.settingsManager.getSetting("APIKey").ToString().Trim());
            headerData.Add("X-Auth-Key", _APIKey);
            headerData.Add("X-Auth-Email", _EmailAddr);

            //Check if request still get value.
            string records = HttpRequestHelper.Get(url, null, headerData);
            var rt = JsonConvert.DeserializeObject<ZoneListResponseWrapper>(records);
            return rt;
        }

        /// <summary>
        /// Run an update on the given record
        /// </summary>
        /// <param name="FetchedRecord"></param>
        /// <returns></returns>
        public DnsRecordUpdateResponseWrapper updateCloudflareRecords(DNSRecord FetchedRecord, string ipAddr)
        {
            if (string.IsNullOrEmpty(FetchedRecord.ZoneID) || string.IsNullOrEmpty(FetchedRecord.ID))
            {
                throw new Exception("参数zone_id和参数id无效！");
            }
            var url = _APIUrl + "/zones/" + FetchedRecord.ZoneID + "/dns_records/" + FetchedRecord.ID;

            var headerData = new WebHeaderCollection();
            //headerData.Add("Authorization", "Bearer " + Program.settingsManager.getSetting("APIKey").ToString().Trim());
            headerData.Add("X-Auth-Key", _APIKey);
            headerData.Add("X-Auth-Email", _EmailAddr);

            var obj = new
            {
                type = FetchedRecord.RecordType,
                name = FetchedRecord.Name,
                content = ipAddr,
                proxied = FetchedRecord.Proxied
            };
            string data = JsonConvert.SerializeObject(obj);

            string rspStr = HttpRequestHelper.Put(url, null, data, headerData);
            var rt = JsonConvert.DeserializeObject<DnsRecordUpdateResponseWrapper>(rspStr);
            return rt;
        }



    }
}
