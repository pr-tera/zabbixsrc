using System;
using System.Text;
using System.Diagnostics;

namespace zabbixscr.Util
{
    class UPTC1C
    {
        public static void UpdateTC1C()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Process UpdateTC = new Process();
                UpdateTC.StartInfo.FileName = Const.UpdateTCScriptPath;
                UpdateTC.StartInfo.Arguments = Const.UpdateTCScriptArgs;
                UpdateTC.Start();
                UpdateTC.Dispose();
                Console.WriteLine("1");
            }
            catch (Exception e)
            {
                Console.WriteLine(101);
            }
        }
    }
}
