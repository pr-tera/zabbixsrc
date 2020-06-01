using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class VirtualizationFirmwareEnabled
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["DeviceID"]).Contains(Data.argT))
                    {
                        t = Convert.ToString(y["VirtualizationFirmwareEnabled"]);
                    }
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
