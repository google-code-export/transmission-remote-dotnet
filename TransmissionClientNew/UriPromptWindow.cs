using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using TransmissionRemoteDotnet.Commmands;

namespace TransmissionRemoteDotnet
{
    public enum DownloadAndUploadTorrentState
    {
        Downloading,
        DownloadFailed,
        Complete
    }

    public partial class UriPromptWindow : Form
    {
        private Uri currentUri;

        public UriPromptWindow()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.DaemonDescriptor.Revision >= 7744)
            {
                Program.Form.CreateActionWorker().RunWorkerAsync(Requests.TorrentAddByUrl(this.textBox1.Text));
                this.Close();
            }
            else
            {
                try
                {
                    string target = Path.GetTempFileName();
                    toolStripStatusLabel1.Text = "Downloading...";
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Value = 0;
                    button1.Enabled = false;
                    WebClient webClient = new TransmissionWebClient(false);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(this.currentUri, target, target);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        private void HandleException(Exception ex)
        {
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Text = ex.Message;
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    this.currentUri = new Uri(textBox1.Text);
                    toolStripStatusLabel1.Text = "Input accepted.";
                    button1.Enabled = true;
                }
                catch (Exception ex)
                {
                    button1.Enabled = false;
                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Waiting for input...";
                button1.Enabled = false;
            }
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HandleException(e.Error);
                button1.Enabled = true;
            }
            else
            {
                Program.Form.CreateActionWorker().RunWorkerAsync(Requests.TorrentAddByFile((string)e.UserState, true));
                this.Close();
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = String.Format("Downloading ({0}%)...", e.ProgressPercentage);
        }
    }
}
