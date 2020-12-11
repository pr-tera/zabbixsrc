using System;
using System.Management;

namespace zabbixscr.Args
{
    class LoadPercentageP
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(int))
                {
                    int i = Convert.ToInt32(_value);
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
            int t = 0;
            try
            {
                if (!string.IsNullOrEmpty(Program.argT))
                {
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["DeviceID"]).Contains(Program.argT))
                            {
                                t = Convert.ToInt32(y["LoadPercentage"]);
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
