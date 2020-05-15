using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenHardwareMonitor.Hardware;

namespace zabbixscr
{
    class Temperature
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        public static string GetCPUSensorName(ref string CPUSensorName)
        {
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.CPUEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                Data.LisrDat.CPUSensorName.Add($"{{\"{{#CPUSENSORNAME}}\":\"{Convert.ToString(computer.Hardware[i].Sensors[j].Name).Replace('#',':')} {i}\"}}");
                            }
                        }
                    }
                }
                computer.Close();
                CPUSensorName = String.Join(",", Data.LisrDat.CPUSensorName);               
            }
            catch
            {
                CPUSensorName = "101";
            }
            return CPUSensorName;
        }
        public static string GetCPUSensorValue(string CPUSensorName, ref string CPUSensorValue)
        {
            try
            {
                CPUSensorName = CPUSensorName.Replace(':', '#').Remove(CPUSensorName.Length - 2);
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.CPUEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {                           
                            if (computer.Hardware[i].Sensors[j].Name == CPUSensorName && computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                CPUSensorValue = computer.Hardware[i].Sensors[j].Value.ToString();
                            }
                        }
                    }
                }
                computer.Close();
            }
            catch
            {
                CPUSensorValue = "101";
            }
            return CPUSensorValue;
        }
        public static string GetDiskSensorName(ref string DiskSensorName)
        {
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.HDDEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.HDD)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                Data.LisrDat.DiskSensorName.Add($"{{\"{{#DISKSENSORNAME}}\":\"{Convert.ToString(computer.Hardware[i].Name)}\"}}");
                            }
                        }
                    }
                }
                computer.Close();
                DiskSensorName = String.Join(",", Data.LisrDat.DiskSensorName);
            }
            catch
            {
                DiskSensorName = "101";
            }
            return DiskSensorName;
        }
        public static string GetDiskSensorValue(string DiskSensorName, ref string DiskSensorValue)
        {
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.HDDEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.HDD)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Name == DiskSensorName && computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                DiskSensorValue = computer.Hardware[i].Sensors[j].Value.ToString();
                            }
                        }
                    }
                }
                computer.Close();
            }
            catch
            {
                DiskSensorValue = "101";
            }
            return DiskSensorValue;
        }
    }
}