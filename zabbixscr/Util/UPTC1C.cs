using System;
using System.Text;
using System.Diagnostics;

namespace zabbixscr.Util
{
    class UPTC1C
    {
        public static void UpdateTC1C(string Client)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                string _clint = string.Empty;
                if (Client == "Fresh")
                {
                    _clint = UPTC.Fresh;
                }
                else if (Client == "BO")
                {
                    _clint = UPTC.BO;
                }
                Process UpdateTC = new Process();
                UpdateTC.StartInfo.FileName = UPTC.UpdateTCScriptPath;
                UpdateTC.StartInfo.Arguments = _clint;
                UpdateTC.Start();
                UpdateTC.WaitForExit();
                UpdateTC.Dispose();
                Console.WriteLine("1");
            }
            catch (Exception e)
            {
                Console.WriteLine(101);
            }
        }
    }
    struct UPTC
    {
        internal static string UpdateTCScriptPath { get; } = @"C:\Util\auto_upd_tc_1cfresh_1cbo.exe";
        internal static string Fresh { get; }  = "https://1cfresh.com/a/ea/305321";
        internal static string BO { get; } = "https://app.1cbo.ru/a/sbp/131972";
    }
}
