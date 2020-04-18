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
        //string
        public static string Mac = null;
        public static string BoardMaker = null;
        public static string SerialNumber = null;
        public static string SocketCPU = null;
        public static string DescriptionCPU = null;
        public static string PhysicalDisk = null;
        public static string SerialNumberD = null;
        public static string LogicalDisk = null;
        public static string SectionNameD = null;
        public static string SerialNumberLD = null;
        public static string CompressedLD = null;
        public static string FileSystemLD = null;
        public static string ChekDirtyTom = null;
        public static string SerialNumberMemory = null;
        public static string SpeedM = null;
        public static string ProcessorDetected = null;
        public static string ModelP = null;
        public static string VirtualizationFirmwareEnabled = null;
        public static string VMMonitorModeExtensions = null;
        public static string SocketDesignation = null;
        public static string SerialNumberP = null;
        public static string TimeZone = null;
        public static string AutomaticManagedPagefile = null;
        public static string DNSHostName = null;
        public static string Domain = null;
        public static string DomainRole = null;
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
    }
}
