using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace zabbixscr.WMI
{
    class TotalPhysicalMemory
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
            double t = 0;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    t += Convert.ToInt64(y["Capacity"]);
                }
                catch
                {
                    t = 101;
                    break;
                }
            }
            i.Dispose();
            t = Math.Round((double)t / 1e+9, 0);
            return Convert.ToString(t);
        }
    }
}
