using System;
using System.Diagnostics;

namespace zabbixscr.Args
{
    class PercentageFreeSpace
    {
        internal static string Value
        {
            get
            {
                object _value = PerfCounter();
                if (_value.GetType() == typeof(float))
                {
                    double i = Convert.ToDouble(_value);
                    if (i == 101)
                    {
                        object _valuewmi = _size();
                        if (_valuewmi.GetType() == typeof(double))
                        {
                            double q = Convert.ToDouble(_valuewmi);
                            if (q == 101)
                            {
                                return "00000";
                            }
                            else
                            {
                                return Convert.ToString(q);
                            }
                        }
                        else
                        {
                            return "00000";
                        }
                    }
                    else
                    {
                        return Convert.ToString(Math.Round(i, 0));
                    }
                }
                else
                {
                    object _valuewmi = _size();
                    if (_valuewmi.GetType() == typeof(double))
                    {
                        double q = Convert.ToDouble(_valuewmi);
                        if (q == 101)
                        {
                            return "00000";
                        }
                        else
                        {
                            return Convert.ToString(q);
                        }
                    }
                    else
                    {
                        return "00000";
                    }
                }
            }
        }
        private static object PerfCounter()
        {
            float t;
            if (!string.IsNullOrEmpty(Program.argT))
            {
                try
                {
                    PerformanceCounter _ioCounter = new PerformanceCounter
                    {
                        CategoryName = "LogicalDisk",
                        CounterName = "% Free Space",
                        InstanceName = Program.argT
                    };
                    t = _ioCounter.NextValue();
                    _ioCounter.Dispose();
                }
                catch
                {
                    t = 101;
                }
            }
            else
            {
                t = 101;
            }
            return t;
        }
        private static object _size()
        {
            double t;
            try
            {
                t = Math.Round(Convert.ToDouble(FreeSpaceLD.Value) / Convert.ToDouble(SizeLD.Value) * 100);
            }
            catch
            {
                t = 101;
            }
            return Convert.ToString(t);
        }
    }
}
