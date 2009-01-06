using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Comparers
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
            ObjectCompare = new ListViewItemIPComparer(0);
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
                    case 0:
                        ObjectCompare = new ListViewItemIPComparer(value);
                        break;
                    case 1:
                        ObjectCompare = new ListViewTextInsensitiveReverseComparer(value);
                        break;
                    case 4:
                        ObjectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    case 5:
                        ObjectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 6:
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