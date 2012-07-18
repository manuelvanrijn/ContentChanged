namespace ContentChanged
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.logGroup = new System.Windows.Forms.GroupBox();
            this.listLog = new System.Windows.Forms.ListBox();
            this.logGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(407, 4);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(117, 99);
            this.browser.TabIndex = 0;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.BrowserDocumentCompleted);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(261, 4);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(109, 23);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.Text = "Start monitoring";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.BtnMonitorClick);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(50, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(205, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "http://store.apple.com";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 9);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "URL:";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(240, 163);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(85, 13);
            this.lblRate.TabIndex = 5;
            this.lblRate.Text = "refresh rate (ms):";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(331, 160);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(39, 20);
            this.txtRate.TabIndex = 6;
            this.txtRate.Text = "3000";
            // 
            // logGroup
            // 
            this.logGroup.Controls.Add(this.listLog);
            this.logGroup.Location = new System.Drawing.Point(15, 32);
            this.logGroup.Name = "logGroup";
            this.logGroup.Size = new System.Drawing.Size(355, 122);
            this.logGroup.TabIndex = 7;
            this.logGroup.TabStop = false;
            this.logGroup.Text = "Log output";
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(6, 19);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(343, 95);
            this.listLog.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 188);
            this.Controls.Add(this.logGroup);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.browser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Content Changed";
            this.logGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.GroupBox logGroup;
        private System.Windows.Forms.ListBox listLog;
    }
}

