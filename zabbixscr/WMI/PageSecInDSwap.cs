using System;
using System.Management;

namespace zabbixscr.WMI
{
    class PageSecInDSwap
    {
        internal static string Value
        {
            get
            {
                return _value();
            }
            private set
            {
                _value();
            }
        }
        private static string _value()
        {
            int q = 0;
            int w = 0;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    q = Convert.ToInt32(y["PagesPersec"]);
                }
                catch
                {
                    q = 101;
                    break;
                }
            }
            i.Dispose();
            ManagementObjectSearcher u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_PhysicalDisk");
            foreach (ManagementObject y in u.Get())
            {
                try
                {
                    w = Convert.ToInt32(y["AvgDisksecPerTransfer"]);
                }
                catch
                {
                    w = 101;
                    break;
                }
            }
            u.Dispose();
            int t = q * w;
            return Convert.ToString(t);
        }
    }
}
