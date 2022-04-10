using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CloudFlare.DDNS.UpdateService
{
    static class Program
    {
        public static CloudFlareDDNSSvc svcInstance = null; 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{
                svcInstance = new CloudFlareDDNSSvc() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
