using System;
using System.Text;
using System.Threading;

namespace zabbixscr
{
    class Program
    {
        internal static string argT = string.Empty;
        static void Main(string[] args)
        {
            int timeout = 18;
            Console.OutputEncoding = Encoding.UTF8;
            if (args[0] == "test")
            {
                Console.WriteLine(Othe.NetHasp.GetHaspLM());
            }
            try
            {
                if (args.Length == 1 && args[0] == "UserPersonalFolder")
                {
                    UserPersonalFolder();
                    //Thread Task = new Thread(UserPersonalFolder);
                    //Task.Start();
                    //if (Task.Join(TimeSpan.FromSeconds(25)))
                    //{

                    //}
                    //else
                    //{
                    //    Console.WriteLine(101);
                    //    Task.Abort();
                    //}
                }
                if (args.Length == 1 && args[0] == "DellCahe")
                {
                    Util.ClearCache.DellCache();
                }
                if (args[0] == "UserPersonalFolberSize" && args[1] != null)
                {
                    Thread Task = new Thread(() => UserPersonalFolberSize(args[1]));
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
                    {

                    }
                    else
                    {
                        Console.WriteLine(101);
                        Task.Abort();
                    }
                }
                if (args.Length == 1 && args[0] == "Mac")
                {
                    Thread Task = new Thread(Mac);
                    Task.Start();
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                    if (Task.Join(TimeSpan.FromSeconds(timeout)))
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
                Console.WriteLine(101);
            }
            if (args.Length == 1 && args[0] == "GetTJ1C")
            {
                TJ.OpenTJ.FindTJ();
                TJ.OpenTJ.TJ();
                Console.WriteLine(TJ.Data.Error);
            }
            if (args[0] == "StartService" && args[1] != null)
            {
                Services.Services.StartService(args[1]);
            }
        }
        /*
         * Services
         */
        private static void GetServices()
        {
            Console.WriteLine($"{{\"data\":[{Services.JSON.GetServiceName.Value}]}}");
        }
        private static void StatusService(string args)
        {
            Services.Data.argT = args;
            Console.WriteLine(Services.Args.StatusService.Value);
        }
        /*
         * Temperature args
         */
        private static void GetDiskSensorValue(string args)
        {
            Temperature.Data.argT = args;
            Console.WriteLine(Temperature.Args.GetDiskSensorValue.Value);
        }
        private static void GetCPUSensorValue(string args)
        {
            Temperature.Data.argT = args;
            Console.WriteLine(Temperature.Args.GetCPUSensorValue.Value);
        }
        /*
         * Temperature JSON
         */
        private static void GetDiskSensorName()
        {
            Console.WriteLine($"{{\"data\":[{Temperature.JSON.GetDiskSensorName.Value}]}}");
        }
        private static void GetSensorProcessor()
        {
            Console.WriteLine($"{{\"data\":[{Temperature.JSON.GetSensorProcessor.Value}]}}");
        }
        /*
         * WMI
         */
        private static void DomainRole()
        {
            Console.WriteLine(Standart.DomainRole.Value);
        }
        private static void Domain()
        {
            Console.WriteLine(Standart.Domain.Value);
        }
        private static void DNSHostName()
        {
            Console.WriteLine(Standart.DNSHostName.Value);
        }
        private static void BoardMaker()
        {
            Console.WriteLine(Standart.BoardMaker.Value);
        }
        private static void SerialNumber()
        {
            Console.WriteLine(Standart.SerialNumber.Value);
        }
        private static void MemoryInfo()
        {
            Console.WriteLine(Standart.MemoryInfo.Value);
        }
        private static void CPUInfo()
        {
            Console.WriteLine(Standart.CPUInfo.Value);
        }
        private static void CacheBytesM()
        {
            Console.WriteLine(Standart.CacheBytesM.Value);
        }
        private static void TotalPhysicalMemory()
        {
            Console.WriteLine(Standart.TotalPhysicalMemory.Value);
        }
        private static void PageSecInDSwap()
        {
            Console.WriteLine(Standart.PageSecInDSwap.Value);
        }
        private static void ProcessorDetected()
        {
            Console.WriteLine($"{{\"data\":[{WMI.JSON.ProcessorDetected.Name}]}}");
        }
        private static void TimeZone()
        {
            Console.WriteLine(Standart.TimeZone.Value);
        }
        private static void AutomaticManagedPagefile()
        {
            Console.WriteLine(Standart.AutomaticManagedPagefile.Value);
        }
        /*
         * WMI args
         */
        private static void PhysicalDiskSize(string args)
        {
            argT = args;
            Console.WriteLine(Args.PhysicalDiskSize.Value);
        }
        private static void SerialNumberD(string args)
        {
            argT = args;
            Console.WriteLine(Args.SerialNumberD.Value);
        }
        private static void SectionNameD(string args)
        {
            argT = args;
            Console.WriteLine(Args.SectionNameD.Value);
        }
        private static void SerialNumberLD(string args)
        {
            argT = args;
            Console.WriteLine(Args.SerialNumberLD.Value);
        }
        private static void CompressedLD(string args)
        {
            argT = args;
            Console.WriteLine(Args.CompressedLD.Value);
        }
        private static void FileSystemLD(string args)
        {
            argT = args;
            Console.WriteLine(Args.FileSystemLD.Value);
        }
        private static void SizeLD(string args)
        {
            argT = args;
            Console.WriteLine(Args.SizeLD.Value);
        }
        private static void FreeSpaceLD(string args)
        {
            argT = args;
            Console.WriteLine(Args.FreeSpaceLD.Value);
        }
        private static void PercentageFreeSpace(string args)
        {
            argT = args;
            Console.WriteLine(Args.PercentageFreeSpace.Value);
        }
        private static void ChekDirtyTom(string args)
        {
            argT = args;
            Console.WriteLine(Args.ChekDirtyTom.Value);
        }
        private static void AvgDiskReadQueueLength(string args)
        {
            argT = args;
            Console.WriteLine(Args.AvgDiskReadQueueLength.Value);
        }
        private static void AvgDiskWriteQueueLength(string args)
        {
            argT = args;
            Console.WriteLine(Args.AvgDiskWriteQueueLength.Value);
        }
        private static void SplitIOPerSec(string args)
        {
            argT = args;
            Console.WriteLine(Args.SplitIOPerSec.Value);
        }
        private static void LoadPercentageP(string args)
        {
            argT = args;
            Console.WriteLine(Args.LoadPercentageP.Value);
        }
        private static void CurrentClockSpeedP(string args)
        {
            argT = args;
            Console.WriteLine(Args.CurrentClockSpeedP.Value);
        }
        private static void VirtualizationFirmwareEnabled(string args)
        {
            argT = args;
            Console.WriteLine(Args.VirtualizationFirmwareEnabled.Value);
        }
        private static void SerialNumberP(string args)
        {
            argT = args;
            Console.WriteLine(Args.SerialNumberP.Value);
        }
        /*
         * WMI json
         */
        private static void PhysicalDisk()
        {
            Console.WriteLine($"{{\"data\":[{WMI.JSON.PhysicalDisk.Name}]}}");
        }
        private static void LogicalDisk()
        {
            Console.WriteLine($"{{\"data\":[{WMI.JSON.LogicalDisk.Name}]}}");
        }
        /*
         * PerfCounter
         */
        private static void AvailableMBytesM()
        {
            Console.WriteLine(Standart.AvailableMBytesM.Value);
        }
        /*
         *  Environment
         */
        private static void PCName()
        {
            Console.WriteLine(Environment.MachineName);
        }
        private static void OSVersion()
        {
            Console.WriteLine(Othe.OSVersion.Value);
        }
        /*
        * 1C json
        */
        /*
         * Othe
         */
        private static void Mac()
        {
            Console.WriteLine(Othe.Mac.Addr);
        }
        private static void SMART()
        {
            Auxiliary SMART = new Auxiliary();
            SMART.SMART();
        }
        private static void UserPersonalFolberSize(string args)
        {
            Catalogs catalogs = new Catalogs();
            catalogs.GetSizeUserFolber(args, ref Data.Temp.TempD);
            Console.WriteLine(Data.Temp.TempD.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
        }
        private static void UserPersonalFolder()
        {
            Catalogs catalogs = new Catalogs();
            catalogs.GetUserFolber();
            string u = string.Join(",", Data.LisrDat.BigUser);
            Console.WriteLine($"{{\"data\":[{u}]}}");
        }
    }
}
