namespace DDNS.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerCloudFlareDDNS = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerCloudFlareDDNSSvc = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerCloudFlareDDNS
            // 
            this.serviceProcessInstallerCloudFlareDDNS.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerCloudFlareDDNS.Password = null;
            this.serviceProcessInstallerCloudFlareDDNS.Username = null;
            // 
            // serviceInstallerCloudFlareDDNSSvc
            // 
            this.serviceInstallerCloudFlareDDNSSvc.DelayedAutoStart = true;
            this.serviceInstallerCloudFlareDDNSSvc.Description = "CloudFlare DDNS Service";
            this.serviceInstallerCloudFlareDDNSSvc.DisplayName = "CloudFlare DDNS Service";
            this.serviceInstallerCloudFlareDDNSSvc.ServiceName = "CloudFlareDDNSSvc";
            this.serviceInstallerCloudFlareDDNSSvc.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerCloudFlareDDNS,
            this.serviceInstallerCloudFlareDDNSSvc});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerCloudFlareDDNS;
        private System.ServiceProcess.ServiceInstaller serviceInstallerCloudFlareDDNSSvc;
    }
}