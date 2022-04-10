using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareDDNSLib
{
    public class DNSRecord
    {
        /// <summary>
        /// dnsrecord id
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("zone_id")]
        public string ZoneID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }

        /// <summary>
        /// Domain name (example.com)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Current IP
        /// </summary>
        [JsonProperty("content")]
        public string IPAddr { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("proxiable")]
        public bool Proxiable { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("proxied")]
        public bool Proxied { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("ttl")]
        public int TTL { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("created_on")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("meta")]
        public DnsRecordMeta MetaInfo { get; set; }

    }



    public class DnsRecordMeta
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("auto_added")]
        public bool AutoAdded { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("managed_by_apps")]
        public bool ManagedByApps { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("managed_by_argo_tunnel")]
        public bool ManagedByArgoTunnel { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

    }
}
