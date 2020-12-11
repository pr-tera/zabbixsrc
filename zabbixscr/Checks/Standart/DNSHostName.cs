using System;
using System.Management;

namespace zabbixscr.Standart
{
    class DNSHostName
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (string.IsNullOrEmpty(i) || i.Contains("101"))
                    {
                        return "Error";
                    }
                    else
                    {
                        return i;
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
                        t = Convert.ToString(y["DNSHostName"]);
                        break;
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
