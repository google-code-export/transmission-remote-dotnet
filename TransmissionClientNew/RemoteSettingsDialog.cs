using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jayrock.Json;

namespace TransmissionRemoteDotnet
{
    public partial class RemoteSettingsDialog : Form
    {
        private static RemoteSettingsDialog instance = null;
        private static readonly object padlock = new object();

        public static RemoteSettingsDialog Instance
        {
            get
            {
                lock (padlock)
                {
                    if (!IsActive())
                    {
                        instance = new RemoteSettingsDialog();
                    }
                }
                return instance;
            }
        }

        private static bool IsActive()
        {
            return instance != null && !instance.IsDisposed;
        }

        public static void CloseIfOpen()
        {
            if (IsActive())
            {
                instance.Close();
            }
        }

        private RemoteSettingsDialog()
        {
            InitializeComponent();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoteSettingsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                JsonObject session = (JsonObject)Program.DaemonDescriptor.SessionData;
                DownloadToField.Text = (string)session["download-dir"];
                LimitDownloadValue.Enabled = LimitDownloadCheckBox.Checked = Toolbox.ToBool(session[ProtocolConstants.FIELD_SPEEDLIMITDOWNENABLED]);
                SetLimitField(Toolbox.ToInt(session[ProtocolConstants.FIELD_SPEEDLIMITDOWN]), LimitDownloadValue);
                LimitUploadValue.Enabled = LimitUploadCheckBox.Checked = Toolbox.ToBool(session[ProtocolConstants.FIELD_SPEEDLIMITUPENABLED]);
                SetLimitField(Toolbox.ToInt(session[ProtocolConstants.FIELD_SPEEDLIMITUP]), LimitUploadValue);
                if (session.Contains("port"))
                {
                    IncomingPortValue.Tag = "port";
                    IncomingPortValue.Value = Toolbox.ToInt(session["port"]);
                }
                else if (session.Contains("peer-port"))
                {
                    IncomingPortValue.Tag = "peer-port";
                    IncomingPortValue.Value = Toolbox.ToInt(session["peer-port"]);
                }
                PortForward.Checked = Toolbox.ToBool(session["port-forwarding-enabled"]);
                string enc = session["encryption"] as string;
                if (enc.Equals("preferred"))
                {
                    EncryptionCombobox.SelectedIndex = 1;
                }
                else if (enc.Equals("required"))
                {
                    EncryptionCombobox.SelectedIndex = 2;
                }
                else
                {
                    EncryptionCombobox.SelectedIndex = 0;
                }
                // peer limit
                if (session.Contains(ProtocolConstants.FIELD_PEERLIMIT))
                {
                    PeerLimitValue.Value = Toolbox.ToInt(session[ProtocolConstants.FIELD_PEERLIMIT]);
                    PeerLimitValue.Tag = ProtocolConstants.FIELD_PEERLIMIT;
                }
                else if (session.Contains("peer-limit-global"))
                {
                    PeerLimitValue.Value = Toolbox.ToInt(session["peer-limit-global"]);
                    PeerLimitValue.Tag = "peer-limit-global";
                }
                // pex
                if (session.Contains("pex-allowed"))
                {
                    PEXcheckBox.Checked = Toolbox.ToBool(session["pex-allowed"]);
                    PEXcheckBox.Tag = "pex-allowed";
                }
                else if (session.Contains("pex-enabled"))
                {
                    PEXcheckBox.Checked = Toolbox.ToBool(session["pex-enabled"]);
                    PEXcheckBox.Tag = "pex-enabled";
                }
                // blocklist
                if (updateBlocklistButton.Enabled = blocklistEnabledCheckBox.Enabled = session.Contains("blocklist-enabled"))
                {
                    blocklistEnabledCheckBox.Checked = Toolbox.ToBool(session["blocklist-enabled"]);
                }
                if (altSpeedLimitEnable.Enabled =
                    altUploadLimitField.Enabled =
                    altDownloadLimitField.Enabled =
                    altTimeConstraintEnabled.Enabled =
                    altTimeConstraintEndField.Enabled =
                    altTimeConstraintStartField.Enabled =
                    session.Contains("alt-speed-enabled"))
                {
                    altDownloadLimitField.Value = Toolbox.ToInt(session["alt-speed-down"]);
                    altUploadLimitField.Value = Toolbox.ToInt(session["alt-speed-up"]);
                    altDownloadLimitField.Enabled = altUploadLimitField.Enabled = altSpeedLimitEnable.Checked = Toolbox.ToBool(session["alt-speed-enabled"]);
                    altTimeConstraintStartField.Enabled = altTimeConstraintEndField.Enabled = altTimeConstraintEnabled.Checked = Toolbox.ToBool(session["alt-speed-time-enabled"]);
                }
                if (seedRatioEnabledCheckBox.Enabled = seedLimitUpDown.Enabled = session.Contains(ProtocolConstants.FIELD_SEEDRATIOLIMITED))
                {
                    seedLimitUpDown.Value = Toolbox.ToDecimal(session[ProtocolConstants.FIELD_SEEDRATIOLIMIT]);
                    seedRatioEnabledCheckBox.Checked = Toolbox.ToBool(session[ProtocolConstants.FIELD_SEEDRATIOLIMITED]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load settings data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SetLimitField(int limit, NumericUpDown field)
        {
            if (Program.DaemonDescriptor.Version < 1.40)
            {
                field.Value = limit >= 1024 && limit <= field.Maximum ? limit / 1024 : 0;
            }
            else
            {
                field.Value = limit >= 0 && limit <= field.Maximum ? limit : 0;
            }
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
            JsonObject request = Requests.CreateBasicObject(ProtocolConstants.METHOD_SESSIONSET);
            JsonObject arguments = Requests.GetArgObject(request);
            arguments.Put((string)IncomingPortValue.Tag, IncomingPortValue.Value);
            arguments.Put("port-forwarding-enabled", PortForward.Checked);
            arguments.Put((string)PEXcheckBox.Tag, PEXcheckBox.Checked);
            arguments.Put((string)PeerLimitValue.Tag, PeerLimitValue.Value);
            switch (EncryptionCombobox.SelectedIndex)
            {
                case 1:
                    arguments.Put("encryption", "preferred");
                    break;
                case 2:
                    arguments.Put("encryption", "required");
                    break;
                default:
                    arguments.Put("encryption", "tolerated");
                    break;
            }
            arguments.Put(ProtocolConstants.FIELD_SPEEDLIMITUPENABLED, LimitUploadCheckBox.Checked);
            arguments.Put(ProtocolConstants.FIELD_SPEEDLIMITUP, LimitUploadValue.Value);
            arguments.Put(ProtocolConstants.FIELD_SPEEDLIMITDOWNENABLED, LimitDownloadCheckBox.Checked);
            arguments.Put(ProtocolConstants.FIELD_SPEEDLIMITDOWN, LimitDownloadValue.Value);
            if (altSpeedLimitEnable.Enabled)
            {
                arguments.Put("alt-speed-enabled", altSpeedLimitEnable.Checked);
                arguments.Put("alt-speed-down", altDownloadLimitField.Value);
                arguments.Put("alt-speed-up", altUploadLimitField.Value);
            }
            if (altTimeConstraintEnabled.Enabled)
            {
                arguments.Put("alt-speed-time-enabled", altTimeConstraintEnabled.Checked);
                arguments.Put("alt-speed-time-begin", altTimeConstraintStartField.Value);
                arguments.Put("alt-speed-time-end", altTimeConstraintEndField.Value);
            }
            if (blocklistEnabledCheckBox.Enabled)
            {
                arguments.Put("blocklist-enabled", blocklistEnabledCheckBox.Checked);
            }
            if (seedRatioEnabledCheckBox.Enabled)
            {
                arguments.Put(ProtocolConstants.FIELD_SEEDRATIOLIMITED, seedRatioEnabledCheckBox.Checked);
                arguments.Put(ProtocolConstants.FIELD_SEEDRATIOLIMIT, seedLimitUpDown.Value);
            }
            arguments.Put("download-dir", DownloadToField.Text);
            SettingsWorker.RunWorkerAsync(request);
            this.Close();
        }

        private void SettingsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CommandFactory.Request((JsonObject)e.Argument);
        }

        private void SettingsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionCommand command = (TransmissionCommand)e.Result;
            command.Execute();
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            Program.Form.CreateActionWorker().RunWorkerAsync(Requests.SessionGet());
        }

        private void altSpeedLimitEnable_CheckedChanged(object sender, EventArgs e)
        {
            altUploadLimitField.Enabled = altDownloadLimitField.Enabled = altSpeedLimitEnable.Checked;
        }

        private void altTimeConstraintEnabled_CheckedChanged(object sender, EventArgs e)
        {
            altTimeConstraintStartField.Enabled = altTimeConstraintEndField.Enabled = altTimeConstraintEnabled.Checked;
        }

        private void blocklistEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateBlocklistButton.Enabled = blocklistEnabledCheckBox.Checked;
        }

        private void updateBlocklistButton_Click(object sender, EventArgs e)
        {
            Program.Form.CreateActionWorker().RunWorkerAsync(Requests.BlocklistUpdate());
        }

        private void seedRatioEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            seedLimitUpDown.Enabled = seedRatioEnabledCheckBox.Checked;
        }
    }
}
