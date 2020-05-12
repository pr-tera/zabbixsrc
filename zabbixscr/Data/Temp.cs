using System;
namespace zabbixscr.Data
{
    struct Temp
    {
        //int
        public static int AvgDiskReadQueueLength = 0;
        public static int AvgDiskWriteQueueLength = 0;
        public static int SplitIOPerSec = 0;
        public static int LoadPercentageP = 0;
        public static int CurrentClockSpeedP = 0;
        public static int MaxClockSpeeP = 0;
        public static int NumberOfCoresP = 0;
        public static int NumberOfLogicalProcessors = 0;
        //double
        public static double PhysicalDiskSize = 0;
        public static double Out = 0;
        public static double SizeLD = 0;
        public static double FreeSpaceLD = 0;
        public static double PercentageFreeSpace = 0;
        public static double AvailableMBytesM = 0;
        public static double CacheBytesM = 0;
        public static double TotalPhysicalMemory = 0;
        public static double PageSecInDSwap = 0;
        //string
        public static string Mac = String.Empty;
        public static string BoardMaker = String.Empty;
        public static string SerialNumber = String.Empty;
        public static string SocketCPU = String.Empty;
        public static string DescriptionCPU = String.Empty;
        public static string PhysicalDisk = String.Empty;
        public static string SerialNumberD = String.Empty;
        public static string LogicalDisk = String.Empty;
        public static string SectionNameD = String.Empty;
        public static string SerialNumberLD = String.Empty;
        public static string CompressedLD = String.Empty;
        public static string FileSystemLD = String.Empty;
        public static string ChekDirtyTom = String.Empty;
        public static string MemoryInfo = String.Empty;
        public static string SpeedM = String.Empty;
        public static string ProcessorDetected = String.Empty;
        public static string ModelP = String.Empty;
        public static string VirtualizationFirmwareEnabled = String.Empty;
        public static string VMMonitorModeExtensions = String.Empty;
        public static string SocketDesignation = String.Empty;
        public static string SerialNumberP = String.Empty;
        public static string TimeZone = String.Empty;
        public static string AutomaticManagedPagefile = String.Empty;
        public static string DNSHostName = String.Empty;
        public static string Domain = String.Empty;
        public static string DomainRole = String.Empty;
        public static string FormFactorMemory = String.Empty;
        public static string MemoryType = String.Empty;
        public static string TypeDetailMemory = String.Empty;
        public static string LocationMemory = String.Empty;
        public static string MemoryErrorCorrection = String.Empty;
        public static string UseMemory = String.Empty;
    }
}
