using System;
using System.Management;

namespace zabbixscr.Standart
{
    class CacheBytesM
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(double))
                {
                    double i = Convert.ToDouble(_value);
                    if (i != 101)
                    {
                        return Convert.ToString(i);
                    }
                    else
                    {
                        return "00000";
                    }
                }
                else
                {
                    return "00000";
                }
            }
        }
        private static object WMIQuery()
        {
            double t = 0;
            try
            {
                ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory");
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        t = Math.Round(Convert.ToInt64(y["CacheBytes"]) / 1e+9, 0);
                    }
                    catch
                    {
                        t = 101;
                        break;
                    }
                }
                i.Dispose();
            }
            catch
            {
                t = 101;
            }
            return t;
        }
    }
}
