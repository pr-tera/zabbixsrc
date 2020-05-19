using System;
using System.Text;
using System.ServiceProcess;

namespace zabbixscr.Util
{
    class Services
    {
        public static string GetServiceName(ref string Name)
        {
            try
            {
                foreach (var i in ServiceController.GetServices())
                {
                    if (i.StartType == ServiceStartMode.Automatic)
                    {
                        //if (i.ServiceName.Contains("1C:Enterprise") || i.ServiceName.Contains("1C:") || i.ServiceName.Contains("1С:"))
                        //{
                        //    Data.LisrDat.TempL.Add(Convert.ToString($"{{\"{{#1CSERVICESNAME}}\":\"{Convert.ToString(i.ServiceName).Replace("(", "LScobk").Replace(")", "RScobck")}\"}}"));
                        //}
                        Data.LisrDat.TempL.Add(Convert.ToString($"{{\"{{#SERVICESNAME}}\":\"{Convert.ToString(i.ServiceName).Replace("(", "LScobk").Replace(")", "RScobck")}\"}}"));
                    }
                }
                Name = string.Join(",", Data.LisrDat.TempL);
            }
            catch (Exception e)
            {
                Name = Convert.ToString(e);
            }
            return Name;
        }
        public static string StatusService(string Name, ref string Status)
        {
            Name = Name.Replace("LScobk", "(").Replace("RScobck", ")");
            try
            {
                foreach (var i in ServiceController.GetServices())
                {
                    if (i.ServiceName == Name)
                    {
                        Status = Convert.ToString(i.Status);
                    }
                }
            }
            catch (Exception e)
            {
                Status = Convert.ToString(e);
            }
            return Status;
        }
        public static void StartService(string Name)
        {
            DateTime Date1 = DateTime.Now;
            DateTime Date2 = Date1.AddSeconds(25);
            //TimeSpan TimeOut = Date2 - Date1;
            Name = Name.Replace("LScobk", "(").Replace("RScobck", ")");
            try
            {
                foreach (var i in ServiceController.GetServices())
                {
                    if (i.ServiceName == Name)
                    {
                        if (i.Status == ServiceControllerStatus.Stopped)
                        {
                            i.Start();
                            i.WaitForStatus(ServiceControllerStatus.Running);
                            //Status = Convert.ToString(i.Status);
                        }
                        if (i.Status == ServiceControllerStatus.StopPending)
                        {
                            i.WaitForStatus(ServiceControllerStatus.Stopped);
                            i.Start();
                            i.WaitForStatus(ServiceControllerStatus.Running);
                            //Status = Convert.ToString(i.Status);
                        }
                        if (i.Status == ServiceControllerStatus.Paused)
                        {
                            i.Start();
                            i.WaitForStatus(ServiceControllerStatus.Running);
                            //Status = Convert.ToString(i.Status);
                        }
                        if (i.Status == ServiceControllerStatus.StartPending)
                        {
                            i.WaitForStatus(ServiceControllerStatus.Running);
                            //Status = Convert.ToString(i.Status);
                        }
                        if (i.Status == ServiceControllerStatus.StartPending)
                        {
                            i.WaitForStatus(ServiceControllerStatus.Running);
                            //Status = Convert.ToString(i.Status);
                        }
                        if (i.Status == ServiceControllerStatus.Running)
                        {
                            //Status = Convert.ToString(i.Status);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Status = Convert.ToString(e);
            }
        }
    }
}
