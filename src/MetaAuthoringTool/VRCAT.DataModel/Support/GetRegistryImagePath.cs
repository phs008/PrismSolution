using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    public class GetRegistryImagePath
    {
        private static Hashtable _IconsInfo;
        public static Hashtable IconsInfo
        {
            get
            {
                if(_IconsInfo == null)
                {
                    _IconsInfo = new Hashtable();
                    Init();
                }
                return _IconsInfo;
            }
        }
        private static void Init()
        {
            // Create a registry key object to represent the HKEY_CLASSES_ROOT registry section
            RegistryKey rkRoot = Registry.ClassesRoot;

            //Gets all sub keys' names.
            string[] keyNames = rkRoot.GetSubKeyNames();

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
                        IconsInfo.Add(keyName, fileParam);
                    }
                    rkFileIcon.Close();
                }
                rkFileType.Close();
            }
            rkRoot.Close();
        }
    }
}
