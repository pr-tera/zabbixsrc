using System.IO;

namespace zabbixscr.Util
{
    class ClearCache
    {
        static string UserDirList = Auxiliary.GetUserDirList(ref UserDirList);
        static string[] Output = Auxiliary.SplittoMass(UserDirList, ref Output);
        static string[] DirTemp = {
            @"AppData\Local\Temp\",
            @"AppData\Local\Google\Chrome\User Data\",
            @"Local\MicrosoftEdge\",
            @"Local\Mozilla\",
            @"Local\CrashDumps\",
            @"AppData\Roaming\1C\1c8\tmplts\",
            @"\AppData\Local\1C\1cv8\",
            @"\Downloads\"
        };
        static string RootDir = @"C:\Users\";
        internal static void DellCache()
        {
            foreach (var i in Output)
            {
                foreach (var y in DirTemp)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo($@"{RootDir}\{i}\{y}");
                    try
                    {
                        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                        {
                            try
                            {
                                fileInfo.Delete();
                            }
                            catch
                            {
                                //
                            }
                        }
                        foreach (DirectoryInfo directoryInfo1 in directoryInfo.GetDirectories())
                        {
                            try
                            {
                                using (FileStream fstream = new FileStream(@"C:\Zabbix Agent\log.log", FileMode.OpenOrCreate))
                                {
                                    using (StreamWriter sw = new StreamWriter(fstream, System.Text.Encoding.Default))
                                    {
                                        sw.Write($"Clean directory: {directoryInfo1.FullName}\n");
                                    }
                                }
                                directoryInfo1.Delete(true);
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                    catch
                    {
                        //
                    }
                }
            }
        }
    }
}
