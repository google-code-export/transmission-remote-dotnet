using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TransmissionRemoteDotnet
{
    class SelectableLabel : TextBox
    {
        public SelectableLabel()
        {
            
            base.BorderStyle = System.Windows.Forms.BorderStyle.None;
            base.ReadOnly = true;
            base.Text = "";
#if !MONO
            base.MouseUp += new MouseEventHandler(
                delegate(object sender, MouseEventArgs e) { HideCaret((sender as Control).Handle); }
            );
#endif
        }

        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
#if !MONO
        [DllImport("User32.dll")]
        static extern Boolean HideCaret(IntPtr hWnd);
#endif
    }
}
