using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Comparers;

namespace TransmissionRemoteDotnet
{
    public class FilesListViewItemSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private IComparer ObjectCompare;

        public FilesListViewItemSorter()
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
                    case 1:
                        ObjectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 2:
                        ObjectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 3:
                        ObjectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    default:
                        ObjectCompare = new ListViewTextInsensitiveComparer(ColumnToSort);
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