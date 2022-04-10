using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CloudFlareDDNSLib
{
    /// <summary>
    /// Paged Info class wrapper
    /// </summary>
    public class PagedWrapper
    {
        /// <summary>
        /// Current Page Index
        /// </summary>
        [JsonProperty("page")] 
        public int PageIndex { get; set; }

        /// <summary>
        /// Record count per page
        /// </summary>
        [JsonProperty("per_page")]
        public int PageSize { get; set; }

        /// <summary>
        /// Total pages matched filters
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Record count of this page(actural)
        /// </summary>
        [JsonProperty("count")] 
        public int RecordCount { get; set; }

        /// <summary>
        /// Record count matched filters
        /// </summary>
        [JsonProperty("total_count")] 
        public int TotalRecordCount { get; set; }
    }

}