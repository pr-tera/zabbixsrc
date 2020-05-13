using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
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
                            DataTJ.TJ.Add($"{line}\n");
                        }
                        else
                        {
                            string i = DataTJ.TJ.Last();
                            i += line;
                            DataTJ.TJ.Remove(DataTJ.TJ.Last());
                            DataTJ.TJ.Add($"{i}\n");
                        }
                    }
                }
            }
            DataTJ.CurrentIndexMessage = DataTJ.TJ.Count;
            if (CheckXML.ExistsXML(ref DataTJ.ExistsXML) == true)
            {
                CheckXML.GetXMLString();
                if (File.Exists(DataTJ.LogPath))
                {
                    if (DataTJ.Path == DataTJ.LogPath)
                    {
                        if (DataTJ.IndexMessage < DataTJ.CurrentIndexMessage)
                        {
                            if (DataTJ.IndexMessage <= 0)
                            {
                                foreach (var i in DataTJ.TJ)
                                {
                                    Error += $"{i}\n";
                                }
                                CheckXML.RenXML();
                            }
                            else
                            {
                                DataTJ.TJ.RemoveRange(0, DataTJ.IndexMessage);
                                foreach (var i in DataTJ.TJ)
                                {
                                    Error += $"{i}\n";
                                    CheckXML.RenXML();
                                }
                            }
                        }
                        else if (DataTJ.IndexMessage == DataTJ.CurrentIndexMessage)
                        {
                            Error = "";
                        }
                    }
                    else
                    {
                        using (FileStream FileStream = new FileStream(DataTJ.LogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader Reader = new StreamReader(FileStream))
                            {
                                string line;
                                Regex Reg = new Regex(@"[0-9](\b{2}\.\d{6})");
                                while ((line = Reader.ReadLine()) != null)
                                {
                                    if (Reg.IsMatch(line))
                                    {
                                        DataTJ.TempTJ.Add(line);
                                    }
                                    else
                                    {
                                        string i = DataTJ.TempTJ.Last();
                                        i += line;
                                        DataTJ.TempTJ.Remove(DataTJ.TempTJ.Last());
                                        DataTJ.TempTJ.Add(i);
                                    }
                                }
                            }
                        }
                        if (DataTJ.IndexMessage < DataTJ.TempTJ.Count)
                        {
                            DataTJ.TempTJ.RemoveRange(0, DataTJ.IndexMessage);
                            foreach (var i in DataTJ.TempTJ)
                            {
                                Error += $"{i}\n";
                            }
                            foreach (var i in DataTJ.TJ)
                            {
                                Error += $"{i}\n";
                            }
                            CheckXML.RenXML();
                        }
                        else
                        {
                            Error = "101";
                            CheckXML.RenXML();
                        }
                    }
                }
                else
                {
                    DataTJ.TempTJ.RemoveRange(0, DataTJ.IndexMessage);
                    foreach (var i in DataTJ.TempTJ)
                    {
                        Error += $"{i}\n";
                    }
                    foreach (var i in DataTJ.TJ)
                    {
                        Error += $"{i}\n";
                    }
                    CheckXML.RenXML();
                }
            }
            else
            {
                CheckXML.GenXml();
                TJ(ref DataTJ.Error);
            }
            return Error;
        }
        class CheckXML : OpenTJ
        {
            public static bool ExistsXML(ref bool ExistsXML)
            {
                if (File.Exists(DataTJ.MessageNumber))
                {
                    ExistsXML = true;
                }
                else
                {
                    ExistsXML = false;
                }
                return ExistsXML;
            }
            public static void GenXml()
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlDeclaration XmlDec = XmlMess.CreateXmlDeclaration("1.0", null, null);
                XmlMess.AppendChild(XmlDec);
                XmlElement xOptions = XmlMess.CreateElement("Options");
                XmlMess.AppendChild(xOptions);
                XmlElement xFile = XmlMess.CreateElement("File");
                xFile.InnerText = DataTJ.Path;
                xOptions.AppendChild(xFile);
                XmlElement xNumber = XmlMess.CreateElement("Number");
                xNumber.InnerText = DataTJ.CurrentIndexMessage.ToString();
                xOptions.AppendChild(xNumber);
                XmlMess.Save(DataTJ.MessageNumber);
                GetXMLString();
            }
            public static void GetXMLString()
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlMess.Load(DataTJ.MessageNumber);
                DataTJ.IndexMessage = Convert.ToInt32(XmlMess.SelectSingleNode("Options/Number").InnerText);
                DataTJ.LogPath = Convert.ToString(XmlMess.SelectSingleNode("Options/File").InnerText);
            }
            public static void RenXML()
            {
                XmlDocument XmlMess = new XmlDocument();
                XmlMess.Load(DataTJ.MessageNumber);
                XmlMess.SelectSingleNode($@"Options[Number=""{DataTJ.CurrentIndexMessage}""]");
                XmlMess.SelectSingleNode($@"Options[File=""{DataTJ.Path}""]");
                XmlMess.Save(DataTJ.MessageNumber);
            }
        }
    }
}
