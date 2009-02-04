using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using TransmissionRemoteDotnet.Comparers;

namespace TransmissionRemoteDotnet
{
    public class ListViewItemSorter : IComparer
    {
        private int columnToSort;
        private SortOrder orderOfSort;
        private IComparer objectCompare;
        
        public ListViewItemSorter()
        {
            columnToSort = 0;
            orderOfSort = SortOrder.None;
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

        /* Set the column and choose the best IComparer implementation */

        public int SortColumn
        {
            set
            {
                columnToSort = value;
                switch (columnToSort)
                {
                    case 0:
                        objectCompare = new ListViewTextComparer(0, false);
                        break;
                    case 1:
                        objectCompare = new ListViewTorrentInt64Comparer(ProtocolConstants.FIELD_TOTALSIZE);
                        break;
                    case 2:
                        objectCompare = new ListViewItemDecimalComparer(value);
                        break;
                    case 4:
                        objectCompare = new ListViewTorrentInt32Comparer(ProtocolConstants.FIELD_SEEDERS);
                        break;
                    case 5:
                        objectCompare = new ListViewTorrentInt32Comparer(ProtocolConstants.FIELD_LEECHERS);
                        break;
                    case 6:
                        objectCompare = new ListViewTorrentInt32Comparer(ProtocolConstants.FIELD_RATEDOWNLOAD);
                        break;
                    case 7:
                        objectCompare = new ListViewTorrentInt32Comparer(ProtocolConstants.FIELD_RATEUPLOAD);
                        break;
                    case 8:
                        objectCompare = new ListViewTorrentInt64Comparer(ProtocolConstants.FIELD_ETA);
                        break;
                    case 9:
                        objectCompare = new ListViewTorrentInt64Comparer(ProtocolConstants.FIELD_UPLOADEDEVER);
                        break;
                    case 10:
                        objectCompare = new ListViewTorrentRatioComparer();
                        break;
                    case 11:
                        objectCompare = new ListViewTorrentInt64Comparer(ProtocolConstants.FIELD_ADDEDDATE);
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
