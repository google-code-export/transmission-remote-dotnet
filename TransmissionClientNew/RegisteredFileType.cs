/* Author: kidvn
 * Source: http://www.codeproject.com/KB/cs/GetFileTypeAndIcon.aspx
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace TransmissionRemoteDotnet
{
    public class RegisteredFileType
    {
        #region APIs

        [DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

        #endregion

        private Hashtable icons;

        public Hashtable Icons
        {
            get { return icons; }
            set { icons = value; }
        }

        public RegisteredFileType()
        {
            this.icons = GetFileTypeAndIcon();
        }

        /// <summary>
        /// Gets registered file types and their associated icon in the system.
        /// </summary>
        /// <returns>Returns a hash table which contains the file extension as keys, the icon file and param as values.</returns>
        private Hashtable GetFileTypeAndIcon()
        {
            try
            {
                // Create a registry key object to represent the HKEY_CLASSES_ROOT registry section
                RegistryKey rkRoot = Registry.ClassesRoot;

                //Gets all sub keys' names.
                string[] keyNames = rkRoot.GetSubKeyNames();
                Hashtable iconsInfo = new Hashtable();

                //Find the file icon.
                foreach (string keyName in keyNames)
                {
                    if (String.IsNullOrEmpty(keyName))
                        continue;
                    int indexOfPoint = keyName.IndexOf(".");

                    //If this key is not a file exttension(eg, .zip), skip it.
                    if (indexOfPoint != 0)
                        continue;

                    RegistryKey rkFileType = rkRoot.OpenSubKey(keyName);
                    if (rkFileType == null)
                        continue;

                    //Gets the default value of this key that contains the information of file type.
                    object defaultValue = rkFileType.GetValue("");
                    if (defaultValue == null)
                        continue;

                    //Go to the key that specifies the default icon associates with this file type.
                    string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
                    RegistryKey rkFileIcon = rkRoot.OpenSubKey(defaultIcon);
                    if (rkFileIcon != null)
                    {
                        //Get the file contains the icon and the index of the icon in that file.
                        object value = rkFileIcon.GetValue("");
                        if (value != null)
                        {
                            //Clear all unecessary " sign in the string to avoid error.
                            string fileParam = value.ToString().Replace("\"", "");
                            iconsInfo.Add(keyName, fileParam);
                        }
                        rkFileIcon.Close();
                    }
                    rkFileType.Close();
                }
                rkRoot.Close();
                return iconsInfo;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}