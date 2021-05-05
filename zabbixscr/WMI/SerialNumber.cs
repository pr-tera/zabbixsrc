using System.Management;

namespace zabbixscr.WMI
{
    class SerialNumber
    {
        internal static string Info
        {
            get
            {
                return _info();
            }
            private set
            {
                _info();
            }
        }
        private static string _info()
        {
            string t = string.Empty;
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    t = y.GetPropertyValue("SerialNumber").ToString();
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
