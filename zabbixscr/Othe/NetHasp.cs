using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace zabbixscr.Othe
{
    class NetHasp
    {

        public static string GetHaspLM()
        {
            RequestHasp requestHasp = new RequestHasp();
            string answer;
            List<JsonStruct.Data> datas = new List<JsonStruct.Data>();
            JsonStruct.Root root = new JsonStruct.Root();
            if (CollHasp(requestHasp.SetConfig).Contains("OK"))
            {
                answer = CollHasp(requestHasp.ScanServ);
                while (answer.Contains("SCANNING"))
                {
                    answer = CollHasp(requestHasp.Status);
                }
                if (answer.Contains("OK"))
                {
                    answer = CollHasp(requestHasp.GetService);
                    while (answer.Contains("EMPTY"))
                    {
                        CollHasp(requestHasp.GetService);
                    }
                    string[] temp = answer.Split('\r', '\n');
                    foreach (var str in temp)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str.Contains("NAME"))
                            {
                                datas.Add(new JsonStruct.Data()
                                {
                                    HaspLMID = str.Substring(str.IndexOf("ID=") + 3).Substring(0, str.LastIndexOf(",NAME") - 6),
                                    HaspLMIP = str.Substring(str.IndexOf("UDP") + 4).Substring(0, str.LastIndexOf("VER") - (str.IndexOf("UDP") + 7)),
                                    HaspLMName = str.Substring(str.IndexOf("NAME=") + 6).Substring(0, str.LastIndexOf(",PROT") - (str.IndexOf("NAME=") + 7)),
                                    HaspLMVer = str.Substring(str.IndexOf("VER=") + 5).Substring(0, str.LastIndexOf(",OS") - (str.IndexOf("VER=") + 6))
                                });
                            }
                            else
                            {
                                datas.Add(new JsonStruct.Data()
                                {
                                    HaspLMID = str.Substring(str.IndexOf("ID=") + 3).Substring(0, str.LastIndexOf(",PROT") - 6),
                                    HaspLMIP = str.Substring(str.IndexOf("UDP") + 4).Substring(0, str.LastIndexOf("VER") - (str.IndexOf("UDP") + 7)),
                                    HaspLMName = str.Substring(str.IndexOf("NAME=") + 6).Substring(0, str.LastIndexOf(",PROT") - (str.IndexOf("NAME=") + 7)),
                                    HaspLMVer = str.Substring(str.IndexOf("VER=") + 5).Substring(0, str.LastIndexOf(",OS") - (str.IndexOf("VER=") + 6))
                                });
                            }
                        }
                    }
                    root.Data = datas;
                    //string json = JsonConvert.SerializeObject(root);
                    int i = 0;
                }
            }
            else
            {
                //error
            }
            return JsonConvert.SerializeObject(root);
        }
        public static string CollHasp(string _requst)
        {
            IntPtr unmanagedBuffer = Marshal.AllocHGlobal(65547);
            IntPtr responsBuffer = Marshal.AllocHGlobal(65547 * 100);
            mightyfunc(_requst, responsBuffer, unmanagedBuffer);
            string respons = Marshal.PtrToStringAnsi(responsBuffer);
            Marshal.FreeHGlobal(unmanagedBuffer);
            Marshal.FreeHGlobal(responsBuffer);
            if (!string.IsNullOrEmpty(respons))
            {
                return respons;
            }
            else
            {
                return "Error";
            }
        }
        [DllImport(@"D:\Repos\zabbixscr\zabbixscr\hsmon.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern string mightyfunc([MarshalAs(UnmanagedType.LPStr)] string request, [MarshalAs(UnmanagedType.SysInt)] IntPtr buffer, IntPtr length);
    }
    class RequestHasp
    {
        public string SetConfig { get; } = @"SET CONFIG,FILENAME=""C:\Program Files(x86)\1cv8\conf\nethasp.ini""";
        public string ScanServ { get; } = "SCAN SERVERS";
        public string Status { get; } = "STATUS";
        public string GetService { get; } = "GET SERVERS";
        public string GetLogins { get; } = "GET LOGINS,HS,ID=";
        public string GetLogininfo { get; } = "GET MODULEINFO,ID=1451025218,MA=\"1\"";
    }
    class JsonStruct
    {
        public class Data
        {
            [JsonProperty("HASPLMNAME")]
            public string HaspLMName { get; set; }
            [JsonProperty("HASPLMID")]
            public string HaspLMID { get; set; }
            [JsonProperty("HASPLMIP")]
            public string HaspLMIP { get; set; }
            [JsonProperty("HASPLMVER")]
            public string HaspLMVer { get; set; }
        }
        public class Root
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }
    }
}