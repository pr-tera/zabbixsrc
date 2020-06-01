using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class SerialNumberLD
    {
        internal static string Number
        {
            get
            {
                return _number();
            }
            private set
            {
                _number();
            }
        }
        private static string _number()
        {
            string t = string.Empty;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Name"]) == Data.argT)
                    {
                        t = Convert.ToString(y["VolumeSerialNumber"]);
                    }
                }
                catch
                {
                    t = "101";
                    break;
                }
            }
            i.Dispose();
            return t;
        }
    }
}
