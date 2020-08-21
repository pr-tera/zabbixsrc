using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class SerialNumberD
    {
        internal static string Serial
        {
            get
            {
                return _serial();
            }
            private set
            {
                _serial();
            }
        }
        private static string _serial()
        {
            string t = string.Empty;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Model"]) == Data.argT)
                    {
                        t = Convert.ToString(y["SerialNumber"]);
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
