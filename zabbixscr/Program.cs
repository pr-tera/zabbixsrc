using System;
using System.Threading;
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
                    Thread Task = new Thread(UserPersonalFolder);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "UserPersonalFolberSize" && args[1] != null)
                {
                    Thread Task = new Thread(() => UserPersonalFolberSize(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                /*
                 * 
                 * Инвенторизация
                 * 
                 */
                if (args.Length == 1 && args[0] == "Mac")
                {
                    Thread Task = new Thread(Mac);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "BoardMaker")
                {
                    Thread Task = new Thread(BoardMaker);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "SerialNumber")
                {
                    Thread Task = new Thread(SerialNumber);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "PCName")
                {
                    Thread Task = new Thread(PCName);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "OSVersion")
                {
                    Thread Task = new Thread(OSVersion);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "MemoryInfo")
                {
                    Thread Task = new Thread(MemoryInfo);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "CPUInfo")
                {
                    Thread Task = new Thread(CPUInfo);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "PhysicalDisk")
                {
                    Thread Task = new Thread(PhysicalDisk);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "SMART")
                {
                    Thread Task = new Thread(SMART);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "PhysicalDiskSize" && args[1] != null)
                {
                    Thread Task = new Thread(() => PhysicalDiskSize(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "SerialNumberD" && args[1] != null)
                {
                    Thread Task = new Thread(() => SerialNumberD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "LogicalDisk")
                {
                    Thread Task = new Thread(LogicalDisk);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args[0] == "SectionNameD" && args[1] != null)
                {
                    Thread Task = new Thread(() => SectionNameD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "SerialNumberLD" && args[1] != null)
                {
                    Thread Task = new Thread(() => SerialNumberLD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "CompressedLD" && args[1] != null)
                {
                    Thread Task = new Thread(() => CompressedLD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "FileSystemLD" && args[1] != null)
                {
                    Thread Task = new Thread(() => FileSystemLD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "SizeLD" && args[1] != null)
                {
                    Thread Task = new Thread(() => SizeLD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "FreeSpaceLD" && args[1] != null)
                {
                    Thread Task = new Thread(() => FreeSpaceLD(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "PercentageFreeSpace" && args[1] != null)
                {
                    Thread Task = new Thread(() => PercentageFreeSpace(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "ChekDirtyTom" && args[1] != null)
                {
                    Thread Task = new Thread(() => ChekDirtyTom(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "AvgDiskReadQueueLength" && args[1] != null)
                {
                    Thread Task = new Thread(() => AvgDiskReadQueueLength(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "AvgDiskWriteQueueLength" && args[1] != null)
                {
                    Thread Task = new Thread(() => AvgDiskWriteQueueLength(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "SplitIOPerSec" && args[1] != null)
                {
                    Thread Task = new Thread(() => SplitIOPerSec(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "AvailableMBytesM")
                {
                    Thread Task = new Thread(AvailableMBytesM);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "CacheBytesM")
                {
                    Thread Task = new Thread(CacheBytesM);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "TotalPhysicalMemory")
                {
                    Thread Task = new Thread(TotalPhysicalMemory);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "PageSecInDSwap")
                {
                    Thread Task = new Thread(PageSecInDSwap);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "ProcessorDetected")
                {
                    Thread Task = new Thread(ProcessorDetected);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args[0] == "LoadPercentageP" && args[1] != null)
                {
                    Thread Task = new Thread(() => LoadPercentageP(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "CurrentClockSpeedP" && args[1] != null)
                {
                    Thread Task = new Thread(() => CurrentClockSpeedP(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "VirtualizationFirmwareEnabled" && args[1] != null)
                {
                    Thread Task = new Thread(() => VirtualizationFirmwareEnabled(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args[0] == "SerialNumberP" && args[1] != null)
                {
                    Thread Task = new Thread(() => SerialNumberP(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "TimeZone")
                {
                    Thread Task = new Thread(TimeZone);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "AutomaticManagedPagefile")
                {
                    Thread Task = new Thread(AutomaticManagedPagefile);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "DNSHostName")
                {
                    Thread Task = new Thread(DNSHostName);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "Domain")
                {
                    Thread Task = new Thread(Domain);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "DomainRole")
                {
                    Thread Task = new Thread(DomainRole);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "GetSensorProcessor")
                {
                    Thread Task = new Thread(GetSensorProcessor);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args[0] == "GetCPUSensorValue" && args[1] != null)
                {
                    Thread Task = new Thread(() => GetCPUSensorValue(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "GetDiskSensorName")
                {
                    Thread Task = new Thread(GetDiskSensorName);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args[0] == "GetDiskSensorValue" && args[1] != null)
                {
                    Thread Task = new Thread(() => GetDiskSensorValue(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "GetServices")
                {
                    Thread Task = new Thread(GetServices);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        string i = string.Join(",", Data.LisrDat.TempL);
                        Console.WriteLine($"{{\"data\":[{i}]}}");
                        Task.Abort();
                    }
                }
                if (args[0] == "StatusService" && args[1] != null)
                {
                    Thread Task = new Thread(() => StatusService(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(25)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
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
            if (args[0] == "StartService" && args[1] != null)
            {
                Util.Services.StartService(args[1]);
            }
            if (args.Length == 1 && args[0] == "UpdateTC1C")
            {
                Util.UPTC1C.UpdateTC1C();
            }
        }
        private static void UserPersonalFolder()
        {
            Catalogs catalogs = new Catalogs();
            catalogs.GetUserFolber();
            string u = string.Join(",", Data.LisrDat.TempL);
            Console.WriteLine($"{{\"data\":[{u}]}}");
        }
        private static void GetServices()
        {
            Console.WriteLine($"{{\"data\":[{Util.Services.GetServiceName(ref Data.Temp.TempS)}]}}");
        }
        private static void StatusService(string args)
        {
            Console.WriteLine(Util.Services.StatusService(args, ref Data.Temp.TempS));
        }
        private static void GetDiskSensorValue(string args)
        {
            Console.WriteLine(Temperature.GetDiskSensorValue(args, ref Data.Temp.TempS));
        }
        private static void GetDiskSensorName()
        {
            Console.WriteLine($"{{\"data\":[{Temperature.GetDiskSensorName(ref Data.Temp.TempS)}]}}");
        }
        private static void GetCPUSensorValue(string args)
        {
            Console.WriteLine(Temperature.GetCPUSensorValue(args, ref Data.Temp.TempS));
        }
        private static void GetSensorProcessor()
        {
            Console.WriteLine($"{{\"data\":[{Temperature.GetCPUSensorName(ref Data.Temp.TempS)}]}}");
        }
        private static void DomainRole()
        {
            Console.WriteLine(WMI.DomainRole(ref Data.Temp.TempS).ToString());
        }
        private static void Domain()
        {
            Console.WriteLine(WMI.Domain(ref Data.Temp.TempS).ToString());
        }
        private static void DNSHostName()
        {
            Console.WriteLine(WMI.DNSHostName(ref Data.Temp.TempS).ToString());
        }
        private static void AutomaticManagedPagefile()
        {
            Console.WriteLine(WMI.AutomaticManagedPagefile(ref Data.Temp.TempS).ToString());
        }
        private static void TimeZone()
        {
            Console.WriteLine(WMI.TimeZone(ref Data.Temp.TempS).ToString());
        }
        private static void SerialNumberP(string args)
        {
            Console.WriteLine(WMI.SerialNumberP(args, ref Data.Temp.TempS).ToString());
        }
        private static void VirtualizationFirmwareEnabled(string args)
        {
            Console.WriteLine(WMI.VirtualizationFirmwareEnabled(args, ref Data.Temp.TempS).ToString());
        }
        private static void CurrentClockSpeedP(string args)
        {
            Console.WriteLine(WMI.CurrentClockSpeedP(args, ref Data.Temp.TempI).ToString());
        }
        private static void LoadPercentageP(string args)
        {
            Console.WriteLine(WMI.LoadPercentageP(args, ref Data.Temp.TempI).ToString());
        }
        private static void ProcessorDetected()
        {
            Console.WriteLine($"{{\"data\":[{WMI.ProcessorDetected(ref Data.Temp.TempS)}]}}");
        }
        private static void PageSecInDSwap()
        {
            Console.WriteLine(WMI.PageSecInDSwap(ref Data.Temp.TempD).ToString());
        }
        private static void TotalPhysicalMemory()
        {
            Console.WriteLine(WMI.TotalPhysicalMemory(ref Data.Temp.TempD).ToString());
        }
        private static void CacheBytesM()
        {
            Console.WriteLine(WMI.CacheBytesM(ref Data.Temp.TempD).ToString());
        }
        private static void AvailableMBytesM()
        {
            Console.WriteLine(WMI.AvailableMBytesM(ref Data.Temp.TempD).ToString());
        }
        private static void SplitIOPerSec(string args)
        {
            Console.WriteLine(WMI.SplitIOPerSec(args, ref Data.Temp.TempI).ToString());
        }
        private static void AvgDiskWriteQueueLength(string args)
        {
            Console.WriteLine(WMI.AvgDiskWriteQueueLength(args, ref Data.Temp.TempI).ToString());
        }
        private static void AvgDiskReadQueueLength(string args)
        {
            Console.WriteLine(WMI.AvgDiskReadQueueLength(args, ref Data.Temp.TempI).ToString());
        }
        private static void ChekDirtyTom(string args)
        {
            Console.WriteLine(WMI.ChekDirtyTom(args, ref Data.Temp.TempS));
        }
        private static void PercentageFreeSpace(string args)
        {
            Console.WriteLine(WMI.PercentageFreeSpace(args, ref Data.Temp.TempD));
        }
        private static void FreeSpaceLD(string args)
        {
            Console.WriteLine(WMI.FreeSpaceLD(args, ref Data.Temp.TempD));
        }
        private static void SizeLD(string args)
        {
            Console.WriteLine(WMI.SizeLD(args, ref Data.Temp.TempD));
        }
        private static void FileSystemLD(string args)
        {
            Console.WriteLine(WMI.FileSystemLD(args, ref Data.Temp.TempS));
        }
        private static void CompressedLD(string args)
        {
            Console.WriteLine(WMI.CompressedLD(args, ref Data.Temp.TempS));
        }
        private static void SerialNumberLD(string args)
        {
            Console.WriteLine(WMI.SerialNumberLD(args, ref Data.Temp.TempS));
        }
        private static void SectionNameD(string args)
        {
            Console.WriteLine(WMI.SectionNameD(args, ref Data.Temp.TempS).ToString(System.Globalization.CultureInfo.GetCultureInfo("ru-RU")));
        }
        private static void LogicalDisk()
        {
            Console.WriteLine($"{{\"data\":[{WMI.LogicalDisk(ref Data.Temp.TempS)}]}}");
        }
        private static void SerialNumberD(string args)
        {
            Console.WriteLine(WMI.SerialNumber(args, ref Data.Temp.TempS));
        }
        private static void PhysicalDiskSize(string args)
        {
            Console.WriteLine(WMI.PhysicalDiskSize(args, ref Data.Temp.TempD));
        }
        private static void SMART()
        {
            Auxiliary SMART = new Auxiliary();
            SMART.SMART();
        }
        private static void PhysicalDisk()
        {
            Console.WriteLine($"{{\"data\":[{WMI.PhysicalDisk(ref Data.Temp.TempS)}]}}");
        }
        private static void CPUInfo()
        {
            Console.WriteLine(WMI.CPUInfo(ref Data.Temp.TempS));
        }
        private static void MemoryInfo()
        {
            Console.WriteLine(WMI.MemoryInfo(ref Data.Temp.TempS));
        }
        private static void OSVersion()
        {
            Console.WriteLine(Environment.OSVersion);
        }
        private static void PCName()
        {
            Console.WriteLine(Environment.MachineName);
        }
        private static void SerialNumber()
        {
            Console.WriteLine(WMI.SerialNumber(ref Data.Temp.TempS));
        }
        private static void BoardMaker()
        {
            Console.WriteLine(WMI.BoardMaker(ref Data.Temp.TempS));
        }
        private static void Mac()
        {
            Console.WriteLine(WMI.Mac(ref Data.Temp.TempS));
        }
        private static void UserPersonalFolberSize(string args)
        {
            Catalogs catalogs = new Catalogs();
            catalogs.GetSizeUserFolber(args, ref Data.Temp.TempD);
            Console.WriteLine(Data.Temp.TempD.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
