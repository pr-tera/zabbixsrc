using System;
using System.Management;

namespace zabbixscr.WMI.JSON
{
    class ProcessorDetected
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    Data.Temp.Add($"{{\"{{#PROCESSORKMODEL}}\":\"{Convert.ToString(y["DeviceID"])}\"}}");
                }
                catch
                {
                    t = "101";
                    break;
                }
            }
            i.Dispose();
            t = string.Join(",", Data.Temp);
            return Convert.ToString(t);
        }
    }
}
