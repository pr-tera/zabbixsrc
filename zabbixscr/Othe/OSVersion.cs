using Microsoft.Win32;
using System;

namespace zabbixscr.Othe
{
    class OSVersion
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
            string version = $"{Environment.OSVersion.Version.Major}.{Environment.OSVersion.Version.Minor}";
            switch (version)
            {
                case "10,0": 
                    version = $"Windows 10 {version}";
                    break;
                case "6.3": 
                    version = $"Windows 8.1 {version}";
                    break;
                case "6.2":
                    version = $"Windows 8 {version}";
                    break;
                case "6.1":
                    version = $"Windows 7 {version}";
                    break;
                case "6.0":
                    version = $"Windows Vista {version}";
                    break;
                case "5.2":
                    version = $"Windows XP {version}";
                    break;
            }
            return version;
        }
    }
}
