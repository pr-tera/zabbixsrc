using System;
using System.Diagnostics;

namespace zabbixscr.PerfCounter.Args
{
    class SplitIOSec
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
            PerformanceCounter _ioCounter = new PerformanceCounter();
            _ioCounter.CategoryName = "LogicalDisk";
            _ioCounter.CounterName = "Split IO/sec";
            _ioCounter.InstanceName = Data.argT;
            float t = _ioCounter.NextValue();
            _ioCounter.Dispose();
            return Convert.ToString(t);
        }
    }
}