using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFlareDDNSLib
{
    public class ZoneListResponseWrapper
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("result")] 
        public IList<ZoneRecord> DNSResultList { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("result_info")]
        public PagedWrapper RspResultInfo { get; set; }

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
    }
}