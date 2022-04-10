using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlareDDNSLib
{
    public class ZoneHost
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string HostName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class ZoneRecord
    {
        /// <summary>
        /// dnsrecord id
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Domain name (example.com)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("paused")]
        public bool Paused { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("type")]
        public string ZoneType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("development_mode")]
        public int DevelopmentMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verification_key")]
        public string VerificationKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cname_suffix")]
        public string CNameSuffix { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("name_servers")]
        public IList<string> NameServerList { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("original_name_servers")]
        public IList<string> OriginalNameServerList { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("original_registrar")]
        public string OriginalRegistrar { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("original_dnshost")]
        public string OriginalDnshost { get; set; }

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
        [JsonProperty("activated_on")]
        public DateTime ActivatedTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("meta")]
        public ZoneMeta MetaInfo { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("owner")]
        public ZoneOwner OwnerInfo { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("account")]
        public ZoneAccount AccountInfo { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("permissions")]
        public string[] PermissionList { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("plan")]
        public ZonePlan PlanInfo { get; set; }

        [JsonProperty("host")]
        public ZoneHost HostInfo { get; set; }
    }

    public class ZoneMeta
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("step")]
        public int Step { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("wildcard_proxiable")]
        public bool WildcardProxiable { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("custom_certificate_quota")]
        public int CustomCertificateQuota { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("page_rule_quota")]
        public int PageRuleQuota { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("phishing_detected")]
        public bool PhishingDetected { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("multiple_railguns_allowed")]
        public bool MultipleRailgunsAllowed { get; set; }
    }

    public class ZoneOwner
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("type")]
        public string OwnerType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }


    public class ZoneAccount
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("name")]
        public string AccountName { get; set; }
    }


    public class ZonePlan
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("name")]
        public string PlanName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("price")]
        public decimal price { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("is_subscribed")]
        public bool IsSubscribed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("can_subscribe")]
        public bool CanSubscribe { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("legacy_id")]
        public string LegacyID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("legacy_discount")]
        public bool LegacyDiscount { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("externally_managed")]
        public bool ExternallyManaged { get; set; }
    }
}
