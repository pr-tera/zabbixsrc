using System;
using System.Management;

namespace zabbixscr.Args
{
    class FileSystemLD
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (string.IsNullOrEmpty(i))
                    {
                        return "Error";
                    }
                    else
                    {
                        return i;
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
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["Name"]) == Program.argT)
                            {
                                t = Convert.ToString(y["FileSystem"]);
                            }
                        }
                        catch
                        {
                            t = "Не определено";
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
