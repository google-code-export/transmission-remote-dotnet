using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionClientNew
{
    public partial class RemoteSettingsDialog : Form
    {
        public RemoteSettingsDialog()
        {
            InitializeComponent();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoteSettingsDialog_Load(object sender, EventArgs e)
        {
            JsonObject settings = (JsonObject)Program.sessionData[ProtocolConstants.KEY_ARGUMENTS];
            DownloadToField.Text = (string)settings["download-dir"];
            LimitDownloadCheckBox.Checked = ((JsonNumber)settings["speed-limit-down-enabled"]).ToInt32() == 1;
            LimitDownloadValue.Enabled = LimitDownloadCheckBox.Checked;
            LimitDownloadValue.Value = ((JsonNumber)settings["speed-limit-down"]).ToInt32()/1024;
            LimitUploadCheckBox.Checked = ((JsonNumber)settings["speed-limit-up-enabled"]).ToInt32() == 1;
            LimitUploadValue.Enabled = LimitUploadCheckBox.Checked;
            LimitUploadValue.Value = ((JsonNumber)settings["speed-limit-up"]).ToInt32()/1024;
            IncomingPortValue.Value = ((JsonNumber)settings["port"]).ToInt32();
        }

        private void LimitUploadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LimitUploadValue.Enabled = LimitUploadCheckBox.Checked;
        }

        private void LimitDownloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LimitDownloadValue.Enabled = LimitDownloadCheckBox.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            JsonObject request = new JsonObject();
            request.Put("method", "session-set");
            JsonObject arguments = new JsonObject();
            arguments.Put("port", IncomingPortValue.Value);
            arguments.Put("speed-limit-up-enabled", LimitUploadCheckBox.Checked);
            arguments.Put("speed-limit-up", LimitUploadValue.Value);
            arguments.Put("speed-limit-down-enabled", LimitDownloadCheckBox.Checked);
            arguments.Put("speed-limit-down", LimitDownloadValue.Value);
            arguments.Put("download-dir", DownloadToField.Text);
            request.Put(ProtocolConstants.KEY_ARGUMENTS, arguments);
            request.Put(ProtocolConstants.KEY_TAG, (int)ResponseTag.DoNothing);
            SettingsWorker.RunWorkerAsync(request);
            this.Close();
        }

        private void SettingsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request((JsonObject)e.Argument);
            CommandFactory.Request(Requests.SessionGet());
        }

        private void SettingsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
        }
    }
}
