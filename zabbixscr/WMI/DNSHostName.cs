using System;
using System.Management;

namespace zabbixscr.WMI
{
    class DNSHostName
    {
        internal static string Name
        {
            get
            {
                return _name();
            }
            private set
            {
                _name();
            }
        }
        private static string _name()
        {
            string t = string.Empty;
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
            return t;
        }
    }
}
