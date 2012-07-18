namespace ContentChanged
{
    using System;
    using System.Windows.Forms;
    using System.Security.Cryptography;

    public partial class FrmMain : Form
    {
        private string _content;
        private bool _started;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Controls and Events
        private void BtnMonitorClick(object sender, EventArgs e)
        {
            _started = !_started;
            if(_started)
                Start();
            else
                Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Log("checking...");
            browser.Url = new Uri(txtUrl.Text);
        }

        private void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var hash = GetHash(browser.DocumentText);
            CheckNewContent(hash);
        }
        #endregion

        #region Logic
        protected void Start()
        {
            listLog.Items.Clear();
            _content = string.Empty;
            timer.Interval = int.Parse(txtRate.Text);
            timer.Enabled = true;
            browser.Url = new Uri(txtUrl.Text);

            btnMonitor.Text = "Stop monitoring";
            txtUrl.Enabled = false;
            txtRate.Enabled = false;
            Log("Started");
        }

        protected void Stop()
        {
            timer.Enabled = false;
            btnMonitor.Text = "Start monitoring";
            txtUrl.Enabled = true;
            txtRate.Enabled = true;
            Log("Stopped");
        }

        protected void CheckNewContent(string content)
        {
            if (_content == string.Empty)
            {
                _content = content;
                Log("setting initial content...");
                return;
            }

            if(_content != content)
            {
                Stop();
                Log("Content changed! Monitoring stopped", true);
                MessageBox.Show("Content Changed!");
            }
            else
            {
                Log("nothing changed...", true);
            }

        }
        #endregion
        
        #region Helpers
        protected string GetHash(string input)
        {
            var x = new MD5CryptoServiceProvider();
            var bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            var s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        protected void Log(string message)
        {
            Log(message, false);
        }

        protected void Log(string message, bool replacePrevious)
        {
            if(replacePrevious)
                listLog.Items.RemoveAt(listLog.Items.Count-1);

            listLog.Items.Add(string.Format("{0} - {1}", DateTime.Now.ToString("HH:mm:ss"), message));
        }
        #endregion
    }
}
