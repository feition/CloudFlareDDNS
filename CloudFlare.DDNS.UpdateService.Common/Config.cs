using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFlare.DDNS.UpdateService.Common
{
    public class RecordConfig
    {
        /// <summary>
        /// eg:www/news
        /// </summary>
        public string RecordName { get; set; }

        /// <summary>
        /// eg:google.com
        /// </summary>
        public string ZoneName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0}.{1}", RecordName, ZoneName);
            }
        }

    }

    public class AccountConfig
    {
        public string EMailAddr { get; set; }

        public string APIKey { get; set; }

        public IList<RecordConfig> RecordConfigList { get; set; }

    }

    public class CloudFlareDDNSUpdateTaskConfig
    {
        public string IPV4AddrSourceUrl { get; set; } = "https://ip4.seeip.org";

        public string IPV6AddrSourceUrl { get; set; } = "https://ip6.seeip.org";

        public IList<AccountConfig> AccountConfigList { get; set; }

        /// <summary>
        /// Min
        /// </summary>
        public double CheckInterval { get; set; } = 1D;
    }

}
