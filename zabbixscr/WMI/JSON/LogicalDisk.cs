using System;
using System.Management;

namespace zabbixscr.WMI.JSON
{
    class LogicalDisk
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    Data.Temp.Add($"{{\"{{#LOGICALDISK}}\":\"{Convert.ToString(y["Name"])}\"}}");
                }
                catch
                {
                    t = "Не определено";
                    break;
                }
            }
            i.Dispose();
            t = string.Join(",", Data.Temp);
            return t;
        }
    }
}
