using System;
using System.ServiceProcess;

namespace zabbixscr.Services.Args
{
    class StatusService
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
            Data.argT = Data.argT.Replace("RTIJ7ANL", "(").Replace("RTIJ7ANR", ")").Replace("EROF8IJS", "$");
            try
            {
                foreach (var i in ServiceController.GetServices())
                {
                    if (i.ServiceName == Data.argT)
                    {
                        t = Convert.ToString(i.Status);
                    }
                }
            }
            catch (Exception e)
            {
                t = Convert.ToString(e);
            }
            return t;
        }
    }
}
