using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace TransmissionClientNew.Commmands
{
    class UpdatePrioritiesCommand : TransmissionCommand
    {
        private JsonObject response;

        public UpdatePrioritiesCommand(JsonObject response)
        {
            this.response = response;
            Program.ResetFailCount();
        }

        public void Execute()
        {
            JsonObject arguments = (JsonObject)response[ProtocolConstants.KEY_ARGUMENTS];
            JsonArray torrents = (JsonArray)arguments[ProtocolConstants.KEY_TORRENTS];
            JsonObject torrent = (JsonObject)torrents[0];
            int id = ((JsonNumber)torrent[ProtocolConstants.FIELD_ID]).ToInt32();
            TorrentInfoDialog form;
            if (Program.infoDialogs.ContainsKey(id))
            {
                form = Program.infoDialogs[id];
            }
            else
            {
                return;
            }
            UpdateFilesCommand.UpdateFiles(torrent, form);
            if (torrent[ProtocolConstants.FIELD_UPLOADLIMITMODE] != null)
            {
                form.UploadLimitEnable.Enabled = form.DownloadLimitEnable.Enabled = true;
                form.UploadLimitField.Enabled = form.UploadLimitEnable.Checked = ((JsonNumber)torrent[ProtocolConstants.FIELD_UPLOADLIMITMODE]).ToBoolean();
                int upLimit = ((JsonNumber)torrent[ProtocolConstants.FIELD_UPLOADLIMIT]).ToInt32();
                form.UploadLimitField.Value = upLimit >= 0 && upLimit <= form.UploadLimitField.Maximum ? upLimit : 0;
                form.DownloadLimitField.Enabled = form.DownloadLimitEnable.Checked = ((JsonNumber)torrent[ProtocolConstants.FIELD_DOWNLOADLIMITMODE]).ToBoolean();
                int downLimit = ((JsonNumber)torrent[ProtocolConstants.FIELD_DOWNLOADLIMIT]).ToInt32();
                form.DownloadLimitField.Value = downLimit >= 0 && downLimit <= form.DownloadLimitField.Maximum ? downLimit : 0;
                form.FilesListView.Enabled = true;
                Toolbox.StripeListView(form.FilesListView);
            }
            form.StatusStripLabel.Text = "";
        }
    }
}
