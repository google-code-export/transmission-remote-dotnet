using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public partial class UriPromptWindow : Form
    {
        private Uri currentUri;
        private event UriDelegate onUriChosen;

        public UriPromptWindow(UriDelegate onUriChosen)
        {
            this.onUriChosen = onUriChosen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (onUriChosen != null)
            {
                onUriChosen(currentUri);
            }
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currentUri = new Uri(textBox1.Text);
            }
            catch
            {
                try
                {
                    currentUri = new Uri("http://" + textBox1.Text);
                }
                catch
                {
                    button1.Enabled = false;
                    return;
                }
            }
            button1.Enabled = true;
        }
    }

    public delegate void UriDelegate(Uri uri);
}
