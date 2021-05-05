using System;
using System.Diagnostics;
using System.Management;

namespace zabbixscr.Args
{
    class AvgDiskReadQueueLength
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
                        return Convert.ToString(i);
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
            if (!string.IsNullOrEmpty(Program.argT))
            {
                try
                {
                    PerformanceCounter _ioCounter = new PerformanceCounter();
                    _ioCounter.CategoryName = "LogicalDisk";
                    _ioCounter.CounterName = "Avg. Disk Read Queue Length";
                    _ioCounter.InstanceName = Program.argT;
                    t = _ioCounter.NextValue();
                    System.Threading.Thread.Sleep(1000);
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
            int t = 0;
            try
            {
                if (!string.IsNullOrEmpty(Program.argT))
                {
                    ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_PhysicalDisk");
                    foreach (ManagementObject y in i.Get())
                    {
                        try
                        {
                            if (Convert.ToString(y["Name"]).Contains(Program.argT))
                            {
                                t = Convert.ToInt32(y["AvgDiskReadQueueLength"]);
                                break;
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