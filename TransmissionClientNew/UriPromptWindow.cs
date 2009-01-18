using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        Uploading,
        DownloadFailed,
        UploadFailed,
        Complete
    }

    public partial class UriPromptWindow : Form
    {
        private Uri currentUri;
        private Exception lastException;

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
            if (Program.transmissionRevision >= 7744)
            {
                Program.form.CreateActionWorker().RunWorkerAsync(Requests.TorrentAdd(this.textBox1.Text));
                this.Close();
            }
            else
            {
                downloadAndUploadTorrentWorker.RunWorkerAsync(this.currentUri);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    currentUri = new Uri(textBox1.Text);
                }
                catch
                {
                    try
                    {
                        currentUri = new Uri("http://" + textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        button1.Enabled = false;
                        toolStripStatusLabel1.Text = ex.Message;
                        return;
                    }
                }
                toolStripStatusLabel1.Text = "Input accepted.";
                button1.Enabled = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "Waiting for input...";
                button1.Enabled = false;
            }
        }

        private void downloadTorrentWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string target = Path.GetTempFileName();
            downloadAndUploadTorrentWorker.ReportProgress(0, DownloadAndUploadTorrentState.Downloading);
            try
            {
                WebClient webClient = new WebClient();
                LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;
                if (settings.proxyEnabled == 1)
                {
                    webClient.Proxy = new WebProxy(settings.proxyHost, settings.proxyPort);
                    if (settings.proxyAuth)
                    {
                        webClient.Proxy.Credentials = new NetworkCredential(settings.proxyUser, settings.proxyPass);
                    }
                }
                else if (settings.proxyEnabled == 2)
                {
                    webClient.Proxy = null;
                }
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                webClient.DownloadFile(this.currentUri, target);
            }
            catch (Exception ex)
            {
                lastException = ex;
                downloadAndUploadTorrentWorker.ReportProgress(0, DownloadAndUploadTorrentState.DownloadFailed);
                return;
            }
            downloadAndUploadTorrentWorker.ReportProgress(50, DownloadAndUploadTorrentState.Uploading);
            if ((lastException = Toolbox.UploadFile(target, true, new UploadProgressChangedEventHandler(webClient_UploadProgressChanged))) != null)
            {
                downloadAndUploadTorrentWorker.ReportProgress(50, DownloadAndUploadTorrentState.UploadFailed);
                return;
            }
            downloadAndUploadTorrentWorker.ReportProgress(100, DownloadAndUploadTorrentState.Complete);
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadAndUploadTorrentWorker.ReportProgress(e.ProgressPercentage / 2, DownloadAndUploadTorrentState.Downloading);
        }

        private void webClient_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            downloadAndUploadTorrentWorker.ReportProgress((e.ProgressPercentage / 2) + 50, DownloadAndUploadTorrentState.Uploading);
        }

        private void downloadAndUploadTorrentWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch ((DownloadAndUploadTorrentState)e.UserState)
            {
                case DownloadAndUploadTorrentState.Downloading:
                    toolStripStatusLabel1.Text = "Downloading...";
                    toolStripProgressBar1.Visible = true;
                    break;
                case DownloadAndUploadTorrentState.Uploading:
                    toolStripStatusLabel1.Text = "Uploading...";
                    break;
                case DownloadAndUploadTorrentState.DownloadFailed:
                    MessageBox.Show(lastException.Message,
                        toolStripStatusLabel1.Text = String.Format("Download failed ({0})", lastException.GetType().ToString()),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetToolStrip();
                    break;
                case DownloadAndUploadTorrentState.UploadFailed:
                    MessageBox.Show(lastException.Message,
                        toolStripStatusLabel1.Text = String.Format("Upload failed ({0})", lastException.GetType().ToString()),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetToolStrip();
                    break;
                case DownloadAndUploadTorrentState.Complete:
                    Program.form.RefreshIfNotRefreshing();
                    this.Close();
                    return;
            }
            try
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            catch { }
        }

        private void ResetToolStrip()
        {
            try
            {
                toolStripProgressBar1.Visible = false;
            }
            catch { }
        }
    }
}
