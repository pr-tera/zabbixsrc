using System;
using System.Text;

namespace zabbixscr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                if (args.Length == 1 && args[0] == "UserPersonalFolder")
                {
                    Catalogs catalogs = new Catalogs();
                    catalogs.GetUserFolber();
                    string u = string.Join(",", Data.LisrDat.TempL);
                    Console.WriteLine($"{{\"data\":[{u}]}}");

                }
                if (args[0] == "UserPersonalFolberSize" && args[1] != null)
                {
                    Catalogs catalogs = new Catalogs();
                    catalogs.GetSizeUserFolber(args[1], ref Data.Temp.TempD);
                    Console.WriteLine(Data.Temp.TempD.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
                }
                /*
                 * 
                 * Инвенторизация
                 * 
                 */
                if (args.Length == 1 && args[0] == "Mac")
                {
                    Console.WriteLine(WMI.Mac(ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "BoardMaker")
                {
                    Console.WriteLine(WMI.BoardMaker(ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "SerialNumber")
                {
                    Console.WriteLine(WMI.SerialNumber(ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "PCName")
                {
                    Console.WriteLine(Environment.MachineName);
                }
                if (args.Length == 1 && args[0] == "OSVersion")
                {
                    Console.WriteLine(Environment.OSVersion);
                }
                if (args.Length == 1 && args[0] == "MemoryInfo")
                {
                    Console.WriteLine(WMI.MemoryInfo(ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "CPUInfo")
                {
                    Console.WriteLine(WMI.CPUInfo(ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "PhysicalDisk")
                {
                    Console.WriteLine($"{{\"data\":[{WMI.PhysicalDisk(ref Data.Temp.TempS)}]}}");
                }
                /*
                 * 
                 * Инфа о hdd
                 * 
                 */
                if (args.Length == 1 && args[0] == "SMART")
                {
                    Auxiliary SMART = new Auxiliary();
                    SMART.SMART();
                }
                if (args[0] == "PhysicalDiskSize" && args[1] != null)
                {
                    Console.WriteLine(WMI.PhysicalDiskSize(args[1], ref Data.Temp.TempD));
                }
                if (args[0] == "SerialNumberD" && args[1] != null)
                {
                    Console.WriteLine(WMI.SerialNumber(args[1], ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "LogicalDisk")
                {
                    Console.WriteLine($"{{\"data\":[{WMI.LogicalDisk(ref Data.Temp.TempS)}]}}");
                }
                if (args[0] == "SectionNameD" && args[1] != null)
                {
                    Console.WriteLine(WMI.SectionNameD(args[1], ref Data.Temp.TempS).ToString(System.Globalization.CultureInfo.GetCultureInfo("ru-RU")));
                }
                if (args[0] == "SerialNumberLD" && args[1] != null)
                {
                    Console.WriteLine(WMI.SerialNumberLD(args[1], ref Data.Temp.TempS));
                }
                if (args[0] == "CompressedLD" && args[1] != null)
                {
                    Console.WriteLine(WMI.CompressedLD(args[1], ref Data.Temp.TempS));
                }
                if (args[0] == "FileSystemLD" && args[1] != null)
                {
                    Console.WriteLine(WMI.FileSystemLD(args[1], ref Data.Temp.TempS));
                }
                if (args[0] == "SizeLD" && args[1] != null)
                {
                    Console.WriteLine(WMI.SizeLD(args[1], ref Data.Temp.TempD));
                }
                if (args[0] == "FreeSpaceLD" && args[1] != null)
                {
                    Console.WriteLine(WMI.FreeSpaceLD(args[1], ref Data.Temp.TempD));
                }
                if (args[0] == "PercentageFreeSpace" && args[1] != null)
                {
                    Console.WriteLine(WMI.PercentageFreeSpace(args[1], ref Data.Temp.TempD));
                }
                if (args[0] == "ChekDirtyTom" && args[1] != null)
                {
                    Console.WriteLine(WMI.ChekDirtyTom(args[1], ref Data.Temp.TempS));
                }
                if (args[0] == "AvgDiskReadQueueLength" && args[1] != null)
                {
                    Console.WriteLine(WMI.AvgDiskReadQueueLength(args[1], ref Data.Temp.TempI).ToString());
                }
                if (args[0] == "AvgDiskWriteQueueLength" && args[1] != null)
                {
                    Console.WriteLine(WMI.AvgDiskWriteQueueLength(args[1], ref Data.Temp.TempI).ToString());
                }
                if (args[0] == "SplitIOPerSec" && args[1] != null)
                {
                    Console.WriteLine(WMI.SplitIOPerSec(args[1], ref Data.Temp.TempI).ToString());
                }
                if (args.Length == 1 && args[0] == "AvailableMBytesM")
                {
                    Console.WriteLine(WMI.AvailableMBytesM(ref Data.Temp.TempD).ToString());
                }
                if (args.Length == 1 && args[0] == "CacheBytesM")
                {
                    Console.WriteLine(WMI.CacheBytesM(ref Data.Temp.TempD).ToString());
                }
                if (args.Length == 1 && args[0] == "TotalPhysicalMemory")
                {
                    Console.WriteLine(WMI.TotalPhysicalMemory(ref Data.Temp.TempD).ToString());
                }
                if (args.Length == 1 && args[0] == "PageSecInDSwap")
                {
                    Console.WriteLine(WMI.PageSecInDSwap(ref Data.Temp.TempD).ToString());
                }
                //if (args.Length == 1 && args[0] == "SerialNumberMemory")
                //{
                //    Console.WriteLine(WMI.SerialNumberMemory(ref Data.Temp.SerialNumberMemory).ToString());
                //}
                //if (args.Length == 1 && args[0] == "SpeedM")
                //{
                //    Console.WriteLine(WMI.SpeedM(ref Data.Temp.SpeedM).ToString());
                //}
                if (args.Length == 1 && args[0] == "ProcessorDetected")
                {
                    Console.WriteLine($"{{\"data\":[{WMI.ProcessorDetected(ref Data.Temp.TempS)}]}}");
                }
                if (args[0] == "LoadPercentageP" && args[1] != null)
                {
                    Console.WriteLine(WMI.LoadPercentageP(args[1], ref Data.Temp.TempI).ToString());
                }
                //if (args[0] == "ModelP" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.ModelP(args[1], ref Data.Temp.ModelP).ToString());
                //}
                if (args[0] == "CurrentClockSpeedP" && args[1] != null)
                {
                    Console.WriteLine(WMI.CurrentClockSpeedP(args[1], ref Data.Temp.TempI).ToString());
                }
                //if (args[0] == "MaxClockSpeeP" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.MaxClockSpeeP(args[1], ref Data.Temp.MaxClockSpeeP).ToString());
                //}
                //if (args[0] == "NumberOfCoresP" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.NumberOfCoresP(args[1], ref Data.Temp.NumberOfCoresP).ToString());
                //}
                //if (args[0] == "NumberOfLogicalProcessors" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.NumberOfLogicalProcessors(args[1], ref Data.Temp.NumberOfLogicalProcessors).ToString());
                //}
                if (args[0] == "VirtualizationFirmwareEnabled" && args[1] != null)
                {
                    Console.WriteLine(WMI.VirtualizationFirmwareEnabled(args[1], ref Data.Temp.TempS).ToString());
                }
                //if (args[0] == "VMMonitorModeExtensions" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.VMMonitorModeExtensions(args[1], ref Data.Temp.VMMonitorModeExtensions).ToString());
                //}
                //if (args[0] == "SocketDesignation" && args[1] != null)
                //{
                //    Console.WriteLine(WMI.SocketDesignation(args[1], ref Data.Temp.SocketDesignation).ToString());
                //}
                if (args[0] == "SerialNumberP" && args[1] != null)
                {
                    Console.WriteLine(WMI.SerialNumberP(args[1], ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "TimeZone")
                {
                    Console.WriteLine(WMI.TimeZone(ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "AutomaticManagedPagefile")
                {
                    Console.WriteLine(WMI.AutomaticManagedPagefile(ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "DNSHostName")
                {
                    Console.WriteLine(WMI.DNSHostName(ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "Domain")
                {
                    Console.WriteLine(WMI.Domain(ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "DomainRole")
                {
                    Console.WriteLine(WMI.DomainRole(ref Data.Temp.TempS).ToString());
                }
                if (args.Length == 1 && args[0] == "GetSensorProcessor")
                {
                    Console.WriteLine($"{{\"data\":[{Temperature.GetCPUSensorName(ref Data.Temp.TempS)}]}}");
                }
                if (args[0] == "GetCPUSensorValue" && args[1] != null)
                {
                    Console.WriteLine(Temperature.GetCPUSensorValue(args[1], ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "GetDiskSensorName")
                {
                    Console.WriteLine($"{{\"data\":[{Temperature.GetDiskSensorName(ref Data.Temp.TempS)}]}}");
                }
                if (args[0] == "GetDiskSensorValue" && args[1] != null)
                {
                    Console.WriteLine(Temperature.GetDiskSensorValue(args[1], ref Data.Temp.TempS));
                }
                if (args.Length == 1 && args[0] == "UpdateTC1C")
                {
                    Util.UPTC1C.UpdateTC1C();
                }
            }
            catch
            {
                Console.WriteLine("101");
            }
            if (args.Length == 1 && args[0] == "GetTJ1C")
            {
                TJ.OpenTJ.FindTJ();
                Console.WriteLine(TJ.OpenTJ.TJ(ref TJ.DataTJ.Error));
            }
            if (args.Length == 1 && args[0] == "GetServices")
            {
                Console.WriteLine($"{{\"data\":[{Util.Services.GetServiceName(ref Data.Temp.TempS)}]}}");
 
            }
            if (args[0] == "StatusService" && args[1] != null)
            {
                Console.WriteLine(Util.Services.StatusService(args[1], ref Data.Temp.TempS));
            }
            if (args[0] == "StartService" && args[1] != null)
            {
               Util.Services.StartService(args[1]);
            }
        }
    }
}
