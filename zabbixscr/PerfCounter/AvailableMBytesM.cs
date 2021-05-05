using System;
using System.Diagnostics;

namespace zabbixscr.PerfCounter
{
    class AvailableMBytesM
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
            PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            float t = _ramCounter.NextValue();
            _ramCounter.Dispose();
            return Convert.ToString(t);
        }
    }
}
