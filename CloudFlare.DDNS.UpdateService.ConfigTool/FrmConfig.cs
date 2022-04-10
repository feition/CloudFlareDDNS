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
    public partial class FrmConfig : Form
    {
        CloudFlareDDNSUpdateTaskConfig taskCfg;

        string configFilePath = null;

        public FrmConfig()
        {
            InitializeComponent();
        }

        void BuildCols()
        {
            BuildCol<DataGridViewTextBoxColumn>(dgvAcc, "EMailAddr", "EMail Addr");
            BuildCol<DataGridViewTextBoxColumn>(dgvAcc, "APIKey", "API Key");

            BuildCol<DataGridViewTextBoxColumn>(dgvDns, "RecordName", "Record Name");
            BuildCol<DataGridViewTextBoxColumn>(dgvDns, "ZoneName", "Zone Name");
        }

        T BuildCol<T>(DataGridView target, string fieldName, string headerText, bool isReadOnly = false, bool isVisible = true) where T : DataGridViewColumn, new()
        {
            T column = new T();
            column.DataPropertyName = fieldName;
            column.HeaderText = headerText;
            column.Name = target.Name + "_col_" + fieldName;
            column.ReadOnly = isReadOnly;
            column.Visible = isVisible;
            target.Columns.Add(column);
            return column;
        }

        void FrmConfig_Load(object sender, EventArgs e)
        {
            var fontForGridCell = new Font(this.Font.Name, 12F);
            var fontForGridHeader = new Font(this.Font.Name, 12F, FontStyle.Bold);
            dgvAcc.DefaultCellStyle.Font = fontForGridCell;
            dgvAcc.ColumnHeadersDefaultCellStyle.Font = fontForGridHeader;

            dgvDns.DefaultCellStyle.Font = fontForGridCell;
            dgvDns.ColumnHeadersDefaultCellStyle.Font = fontForGridHeader;

            dgvAcc.AutoGenerateColumns = false;
            dgvDns.AutoGenerateColumns = false;
            dgvAcc.DataSource = bsAcc;
            dgvDns.DataSource = bsDns;
            BuildCols();

            configFilePath = string.Format(@"{0}\Config.json", Application.StartupPath);
            //load config
            bool isDefault;
            taskCfg = ConfigHelper.GetSettings(configFilePath, out isDefault);
            if (isDefault)
            {
                ShowWarning("You are using the default config!");
            }

            txtCheckInterval.Text = taskCfg.CheckInterval.ToString();
            txtIPv4Source.Text = taskCfg.IPV4AddrSourceUrl;
            txtIPv6Source.Text = taskCfg.IPV6AddrSourceUrl;

            bsAcc.DataSource = taskCfg.AccountConfigList;
            dgvAcc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            bsAcc.CurrentChanged += bsAcc_CurrentChanged;
            bsAcc_CurrentChanged(bsAcc, null);
        }

        private void bsAcc_CurrentChanged(object sender, EventArgs e)
        {
            var obj = bsAcc.Current as AccountConfig;
            if (obj == null) return;

            if (obj.RecordConfigList == null)
            {
                obj.RecordConfigList = new List<RecordConfig>();
            }

            bsDns.DataSource = obj.RecordConfigList;
            dgvDns.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        public static DialogResult ShowWarning(string content)
        {
            return MessageBox.Show(content, "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowQuestion(string content)
        {
            return MessageBox.Show(content, "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            AccountConfig accCfg = null;
            using (var frm = new FrmAccountConfigInfo())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
                accCfg = frm.Instance;
            }

            bsAcc.Add(accCfg);
        }

        private void btnDelAcc_Click(object sender, EventArgs e)
        {
            var obj = bsAcc.Current as AccountConfig;
            if (obj == null) return;

            if (obj.RecordConfigList != null)
            {
                if (obj.RecordConfigList.Count > 0)
                {
                    ShowWarning("There are some DNS records in this account config!");
                    return;
                }
            }

            var rt = ShowQuestion("Sure to remove this account config?");
            if (rt != DialogResult.Yes) return;

            bsAcc.RemoveCurrent();
        }

        private void btnAddDns_Click(object sender, EventArgs e)
        {
            RecordConfig recordCfg = null;
            using (var frm = new FrmDNSRecordInfo())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
                recordCfg = frm.Instance;
            }

            bsDns.Add(recordCfg);
        }

        private void btnDelDns_Click(object sender, EventArgs e)
        {
            var obj = bsDns.Current as RecordConfig;
            if (obj == null) return;


            var rt = ShowQuestion("Sure to remove this DNS record config?");
            if (rt != DialogResult.Yes) return;

            bsDns.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            taskCfg.IPV4AddrSourceUrl = txtIPv4Source.Text.Trim();
            if (string.IsNullOrEmpty(taskCfg.IPV4AddrSourceUrl))
            {
                ShowWarning("Please input IPv4 Address Source!");
                return;
            }

            taskCfg.IPV6AddrSourceUrl = txtIPv6Source.Text.Trim();
            if (string.IsNullOrEmpty(taskCfg.IPV6AddrSourceUrl))
            {
                ShowWarning("Please input IPv6 Address Source!");
                return;
            }

            var intervalStr = txtCheckInterval.Text.Trim();
            double interval;
            bool convertOK = double.TryParse(intervalStr, out interval);
            if (!convertOK)
            {
                ShowWarning("Please input valid check interval value!");
                return;
            }

            taskCfg.CheckInterval = interval;
            if (configFilePath == null) return;
            ConfigHelper.SaveConfig(configFilePath, taskCfg);
            ShowWarning("Save OK!");

        }
    }
}
