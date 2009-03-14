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
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            label1.Text = String.Format("Transmission Remote v{0}.{1} ({2} {3})", version.Major, version.Minor, OtherStrings.Build.ToLower(), version.Build);
            label3.Text = String.Format("{0}: Alan F <{1}>", OtherStrings.Author, Encoding.ASCII.GetString(Convert.FromBase64String("YWxhbkBldGgwLm9yZy51aw==")));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
