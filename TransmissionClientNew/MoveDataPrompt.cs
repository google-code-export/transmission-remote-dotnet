using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public partial class MoveDataPrompt : Form
    {
        private ListView.SelectedListViewItemCollection selections;

        public MoveDataPrompt(ListView.SelectedListViewItemCollection selections)
        {
            InitializeComponent();
            this.selections = selections;
            if (selections.Count < 1)
            {
                this.Close();
            }
            else if (selections.Count == 1)
            {
                Torrent t = (Torrent)selections[0].Tag;
                this.Text = String.Format(OtherStrings.MoveX, t.Name);
            }
            else
            {
                this.Text = OtherStrings.MoveMultipleTorrents;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Form.CreateActionWorker().RunWorkerAsync(Requests.TorrentSetLocation(Toolbox.ListViewSelectionToIdArray(selections), textBox1.Text, true));
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text.IndexOf('/') >= 0;
        }
    }
}
