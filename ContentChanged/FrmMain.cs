namespace ContentChanged
{
    using System;
    using System.Windows.Forms;
    using System.Security.Cryptography;
    using Properties;

    /// <summary>
    /// Main Form
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Contains the content of the previous fetch
        /// </summary>
        private string _content;

        /// <summary>
        /// Indicated if program is monitoring
        /// </summary>
        private bool _started;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Controls and Events
        /// <summary>
        /// Start/Stop monitoring
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnMonitorClick(object sender, EventArgs e)
        {
            _started = !_started;
            if(_started)
                Start();
            else
                Stop();
        }

        /// <summary>
        /// Tick event of the Timer
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            Log("checking...");
            browser.Url = new Uri(txtUrl.Text);
        }

        /// <summary>
        /// Browsers finished loading document event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.WebBrowserDocumentCompletedEventArgs"/> instance containing the event data.</param>
        private void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var hash = GetHash(browser.DocumentText);
            CheckNewContent(hash);
        }
        #endregion

        #region Logic
        /// <summary>
        /// Start Monitoring
        /// </summary>
        protected void Start()
        {
            listLog.Items.Clear();
            _content = string.Empty;
            timer.Interval = int.Parse(txtRate.Text);
            timer.Enabled = true;
            browser.Url = new Uri(txtUrl.Text);

            btnMonitor.Text = Resources.stopMonitoring;
            txtUrl.Enabled = false;
            txtRate.Enabled = false;
            Log("Started");
        }

        /// <summary>
        /// Stop Monitoring
        /// </summary>
        protected void Stop()
        {
            timer.Enabled = false;
            btnMonitor.Text = Resources.startMonitoring;
            txtUrl.Enabled = true;
            txtRate.Enabled = true;
            Log("Stopped");
        }

        /// <summary>
        /// Compare the new content with the previous content
        /// </summary>
        /// <param name="content">The content.</param>
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
                Log("Content changed! Monitoring stopped", true);
                Stop();
                _started = false;
                MessageBox.Show(Resources.contentChanged);
            }
            else
            {
                Log("nothing changed...", true);
            }

        }
        #endregion
        
        #region Helpers
        /// <summary>
        /// Converts a string into a MD5 hash
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>md5 hash</returns>
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

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void Log(string message)
        {
            Log(message, false);
        }

        /// <summary>
        /// Logs the specified message and remove's the previous inserted line.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="replacePrevious">if set to <c>true</c> replace previous logged message.</param>
        protected void Log(string message, bool replacePrevious)
        {
            if(replacePrevious)
                listLog.Items.RemoveAt(listLog.Items.Count-1);

            listLog.Items.Add(string.Format("{0} - {1}", DateTime.Now.ToString("HH:mm:ss"), message));
        }
        #endregion
    }
}
