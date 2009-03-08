using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Commmands
{
    public class ErrorCommand : TransmissionCommand
    {
        private const int MAX_MESSAGE_DIALOG_LENGTH = 500;
        private const int MAX_MESSAGE_STATUSBAR_LENGTH = 120;

        private string title;
        private string body;
        private bool showDontCount;

        public ErrorCommand(string title, string body, bool showDontCount)
        {
            this.title = title;
            this.body = body;
            this.showDontCount = showDontCount;
        }

        public ErrorCommand(Exception ex, bool showDontCount)
        {
            this.title = OtherStrings.Error;
            this.body = ex.Message;
            this.showDontCount = showDontCount;
        }

        private void ShowErrorBox(string title, string body)
        {
            MessageBox.Show(TrimText(body, MAX_MESSAGE_DIALOG_LENGTH), title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private delegate void ExecuteDelegate();
        public void Execute()
        {
            MainWindow form = Program.Form;
            if (Program.Form.InvokeRequired)
            {
                form.Invoke(new ExecuteDelegate(this.Execute));
            }
            else
            {
                Program.UploadArgs = null;
                if (!Program.Connected)
                {
                    form.toolStripStatusLabel.Text = this.StatusBarMessage;
                    ShowErrorBox(this.title, this.body);
                }
                else if (showDontCount)
                {
                    ShowErrorBox(this.title, this.body);
                }
                else if (++Program.DaemonDescriptor.FailCount > LocalSettingsSingleton.Instance.RetryLimit)
                {
                    Program.Connected = false;
                    form.toolStripStatusLabel.Text = OtherStrings.DisconnectedExceeded;
                    ShowErrorBox(this.title, this.body);
                }
                else
                {
                    form.toolStripStatusLabel.Text = String.Format("{0} #{1}: {2}", OtherStrings.FailedRequest, Program.DaemonDescriptor.FailCount, this.StatusBarMessage);
                }
                Program.Log(this.title, this.body);
            }
        }

        private string StatusBarMessage
        {
            get
            {
                return !this.title.Equals(OtherStrings.Error) ? this.title : TrimText(this.body, MAX_MESSAGE_STATUSBAR_LENGTH);
            }
        }

        private string TrimText(string s, int len)
        {
            return s.Length < len ? s : s.Substring(0, len) + "...";
        }
    }
}
