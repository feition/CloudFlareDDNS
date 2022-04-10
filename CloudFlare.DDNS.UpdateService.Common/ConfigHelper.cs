using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CloudFlare.DDNS.UpdateService.Common
{
    public class ConfigHelper
    {
        public static CloudFlareDDNSUpdateTaskConfig GetSettings(string settingsFile, out bool isDefaultConfig)
        {
            bool fileExists = File.Exists(settingsFile);
            if (!fileExists)
            {
                using (var stream = File.Open(settingsFile, FileMode.OpenOrCreate))
                {
                    var defaultConfig = new CloudFlareDDNSUpdateTaskConfig();
                    //defaultConfig.CheckInterval =1D;
                    //defaultConfig.IPV4AddrSvcUrl = ;
                    defaultConfig.AccountConfigList = new List<AccountConfig>();
                    var demoAccCfg = new AccountConfig();
                    demoAccCfg.APIKey = "ABCDEFGHIJKL";
                    demoAccCfg.EMailAddr = "demo@outlook.com";
                    demoAccCfg.RecordConfigList = new List<RecordConfig>();
                    demoAccCfg.RecordConfigList.Add(new RecordConfig
                    {
                        RecordName = "ipv4",
                        ZoneName = "test1.cc"
                    });

                    demoAccCfg.RecordConfigList.Add(new RecordConfig
                    {
                        RecordName = "news",
                        ZoneName = "test1.cc"
                    });

                    demoAccCfg.RecordConfigList.Add(new RecordConfig
                    {
                        RecordName = "ipv6",
                        ZoneName = "test2.cc"
                    });

                    defaultConfig.AccountConfigList.Add(demoAccCfg);


                    string configStrNew = JsonConvert.SerializeObject(defaultConfig);
                    var strArr = System.Text.Encoding.UTF8.GetBytes(configStrNew);
                    stream.Write(strArr, 0, strArr.Length);
                    isDefaultConfig = true;
                    return defaultConfig;
                }
            }
            else
            {
                string configStr = File.ReadAllText(settingsFile, System.Text.Encoding.UTF8);
                CloudFlareDDNSUpdateTaskConfig config = null;
                try
                {
                    config = JsonConvert.DeserializeObject<CloudFlareDDNSUpdateTaskConfig>(configStr);
                    isDefaultConfig = false;
                    return config;
                }
                catch
                {
                    File.Delete(settingsFile);
                    return GetSettings(settingsFile, out isDefaultConfig);
                }
            }

        }


        public static void SaveConfig(string settingsFile, CloudFlareDDNSUpdateTaskConfig cfg)
        {
            using (var stream = File.Open(settingsFile, FileMode.Create))
            {
                string configStrNew = JsonConvert.SerializeObject(cfg);
                var strArr = System.Text.Encoding.UTF8.GetBytes(configStrNew);
                stream.Write(strArr, 0, strArr.Length);
            }
        }
    }
}
