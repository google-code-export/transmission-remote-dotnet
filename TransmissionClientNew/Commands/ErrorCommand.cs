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
        private string title;
        private string body;
        public bool showDontCount = false;

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

        private delegate void ExecuteDelegate();
        public void Execute()
        {
            MainWindow form = Program.form;
            if (Program.form.InvokeRequired)
            {
                form.Invoke(new ExecuteDelegate(this.Execute));
            }
            else
            {
                Program.uploadArgs = null;
                if (!Program.Connected)
                {
                    form.toolStripStatusLabel.Text = "Unable to connect (" + this.title + ")";
                    ShowErrorBox(this.title, this.body);
                }
                else if (showDontCount)
                {
                    ShowErrorBox(this.title, this.body);
                }
                else if (++Program.failCount > LocalSettingsSingleton.Instance.retryLimit)
                {
                    Program.Connected = false;
                    form.toolStripStatusLabel.Text = "Disconnected. Exceeded maximum number of failed requests.";
                    ShowErrorBox(this.title, this.body);
                }
                else
                {
                    form.toolStripStatusLabel.Text = "Failed request #" + Program.failCount + ": " + this.title;
                }
                Program.Log(this.title, this.body);
            }
        }
    }
}
