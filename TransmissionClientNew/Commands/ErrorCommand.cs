using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    public class ErrorCommand : TransmissionCommand
    {
        private const int MAX_MESSAGE_LENGTH = 500;
        public string title;
        public string body;

        public ErrorCommand(string title, string body)
        {
            this.title = title;
            this.body = body;
        }

        public ErrorCommand(Exception ex)
        {
            this.title = ex.GetType().ToString();
            this.body = ex.Message;
        }

        private void ShowErrorBox(string title, string body)
        {
            MessageBox.Show(body.Length > MAX_MESSAGE_LENGTH ? body.Substring(0, MAX_MESSAGE_LENGTH) + "..." : body, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public void Execute()
        {
            MainWindow form = Program.form;
            Program.uploadArgs = null;
            if (!Program.Connected)
            {
                form.toolStripStatusLabel.Text = "Unable to connect (" + this.title + ")";
                ShowErrorBox(this.title, this.body);
            }
            else if (++Program.failCount > LocalSettingsSingleton.Instance.retryLimit)
            {
                Program.Connected = false;
                form.toolStripStatusLabel.Text = "Disconnected. Exceeded maximum number of failed requests.";
                Program.Log(this.title, this.body);
                ShowErrorBox(this.title, this.body);
            }
            else
            {
                Program.Log(this.title, this.body);
                form.toolStripStatusLabel.Text = "Failed request #" + Program.failCount + ": " + this.title;
            }
        }
    }
}
