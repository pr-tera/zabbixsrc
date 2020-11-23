using System;
using System.ServiceProcess;

namespace zabbixscr.Services
{
    class Services
    {
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
            catch
            {
                //Status = Convert.ToString(e);
            }
        }
    }
}
