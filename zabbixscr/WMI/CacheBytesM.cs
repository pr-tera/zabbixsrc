using System;
using System.Management;

namespace zabbixscr.WMI
{
    class CacheBytesM
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
            double t = 0;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    t = Math.Round((double)Convert.ToInt64(y["CacheBytes"]) / 1e+9, 0);
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
