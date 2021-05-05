using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class PhysicalDiskSize
    {
        internal static string Size
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Model"]) == Data.argT)
                    {
                        t = Math.Round((double)Convert.ToInt64(y["Size"]) / 1024 / 1024 / 1024, 0);
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
