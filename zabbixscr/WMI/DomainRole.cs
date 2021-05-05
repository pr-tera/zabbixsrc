using System;
using System.Management;

namespace zabbixscr.WMI
{
    class DomainRole
    {
        internal static string Role
        {
            get
            {
                return _role();
            }
            private set
            {
                _role();
            }
        }
        private static string _role()
        {
            string t = string.Empty;
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
            return t;
        }
    }
}
