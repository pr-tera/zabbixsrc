using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace zabbixscr.TJ
{
    struct Data
    {
        internal static List<string> Path = new List<string>();
        internal static List<string> TJ = new List<string>();
        internal static List<string> TJold = new List<string>();
        internal static string RootDirTJ { get; } = @"C:\LOG1C";
        internal static string Message
        {
            get
            {
                return @"C:\LOG1C\Message";
            }
        }
        internal static int CurrentIndexMessage
        {
            get
            {
                return TJ.Count;
            }
        }
        internal static bool ExistsXML
        {
            get
            {
                if (File.Exists(Message))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        internal static int IndexMessage { get; set; }
        internal static string LogPath;
        internal static string Error { get; set; }
        internal static string CurrentDate { get; set; }
    }
    class OpenTJ
    {
        public static void FindTJ()
        {
            Data.CurrentDate = DateTime.Now.ToString("yyMMddHH");
            //DataTJ.Path = SearchForCurrentLog(DataTJ.RootDirTJ);
            SearchForCurrentLog(Data.RootDirTJ);
        }
        public static void SearchForCurrentLog(string FilePath)
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
                        //if (i.Name.Contains(DataTJ.CurrentDate))
                        //{
                        //    Path = i.FullName;
                        //    break;
                        //}
                        if (i.Name.Contains(Data.CurrentDate))
                        {
                            Data.Path.Add(i.FullName);
                            //break;
                        }
                    }
                }
                else
                {
                    SearchForCurrentLog(y.FullName);
                }
            }
            //return true;
        }
        private static void GetTJ(string path)
        {
            using (FileStream FileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader Reader = new StreamReader(FileStream))
                {
                    string line;
                    Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (Reg.IsMatch(line))
                        {
                            Data.TJ.Add($"{line}\n");
                        }
                        else
                        {
                            string str = Data.TJ.Last();
                            str += line;
                            Data.TJ.Remove(Data.TJ.Last());
                            Data.TJ.Add($"{str}\n");
                        }
                    }
                }
            }
        }
        public static void TJ()
        {
            DirectoryInfo di = new DirectoryInfo(Data.Message);
            FileInfo[] fi = di.GetFiles();
            int ver = 0;
            foreach (var i in Data.Path)
            {
                GetTJ(i.ToString());
                if (fi.Length == 0)
                {
                    ver++;
                    CheckXML.GenXml($"{Data.Message}\\{Data.CurrentDate}{ver}.xml", i.ToString());
                    Data.Error += $"---------------{i}---------------\n";
                    foreach (var y in Data.TJ)
                    {
                        Data.Error += $"{y}\n";
                    }
                }
                else
                {
                    foreach (var messagePath in fi)
                    {
                        CheckXML.GetXMLString(messagePath.FullName);
                        if (i == Data.LogPath)
                        {
                            if (Data.IndexMessage < Data.TJ.Count)
                            {
                                //если передано строк меньше чем текущее
                                if (Data.IndexMessage <= 0)
                                {
                                    //если передано строк меньше или равно 0
                                    Data.Error += $"---------------{i}---------------\n";
                                    foreach (var str in Data.TJ)
                                    {
                                        Data.Error += $"{str}\n";
                                    }
                                    CheckXML.RenXML(messagePath.FullName);
                                }
                                else
                                {
                                    //передано строк строк больше 0
                                    Data.TJ.RemoveRange(0, Data.IndexMessage);
                                    Data.Error += $"---------------{i}---------------\n";
                                    foreach (var str in Data.TJ)
                                    {
                                        Data.Error += $"{i}\n";
                                        CheckXML.RenXML(messagePath.FullName);
                                    }
                                }
                            }
                            else if (Data.IndexMessage == Data.TJ.Count)
                            {
                                //передано столько же строк
                                Data.Error = "";
                            }
                        }

                    }
                }
            }
        }
        //public static void TestTJ()
        //{
        //    /*
        //     * прогоняю все файлы из списка с текущей отметкой времени 
        //     */
        //    foreach (var path in Data.Path)
        //    {
        //        using (FileStream FileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        {
        //            using (StreamReader Reader = new StreamReader(FileStream))
        //            {
        //                string line;
        //                Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
        //                while ((line = Reader.ReadLine()) != null)
        //                {
        //                    if (Reg.IsMatch(line))
        //                    {
        //                        Data.TJ.Add($"{line}\n");
        //                    }
        //                    else
        //                    {
        //                        string str = Data.TJ.Last();
        //                        str += line;
        //                        Data.TJ.Remove(Data.TJ.Last());
        //                        Data.TJ.Add($"{str}\n");
        //                    }
        //                }
        //            }
        //        }
        //        DirectoryInfo di = new DirectoryInfo(Data.Message);
        //        FileInfo[] fi = di.GetFiles();
        //        if (fi.Length != 0)
        //        {
        //            foreach (var f in fi)
        //            {
        //                string pathlog = Data.Message + path + ".xml";
        //                CheckXML.GetXMLString();
        //                if (f.FullName == Data.LogPath)
        //                {
        //                    if (Data.IndexMessage < Data.TJ.Count)
        //                    {
        //                        //если передано строк меньше чем текущее
        //                        if (Data.IndexMessage <= 0)
        //                        {
        //                            //если передано строк меньше или равно 0
        //                            foreach (var i in Data.TJ)
        //                            {
        //                                Data.Error += $"{i}\n";
        //                            }
        //                            CheckXML.RenXML(f.FullName);
        //                        }
        //                        else
        //                        {
        //                            //передано строк строк больше 0
        //                            DataTJ.TJ.RemoveRange(0, DataTJ.IndexMessage);
        //                            foreach (var i in DataTJ.TJ)
        //                            {
        //                                Data.Error += $"{i}\n";
        //                                //CheckXML.RenXML();
        //                            }
        //                        }
        //                    }
        //                    else if (Data.IndexMessage == Data.TJ.Count)
        //                    {
        //                        //передано столько же строк
        //                        Data.Error = "";
        //                    }
        //                }
        //                else
        //                {
        //                    //текущей файл лога != прошлому
        //                    using (FileStream FileStream = new FileStream(Data.LogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //                    {
        //                        using (StreamReader Reader = new StreamReader(FileStream))
        //                        {
        //                            string line;
        //                            Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
        //                            while ((line = Reader.ReadLine()) != null)
        //                            {
        //                                if (Reg.IsMatch(line))
        //                                {
        //                                    Data.TJold.Add(line);
        //                                }
        //                                else
        //                                {
        //                                    string i = Data.TJold.Last();
        //                                    i += line;
        //                                    Data.TJold.Remove(Data.TJold.Last());
        //                                    Data.TJold.Add(i);
        //                                }
        //                            }
        //                        }
        //                    }
        //                    if (Data.IndexMessage < Data.TJold.Count)
        //                    {
        //                        Data.TJold.RemoveRange(0, Data.IndexMessage);
        //                        foreach (var i in Data.TJold)
        //                        {
        //                            Data.Error += $"{i}\n";
        //                        }
        //                        foreach (var i in Data.TJ)
        //                        {
        //                            Data.Error += $"{i}\n";
        //                        }
        //                        CheckXML.RenXML(Data.LogPath);
        //                    }
        //                    else
        //                    {
        //                        Data.Error = "101";
        //                        CheckXML.RenXML(Data.Message + "\\" + Data.CurrentDate + ".xml");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //Файл обмена не существует
        //            CheckXML.GenXml(path);
        //            TestTJ();
        //        }
        //    }
        //}
        class CheckXML
        {
            public static void GenXml(string path, string logPath)
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlDeclaration XmlDec = XmlMess.CreateXmlDeclaration("1.0", null, null);
                XmlMess.AppendChild(XmlDec);
                XmlElement xOptions = XmlMess.CreateElement("Options");
                XmlMess.AppendChild(xOptions);
                XmlElement xFile = XmlMess.CreateElement("File");
                xFile.InnerText = logPath;
                xOptions.AppendChild(xFile);
                XmlElement xNumber = XmlMess.CreateElement("Number");
                xNumber.InnerText = Data.CurrentIndexMessage.ToString();
                xOptions.AppendChild(xNumber);
                XmlMess.Save(path);
            }
            public static void GetXMLString(string path)
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlMess.Load(path);
                Data.IndexMessage = Convert.ToInt32(XmlMess.SelectSingleNode("Options/Number").InnerText);
                Data.LogPath = Convert.ToString(XmlMess.SelectSingleNode("Options/File").InnerText);
            }
            public static void RenXML(string logPath)
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlMess.Load(logPath);
                XmlMess.SelectSingleNode($@"Options[Number=""{Data.CurrentIndexMessage}""]");
                XmlMess.SelectSingleNode($@"Options[File=""{Data.Path}""]");
                XmlMess.Save(logPath);
            }
        }
    }
}
//                    if (File.Exists(pathlog))
//                    {
//                        CheckXML.GetXMLString(pathlog);
//                        if (f.FullName == Data.LogPath)
//                        {
//                            if (Data.IndexMessage<Data.TJ.Count)
//                            {
//                                //если передано строк меньше чем текущее
//                                if (Data.IndexMessage <= 0)
//                                {
//                                    //если передано строк меньше или равно 0
//                                    foreach (var i in Data.TJ)
//                                    {
//                                        Data.Error += $"{i}\n";
//                                    }
//                                    CheckXML.RenXML(f.FullName);
//                                }
//                                else
//                                {
//                                    //передано строк строк больше 0
//                                    DataTJ.TJ.RemoveRange(0, DataTJ.IndexMessage);
//                                    foreach (var i in DataTJ.TJ)
//                                    {
//                                        Data.Error += $"{i}\n";
//                                        //CheckXML.RenXML();
//                                    }
//                                }
//                            }
//                            else if (Data.IndexMessage == Data.TJ.Count)
//                            {
//                                //передано столько же строк
//                                Data.Error = "";
//                            }
//                        }
//                        else
//                        {
//                            //текущей файл лога != прошлому
//                            using (FileStream FileStream = new FileStream(Data.LogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//                            {
//                                using (StreamReader Reader = new StreamReader(FileStream))
//                                {
//                                    string line;
//Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
//                                    while ((line = Reader.ReadLine()) != null)
//                                    {
//                                        if (Reg.IsMatch(line))
//                                        {
//                                            Data.TJold.Add(line);
//                                        }
//                                        else
//                                        {
//                                            string i = Data.TJold.Last();
//i += line;
//                                            Data.TJold.Remove(Data.TJold.Last());
//                                            Data.TJold.Add(i);
//                                        }
//                                    }
//                                }
//                            }
//                            if (Data.IndexMessage<Data.TJold.Count)
//                            {
//                                Data.TJold.RemoveRange(0, Data.IndexMessage);
//                                foreach (var i in Data.TJold)
//                                {
//                                    Data.Error += $"{i}\n";
//                                }
//                                foreach (var i in Data.TJ)
//                                {
//                                    Data.Error += $"{i}\n";
//                                }
//                                CheckXML.RenXML(Data.LogPath);
//                            }
//                            else
//                            {
//                                Data.Error = "101";
//                                CheckXML.RenXML(Data.LogPath);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        //Файл обмена не существует
//                        CheckXML.GenXml(path);
//                        TestTJ();
//                    }