using System;
using System.Diagnostics;

namespace zabbixscr.PerfCounter.Args
{
    class AvgDiskWriteQueueLength
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
            _ioCounter.CounterName = "Avg. Disk Write Queue Length";
            _ioCounter.InstanceName = Data.argT;
            float t = _ioCounter.NextValue();
            _ioCounter.Dispose();
            return Convert.ToString(t);
        }
    }
}
