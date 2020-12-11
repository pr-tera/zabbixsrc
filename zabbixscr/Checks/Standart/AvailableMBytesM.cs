using System;
using System.Diagnostics;

namespace zabbixscr.Standart
{
    class AvailableMBytesM
    {
        internal static string Value
        {
            get
            {
                object _value = PerfCounter();
                if (_value.GetType() == typeof(float))
                {
                    int i = Convert.ToInt32(_value);
                    if (i == 101)
                    {
                        return "00000";
                    }
                    else
                    {
                        return Convert.ToString(i);
                    }
                }
                else
                {
                    return "00000";
                }
            }
        }
        private static object PerfCounter()
        {
            float t;
            try
            {
                PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                t = _ramCounter.NextValue();
                _ramCounter.Dispose();
            }
            catch
            {
                t = 101;   
            }
            return t;
        }
    }
}
