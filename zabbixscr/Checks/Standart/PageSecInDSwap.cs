using System;
using System.Management;

namespace zabbixscr.Standart
{
    class PageSecInDSwap
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(int))
                {
                    int i = Convert.ToInt32(_value);
                    if (i == 101)
                    {
                        return "00000";
                    }
                    else
                    {
                        return Convert.ToString(i);
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
            int q = 0;
            int w = 0;
            int t;
            try
            {
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
            }
            catch
            {

            }
            if (q == 101 || w == 101)
            {
                t = q * w;
            }
            else
            {
                t = 101;
            }
            return t;
        }
    }
}
