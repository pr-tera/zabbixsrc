using System;
using System.Management;

namespace zabbixscr.Standart
{
    class DomainRole
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (string.IsNullOrEmpty(i) || i.Contains("101"))
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
                ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        t = Convert.ToString(y["DomainRole"]);
                        break;
                    }
                    catch
                    {
                        t = "101";
                        break;
                    }
                }
                i.Dispose();
                if (!t.Contains("101"))
                {
                    switch (t)
                    {
                        case "0":
                            t = "Автономная рабочая станция";
                            break;
                        case "1":
                            t = "Рабочая станция участника";
                            break;
                        case "2":
                            t = "Автономный сервер";
                            break;
                        case "3":
                            t = "Рядовой сервер";
                            break;
                        case "4":
                            t = "Резервный контроллер домена";
                            break;
                        case "5":
                            t = "Основной контроллер домена";
                            break;
                    }
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
