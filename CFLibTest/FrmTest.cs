using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CloudFlareDDNSLib;

namespace CFLibTest
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var api = new CloudFlareAPI("feition@hotmail.com",
                "63371b389bc159fa78f85a6978a3d11b8f6a8");

            var zones = api.GetCloudFlareZones();
            MessageBox.Show(zones.ToString());

            string id = zones.DNSResultList[1].ID;
            var dnsRecList = api.GetCloudFlareRecords(id);
            MessageBox.Show(dnsRecList.ToString());

            var result = dnsRecList.DnsRecordList[0];

            var rt = api.updateCloudflareRecords(result, "1.1.1.1");
            MessageBox.Show(rt.ToString());
        }
    }
}
