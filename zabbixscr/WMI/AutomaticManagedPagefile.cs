using System;
using System.Management;

namespace zabbixscr.WMI
{
    class AutomaticManagedPagefile
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
            string t = string.Empty;
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
            return t;
        }
    }
}
