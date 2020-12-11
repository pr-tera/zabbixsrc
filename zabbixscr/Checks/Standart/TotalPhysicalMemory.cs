using System;
using System.Management;

namespace zabbixscr.Standart
{
    class TotalPhysicalMemory
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(double))
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
            double t = 0;
            try
            {
                ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        t += Convert.ToInt64(y["Capacity"]);
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
            
            }
            if (t != 0)
            {
                t = Math.Round((double)t / 1e+9, 0);
            }
            else
            {
                t = 101;
            }
            return t;
        }
    }
}
