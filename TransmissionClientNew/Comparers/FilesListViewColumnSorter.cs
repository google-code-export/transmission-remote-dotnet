using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace TransmissionRemoteDotnet.Comparers
{
    public class FilesListViewItemSorter : IComparer
    {
        private int columnToSort;
        private SortOrder orderOfSort;
        private IComparer objectCompare;

        public FilesListViewItemSorter()
        {
            columnToSort = 0;
            orderOfSort = SortOrder.None;
            objectCompare = new ListViewTextComparer(0, true);
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
                    case 1:
                        objectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 2:
                        objectCompare = new ListViewItemInt64Comparer(value);
                        break;
                    case 3:
                        objectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    default:
                        objectCompare = new ListViewTextComparer(columnToSort, true);
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