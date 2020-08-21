using System.Net.NetworkInformation;

namespace zabbixscr.Othe
{
    class Mac
    {
        internal static string Addr
        {
            get
            {
                return _addr();
            }
            private set
            {
                _addr();
            }
        }
        private static string _addr()
        {
            string t = string.Empty;
            foreach (NetworkInterface i in NetworkInterface.GetAllNetworkInterfaces())
            {
                try
                {
                    if (i.OperationalStatus == OperationalStatus.Up)
                    {
                        t = i.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                catch
                {
                    t = "101";
                    break;
                }
            }
            if (string.IsNullOrEmpty(t))
            {
                t = "101";
            }
            return t;
        }
    }
}
