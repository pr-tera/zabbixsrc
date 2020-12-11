using System;
using System.Management;

namespace zabbixscr.Standart
{
    class AutomaticManagedPagefile
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (i.Contains("True") || i.Contains("False"))
                    {
                        return i;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error";
                }
            }
        }
        private static object WMIQuery()
        {
            string t = string.Empty;
            try
            {
                ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        t = Convert.ToString(y["AutomaticManagedPagefile"]);
                    }
                    catch
                    {
                        t = "101";
                        break;
                    }
                }
                i.Dispose();
            }
            catch
            {
                t = "101";
            }
            return t;
        }
    }
}
