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
        private int columnToSort;
        private SortOrder orderOfSort;
        private IComparer objectCompare;

        public PeersListViewItemSorter()
        {
            columnToSort = 0;
            orderOfSort = SortOrder.None;
            objectCompare = new ListViewItemIPComparer(0);
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            compareResult = objectCompare.Compare(x, y);
            if (orderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (orderOfSort == SortOrder.Descending)
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
                columnToSort = value;
                switch (columnToSort)
                {
                    case 0:
                        objectCompare = new ListViewItemIPComparer(value);
                        break;
                    case 1:
                        objectCompare = new ListViewTextInsensitiveReverseComparer(value);
                        break;
                    case 5:
                        objectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    case 6:
                        objectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 7:
                        objectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    default:
                        objectCompare = new ListViewTextComparer(value, true);
                        break;
                }
            }
            get
            {
                return columnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                orderOfSort = value;
            }
            get
            {
                return orderOfSort;
            }
        }
    }
}