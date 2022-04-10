
namespace CloudFlare.DDNS.UpdateService.ConfigTool
{
    partial class FrmConfig
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPv6Source = new System.Windows.Forms.TextBox();
            this.txtIPv4Source = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheckInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAcc = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelAcc = new System.Windows.Forms.Button();
            this.btnAddAcc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDns = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelDns = new System.Windows.Forms.Button();
            this.btnAddDns = new System.Windows.Forms.Button();
            this.bsAcc = new System.Windows.Forms.BindingSource(this.components);
            this.bsDns = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDns)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPv6 Address Source";
            // 
            // txtIPv6Source
            // 
            this.txtIPv6Source.Location = new System.Drawing.Point(164, 20);
            this.txtIPv6Source.Name = "txtIPv6Source";
            this.txtIPv6Source.Size = new System.Drawing.Size(305, 21);
            this.txtIPv6Source.TabIndex = 1;
            // 
            // txtIPv4Source
            // 
            this.txtIPv4Source.Location = new System.Drawing.Point(164, 56);
            this.txtIPv4Source.Name = "txtIPv4Source";
            this.txtIPv4Source.Size = new System.Drawing.Size(305, 21);
            this.txtIPv4Source.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "IPv4 Address Source";
            // 
            // txtCheckInterval
            // 
            this.txtCheckInterval.Location = new System.Drawing.Point(164, 94);
            this.txtCheckInterval.Name = "txtCheckInterval";
            this.txtCheckInterval.Size = new System.Drawing.Size(305, 21);
            this.txtCheckInterval.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Check Interval(Min)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtIPv6Source);
            this.groupBox1.Controls.Add(this.txtCheckInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIPv4Source);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 136);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Info";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(484, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 59);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Config";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAcc);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(10, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 294);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Config";
            // 
            // dgvAcc
            // 
            this.dgvAcc.AllowUserToAddRows = false;
            this.dgvAcc.AllowUserToDeleteRows = false;
            this.dgvAcc.AllowUserToOrderColumns = true;
            this.dgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAcc.Location = new System.Drawing.Point(3, 61);
            this.dgvAcc.Name = "dgvAcc";
            this.dgvAcc.ReadOnly = true;
            this.dgvAcc.RowTemplate.Height = 23;
            this.dgvAcc.Size = new System.Drawing.Size(431, 230);
            this.dgvAcc.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelAcc);
            this.panel1.Controls.Add(this.btnAddAcc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 44);
            this.panel1.TabIndex = 18;
            // 
            // btnDelAcc
            // 
            this.btnDelAcc.Location = new System.Drawing.Point(96, 2);
            this.btnDelAcc.Name = "btnDelAcc";
            this.btnDelAcc.Size = new System.Drawing.Size(87, 39);
            this.btnDelAcc.TabIndex = 8;
            this.btnDelAcc.Text = "Remove";
            this.btnDelAcc.UseVisualStyleBackColor = true;
            this.btnDelAcc.Click += new System.EventHandler(this.btnDelAcc_Click);
            // 
            // btnAddAcc
            // 
            this.btnAddAcc.Location = new System.Drawing.Point(3, 2);
            this.btnAddAcc.Name = "btnAddAcc";
            this.btnAddAcc.Size = new System.Drawing.Size(87, 39);
            this.btnAddAcc.TabIndex = 7;
            this.btnAddAcc.Text = "Add";
            this.btnAddAcc.UseVisualStyleBackColor = true;
            this.btnAddAcc.Click += new System.EventHandler(this.btnAddAcc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDns);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(447, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 294);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DNS Record Config";
            // 
            // dgvDns
            // 
            this.dgvDns.AllowUserToAddRows = false;
            this.dgvDns.AllowUserToDeleteRows = false;
            this.dgvDns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDns.Location = new System.Drawing.Point(3, 61);
            this.dgvDns.MultiSelect = false;
            this.dgvDns.Name = "dgvDns";
            this.dgvDns.ReadOnly = true;
            this.dgvDns.RowTemplate.Height = 23;
            this.dgvDns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDns.Size = new System.Drawing.Size(430, 230);
            this.dgvDns.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelDns);
            this.panel2.Controls.Add(this.btnAddDns);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 44);
            this.panel2.TabIndex = 19;
            // 
            // btnDelDns
            // 
            this.btnDelDns.Location = new System.Drawing.Point(96, 2);
            this.btnDelDns.Name = "btnDelDns";
            this.btnDelDns.Size = new System.Drawing.Size(87, 39);
            this.btnDelDns.TabIndex = 8;
            this.btnDelDns.Text = "Remove";
            this.btnDelDns.UseVisualStyleBackColor = true;
            this.btnDelDns.Click += new System.EventHandler(this.btnDelDns_Click);
            // 
            // btnAddDns
            // 
            this.btnAddDns.Location = new System.Drawing.Point(3, 2);
            this.btnAddDns.Name = "btnAddDns";
            this.btnAddDns.Size = new System.Drawing.Size(87, 39);
            this.btnAddDns.TabIndex = 7;
            this.btnAddDns.Text = "Add";
            this.btnAddDns.UseVisualStyleBackColor = true;
            this.btnAddDns.Click += new System.EventHandler(this.btnAddDns_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CloudFlare DDNS Config";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDns)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPv6Source;
        private System.Windows.Forms.TextBox txtIPv4Source;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCheckInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAcc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelAcc;
        private System.Windows.Forms.Button btnAddAcc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDns;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelDns;
        private System.Windows.Forms.Button btnAddDns;
        private System.Windows.Forms.BindingSource bsAcc;
        private System.Windows.Forms.BindingSource bsDns;
    }
}

