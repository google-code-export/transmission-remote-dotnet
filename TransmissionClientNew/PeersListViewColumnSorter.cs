using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Comparers;

namespace TransmissionRemoteDotnet
{
    public class PeersListViewItemSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private IComparer ObjectCompare;

        public PeersListViewItemSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new ListViewTextInsensitiveComparer(0);
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            compareResult = ObjectCompare.Compare(x, y);
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        /* Set the column and choose the best IComparer implementation */

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
                switch (ColumnToSort)
                {
                    case 3:
                        ObjectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    case 4:
                        ObjectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 5:
                        ObjectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    default:
                        ObjectCompare = new ListViewTextInsensitiveComparer(value);
                        break;
                }
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}