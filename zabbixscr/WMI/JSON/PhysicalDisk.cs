using System;
using System.Management;

namespace zabbixscr.WMI.JSON
{
    class PhysicalDisk
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    Data.Temp.Add($"{{\"{{#PHYSUCALDISKMODEL}}\":\"{Convert.ToString(y["Model"])}\"}}");
                }
                catch
                {
                    t = "101";
                    break;
                }
            }
            i.Dispose();
            t = string.Join(",", Data.Temp);
            return t;
        }
    }
}
