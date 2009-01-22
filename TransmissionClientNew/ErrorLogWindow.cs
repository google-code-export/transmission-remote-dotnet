using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Commmands;

namespace TransmissionRemoteDotnet
{
    public partial class ErrorLogWindow : Form
    {
        private static ErrorLogWindow instance = null;
        private static readonly object padlock = new object();

        public static ErrorLogWindow Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new ErrorLogWindow();
                    }
                }
                return instance;
            }
        }

        private OnErrorDelegate onErrorDelegate;

        private ErrorLogWindow()
        {
            Program.onError += onErrorDelegate = new OnErrorDelegate(this.OnError);
            InitializeComponent();
        }

        private void ErrorLogWindow_Load(object sender, EventArgs e)
        {
            lock (Program.LogItems)
            {
                lock (errorListView)
                {
                    foreach (ListViewItem item in Program.LogItems)
                    {
                        errorListView.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lock (errorListView)
            {
                errorListView.Items.Clear();
            }
            lock (Program.LogItems)
            {
                Program.LogItems.Clear();
            }
        }

        private void ErrorLogWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.onError -= onErrorDelegate;
        }

        private void OnError()
        {
            errorListView.SuspendLayout();
            lock (Program.LogItems)
            {
                lock (errorListView)
                {
                    List<ListViewItem> logItems = Program.LogItems;
                    if (logItems.Count > errorListView.Items.Count)
                    {
                        for (int i = errorListView.Items.Count; i < logItems.Count; i++)
                        {
                            errorListView.Items.Add((ListViewItem)logItems[i].Clone());
                        }
                    }
                }
            }
            errorListView.ResumeLayout();
        }

        private void errorListView_DoubleClick(object sender, EventArgs e)
        {
            lock (errorListView)
            {
                if (errorListView.SelectedItems.Count == 1)
                {
                    Clipboard.SetText(errorListView.SelectedItems[0].SubItems[2].Text);
                }
            }
        }
    }
}
