using System;
using System.Management;

namespace zabbixscr.Args
{
    class SizeLD
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
                if (!string.IsNullOrEmpty(Program.argT))
                {
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["Name"]) == Program.argT)
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
                }
                else
                {
                    t = 101;
                }
            }
            catch
            {
                t = 101;
            }
            return t;
        }
    }
}
