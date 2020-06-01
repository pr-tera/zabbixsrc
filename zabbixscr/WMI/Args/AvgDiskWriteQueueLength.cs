using System;
using System.Management;

namespace zabbixscr.WMI.Args
{
    class AvgDiskWriteQueueLength
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
        private static string _value()
        {
            int t = 0;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_PhysicalDisk");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    if (Convert.ToString(y["Name"]).Contains(Data.argT))
                    {
                        t = Convert.ToInt32(y["AvgDiskReadQueueLength"]);
                        break;
                    }
                }
                catch
                {
                    t = 101;
                    break;
                }
            }
            i.Dispose();
            return Convert.ToString(t);
        }
    }
}
