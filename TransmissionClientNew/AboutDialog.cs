using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TransmissionRemoteDotnet
{
    public partial class AboutDialog : Form
    {
        public const string PROJECT_SITE = "http://code.google.com/p/transmission-remote-dotnet/";

        private static AboutDialog instance = null;
        private static readonly object padlock = new object();

        public static AboutDialog Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new AboutDialog();
                    }
                }
                return instance;
            }
        }

        private AboutDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(PROJECT_SITE);
        }
    }
}
