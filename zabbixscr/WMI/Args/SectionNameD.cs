using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class SectionNameD
    {
        internal static string Name
        {
            get
            {
                return _name().ToString(System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
            }
            set
            {
                _name();
            }
        }
        private static string _name()
        {
            string t = string.Empty;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Name"]) == Data.argT)
                    {
                        t = Convert.ToString(y["VolumeName"]);
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
