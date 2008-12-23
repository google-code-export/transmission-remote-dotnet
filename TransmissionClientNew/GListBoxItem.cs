/* http://www.codeproject.com/KB/combobox/glistbox.aspx
 * + some of my fixes. */

using System.Windows.Forms;

namespace TransmissionRemoteDotnet
{
    public class GListBoxItem
    {
        private string _myText;
        private int _myImageIndex;

        public string Text
        {
            get { return _myText; }
            set { _myText = value; }
        }

        public int ImageIndex
        {
            get { return _myImageIndex; }
            set { _myImageIndex = value; }
        }

        public GListBoxItem(string text, int index)
        {
            _myText = text;
            _myImageIndex = index;
        }

        public GListBoxItem(string text) : this(text, -1) { }
        public GListBoxItem() : this("") { }
        public override string ToString()
        {
            return _myText;
        }
    }
}