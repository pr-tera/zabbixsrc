using System;
using System.Diagnostics;
using System.Management;

namespace zabbixscr.Args
{
    class FreeSpaceLD
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
                        object _valuewmi = WMIQuery();
                        if (_valuewmi.GetType() == typeof(int))
                        {
                            int q = Convert.ToInt32(_valuewmi);
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
                        return Convert.ToString(Math.Round(i / 1024, 0));
                    }
                }
                else
                {
                    object _valuewmi = WMIQuery();
                    if (_valuewmi.GetType() == typeof(int))
                    {
                        int q = Convert.ToInt32(_valuewmi);
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
            if (string.IsNullOrEmpty(Program.argT))
            {
                try
                {
                    PerformanceCounter _ioCounter = new PerformanceCounter();
                    _ioCounter.CategoryName = "LogicalDisk";
                    _ioCounter.CounterName = "Free Megabytes";
                    _ioCounter.InstanceName = Program.argT;
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
        private static object WMIQuery()
        {
            double t = 0;
            try
            {
                if (!string.IsNullOrEmpty(Program.argT))
                {
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["Name"]) == Program.argT)
                            {
                                t = Math.Round((double)Convert.ToInt64(y["FreeSpace"]) / 1024 / 1024 / 1024, 0);
                            }
                        }
                        catch
                        {
                            t = 101;
                            break;
                        }
                    }
                    i.Dispose();
                }
                else
                {
                    t = 101;
                }
            }
            catch
            {
                t = 101;
            }
            return t;
        }
    }
}
