using System;
using System.ServiceProcess;

namespace zabbixscr.Services.JSON
{
    class GetServiceName
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
            try
            {
                foreach (var i in ServiceController.GetServices())
                {
                    if (i.StartType == ServiceStartMode.Automatic)
                    {
                        Data.Temp.Add(Convert.ToString($"{{\"{{#SERVICESNAME}}\":\"{Convert.ToString(i.ServiceName).Replace("(", "RTIJ7ANL").Replace(")", "RTIJ7ANR").Replace("$", "EROF8IJS")}\"}}"));
                    }
                }
                t = string.Join(",", Data.Temp);
            }
            catch (Exception e)
            {
                t = Convert.ToString(e);
            }
            return t;
        }
    }
}
