using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public partial class PiecesGraph : UserControl
    {
        private byte[] bits;
        private int len;
        public PiecesGraph()
        {
            len = 0;
            // Set Optimized Double Buffer to reduce flickering
            this.SetStyle(ControlStyles.UserPaint, true);
//            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Redraw when resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (len > 0)
            {
                decimal arany = (decimal)len / Width;
                for (int n = 0; n < Width; n++)
                {
                    if (BitGet(bits, len, (int)(n * arany)))
                    {
                        e.Graphics.DrawLine(new Pen(ForeColor), n, 0, n, Height);
                    }
                }
            }
        }

        private bool BitGet(byte[] array, int len, int index)
        {
            if (index < 0 || index >= len)
                throw new ArgumentOutOfRangeException();
            return (array[index >> 3] & (1 << ((7-index) & 7))) != 0;
        }

        public void ApplyBits(byte[] b, int len)
        {
            this.len = len;
            this.bits = b;
            Invalidate();
        }

        public void ClearBits()
        {
            this.len = 0;
            this.bits = new byte[0];
            Invalidate();
        }
    }
}
