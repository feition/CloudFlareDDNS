using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFlareDDNSLib
{
    public class DnsRecordListResponseWrapper
    {
        /// <summary>
        /// Get all DNS Records
        /// </summary>
        [JsonProperty("result")]
        public IList<DNSRecord> DnsRecordList { get; set; }

        /// <summary>
        /// success msg
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// error msg's
        /// </summary>
        [JsonProperty("errors")] 
        public IList<string> ErrorList { get; set; }

        /// <summary>
        /// other msg's
        /// </summary>
        [JsonProperty("messages")] 
        public IList<string> MessageList { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("result_info")] 
        public PagedWrapper ResultInfo { get; set; }
    }
}