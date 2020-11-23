using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class FreeSpaceLD
    {
        internal static string Value
        {
            get
            {
                return _size();
            }
            private set
            {
                _size();
            }
        }
        private static string _size()
        {
            double t = 0;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Name"]) == Data.argT)
                    {
                        t = Math.Round((double)Convert.ToInt64(y["FreeSpace"]) / 1024 / 1024 / 1024, 0);
                    }
                }
                catch
                {
                    t = 101;
                    break;
                }
            }
            i.Dispose();
            return Convert.ToString(t);
        }
    }
}
