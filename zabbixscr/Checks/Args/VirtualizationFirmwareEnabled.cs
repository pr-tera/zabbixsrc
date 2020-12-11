using System;
using System.Management;

namespace zabbixscr.Args
{
    class VirtualizationFirmwareEnabled
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (i.Contains("True") || i.Contains("False"))
                    {
                        return i;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error";
                }
            }
        }
        private static object WMIQuery()
        {
            string t = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(Program.argT))
                {
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["DeviceID"]).Contains(Program.argT))
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
                }
                else
                {
                    t = "101";
                }
            }
            catch
            {
                t = "101";
            }
            return t;
        }
    }
}
