using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class CompressedLD
    {
        internal static string Value
        {
            get
            {
                return _value();
            }
            set
            {
                _value();
            }
        }
        private static  string _value()
        {
            string t = string.Empty;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Name"]) == Data.argT)
                    {
                        t = Convert.ToString(y["Compressed"]);
                    }
                }
                catch
                {
                    t = "Не определено";
                    break;
                }
            }
            i.Dispose();
            return t;
        }
    }
}
