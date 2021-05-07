using System;
using System.Diagnostics;
using System.IO;

namespace zabbixscr._1C
{
    struct Data
    {
        internal static string Rac { get; } = @"C:\Program Files\1cv8\8.3.13.1865\bin\rac.exe";
        internal static int Ras_port { get; } = 1945;
        internal static string Rac_user { get; } = "deploy";
        internal static string Rac_pwd { get; } = "GqNwOPmcG";
        internal static string Output { get; set; }
        //
        internal static string Cluster { get; set; }
        internal static string ClusterName { get; set; }
    }
    class GetInfo
    {
        internal static void Get_clusterInfo()
        {
            Process process = new Process();
            process.StartInfo.FileName = Data.Rac;
            process.StartInfo.Arguments = $"13.0.0.22:{1945} cluster list";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            StreamReader reader = process.StandardOutput;
            Data.Output = reader.ReadToEnd();
            process.WaitForExit();
            process.Dispose();
            Parse.Cluster();
        }
    }
    class Parse
    {
        internal static void Cluster()
        {
            string[] words = Data.Output.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var i in words)
            {
                if (i.Contains("cluster"))
                {
                    Data.Cluster = i.Substring(i.IndexOf(':') + 2);
                }

            }
        }
    }
}


//deployka session kill -ras 13.0.0.22 -rac “C:\Program Files (x86)\1cv8\8.3.16.1359\bin\rac.exe” -db “franupp” -db-user “deploy” -lockmessage “Плановое обновление, 5 мин” -lockuccode update
//db-user deploy -db-pwd GqNwOPmcG