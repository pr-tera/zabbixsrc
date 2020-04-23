using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace zabbixscr.TJ
{
    class OpenTJ
    {
        public static void FindTJ()
        {
            DataTJ.CurrentDate = DateTime.Now.ToString("yyMMddHH");
            DataTJ.Path = SearchForCurrentLog(DataTJ.RootDirTJ, ref DataTJ.Path);
        }
        public static string SearchForCurrentLog(string FilePath, ref string Path)
        {
            DirectoryInfo Dir = new DirectoryInfo(FilePath);
            DirectoryInfo[] DirA = Dir.GetDirectories();
            foreach (DirectoryInfo y in DirA)
            {
                if (y.Name.Contains("rphost"))
                {
                    FileInfo[] Fi = y.GetFiles();
                    foreach (FileInfo i in Fi)
                    {
                        if (i.Name.Contains(DataTJ.CurrentDate))
                        {
                            Path = i.FullName;
                            break;
                        }
                    }
                }
                else
                {
                    SearchForCurrentLog(y.FullName, ref Path);
                }
            }
            return Path;
        }
        public static string TJ(ref string Error)
        {
            using (FileStream FileStream = new FileStream(DataTJ.Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader Reader = new StreamReader(FileStream))
                {
                    string line;
                    Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (Reg.IsMatch(line))
                        {
                            DataTJ.TJ.Add(line);
                        }
                        else
                        {
                            string i = DataTJ.TJ.Last();
                            i += line;
                            DataTJ.TJ.Remove(DataTJ.TJ.Last());
                            DataTJ.TJ.Add(i);
                        }
                    }
                }
            }
            DataTJ.IndexMessage = Message(ref DataTJ.IndexMessage);
            DataTJ.CurrentIndexMessage = DataTJ.TJ.Count - 1;
            if (DataTJ.IndexMessage == 0)
            {
                Error = "101";
            }
            else  if(DataTJ.IndexMessage != DataTJ.CurrentIndexMessage)
            {
                DataTJ.TJ.RemoveRange(0, DataTJ.IndexMessage);
                foreach (var i in DataTJ.TJ)
                {
                    Error += $"{i}\n";
                }
                using (StreamWriter Writer = new StreamWriter(DataTJ.MessageNumber))
                {
                    DataTJ.CurrentIndexMessage = DataTJ.TJ.Count - 1;
                    Writer.WriteLine(DataTJ.CurrentIndexMessage);
                }
            }
            else if (DataTJ.IndexMessage == DataTJ.CurrentIndexMessage)
            {
                if (DataTJ.Chek == true)
                {
                    TJ(ref DataTJ.Error);
                    DataTJ.Chek = false;
                }
                else
                {
                    Error = "101";
                }
            }
            else if (DataTJ.IndexMessage < DataTJ.CurrentIndexMessage)
            {
                DataTJ.CurrentDate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyMMddhhHH")) - 1);
                SearchForCurrentLog(DataTJ.RootDirTJ, ref DataTJ.Path);
                TJ(ref DataTJ.Error);
            }
            return Error;
        }
        static int Message(ref int Index)
        {
            if (File.Exists(DataTJ.MessageNumber))
            {
                using (StreamReader Reader = new StreamReader(DataTJ.MessageNumber))
                {
                    Index = Convert.ToInt32(Reader.ReadLine());
                }
            }
            else
            {
                //File.Create(DataTJ.MessageNumber);
                using (StreamWriter Writer = new StreamWriter(DataTJ.MessageNumber))
                {
                    DataTJ.CurrentIndexMessage = DataTJ.TJ.Count - 1;
                    Writer.WriteLine(DataTJ.CurrentIndexMessage);
                }
            }
            return Index;
        }
    }
}
