using System.Collections.Generic;

namespace zabbixscr.TJ
{
    struct DataTJ
    {
        //public const string RootDirTJ = @"C:\LOG1C";
        public static string CurrentDate = string.Empty;
        public static string Path = string.Empty;
        public static string Error = string.Empty;
        public const string MessageNumber = @"C:\LOG1C\Message.xml";
        public static string LogPath = string.Empty;
        public static int IndexMessage = 0;
        public static int CurrentIndexMessage = 0;
        public static bool ExistsXML = false;
        //
        public static List<string> TJ = new List<string>();
        public static List<string> TempTJ = new List<string>();
    }
}
