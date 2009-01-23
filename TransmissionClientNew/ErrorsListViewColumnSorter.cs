using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Comparers;

namespace TransmissionRemoteDotnet
{
    public class ErrorsListViewColumnSorter : IComparer
    {
        private int columnToSort;
        private SortOrder orderOfSort;
        private IComparer objectCompare;

        public ErrorsListViewColumnSorter()
        {
            columnToSort = 0;
            orderOfSort = SortOrder.Descending;
            objectCompare = new ListViewTextComparer(0, false);
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

        public int SortColumn
        {
            set
            {
                columnToSort = value;
                switch (columnToSort)
                {
                    default:
                        objectCompare = new ListViewTextComparer(columnToSort, false);
                        break;
                }
            }
            get
            {
                return columnToSort;
            }
        }
    }
}
