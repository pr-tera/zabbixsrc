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
        public static string Mac = System.String.Empty;
        public static string BoardMaker = System.String.Empty;
        public static string SerialNumber = System.String.Empty;
        public static string SocketCPU = System.String.Empty;
        public static string DescriptionCPU = System.String.Empty;
        public static string PhysicalDisk = System.String.Empty;
        public static string SerialNumberD = System.String.Empty;
        public static string LogicalDisk = System.String.Empty;
        public static string SectionNameD = System.String.Empty;
        public static string SerialNumberLD = System.String.Empty;
        public static string CompressedLD = System.String.Empty;
        public static string FileSystemLD = System.String.Empty;
        public static string ChekDirtyTom = System.String.Empty;
        public static string SerialNumberMemory = System.String.Empty;
        public static string SpeedM = System.String.Empty;
        public static string ProcessorDetected = System.String.Empty;
        public static string ModelP = System.String.Empty;
        public static string VirtualizationFirmwareEnabled = System.String.Empty;
        public static string VMMonitorModeExtensions = System.String.Empty;
        public static string SocketDesignation = System.String.Empty;
        public static string SerialNumberP = System.String.Empty;
        public static string TimeZone = System.String.Empty;
        public static string AutomaticManagedPagefile = System.String.Empty;
        public static string DNSHostName = System.String.Empty;
        public static string Domain = System.String.Empty;
        public static string DomainRole = System.String.Empty;
    }
}
