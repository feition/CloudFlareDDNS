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
    public partial class FrmAccountConfigInfo : Form
    {
        AccountConfig instance;

        public AccountConfig Instance
        {
            get
            {
                return instance;
            }
        }

        public FrmAccountConfigInfo()
        {
            InitializeComponent();

            instance = new AccountConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();//regex validate?
            if (string.IsNullOrEmpty(email))
            {
                FrmConfig.ShowWarning("Please input email address!");
                return;
            }

            string apiKey = txtAPIKey.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                FrmConfig.ShowWarning("Please input API key!");
                return;
            }

            instance.EMailAddr = email;
            instance.APIKey = apiKey;

            this.DialogResult = DialogResult.OK;

        }
    }
}
