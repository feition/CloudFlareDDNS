using CloudFlare.DDNS.UpdateService.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudFlare.DDNS.UpdateService.ConfigTool
{
    public partial class FrmDNSRecordInfo : Form
    {
        RecordConfig instance;

        public RecordConfig Instance
        {
            get
            {
                return instance;
            }
        }

        public FrmDNSRecordInfo()
        {
            InitializeComponent();

            instance = new RecordConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string recordName = txtRecordName.Text.Trim();//regex validate?
            if (string.IsNullOrEmpty(recordName))
            {
                FrmConfig.ShowWarning("Please input record name!");
                return;
            }

            string zoneName = txtZoneName.Text.Trim();
            if (string.IsNullOrEmpty(zoneName))
            {
                FrmConfig.ShowWarning("Please input zone name!");
                return;
            }

            instance.RecordName = recordName;
            instance.ZoneName = zoneName;

            this.DialogResult = DialogResult.OK;

        }
    }
}
