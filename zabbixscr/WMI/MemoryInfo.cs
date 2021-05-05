using System;
using System.Management;

namespace zabbixscr.WMI
{
    class MemoryInfo
    {
        internal static string Info
        {
            get
            {
                return _memoryInfo();
            }
            private set
            {
                _memoryInfo();
            }
        }
        private static string _memoryInfo()
        {
            string Temp = string.Empty;
            ManagementObjectSearcher u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject y in u.Get())
            {
                try
                {
                    Data.Temp.Add($"-------------------\nTag: {Convert.ToString(y["Tag"])}\n-------------------\n");
                }
                catch
                {
                    Data.Temp.Add("Tag: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| BankLabel: {Convert.ToString(y["BankLabel"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| BankLabel: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| DeviceLocator: {Convert.ToString(y["DeviceLocator"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| DeviceLocator: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| Manufacturer: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| FormFactor: {Auxiliary.FormFactorMemory(Convert.ToInt32(y["FormFactor"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| FormFactor: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MemoryType: {Auxiliary.MemoryType(Convert.ToInt32(y["MemoryType"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| MemoryType: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| InterleavePosition: {Convert.ToString(y["InterleavePosition"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| InterleavePosition: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| InterleaveDataDepth: {Convert.ToString(y["InterleaveDataDepth"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| InterleaveDataDepth: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Model: {Convert.ToString(y["Model"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| Model: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| SerialNumber: {Convert.ToString(y["SerialNumber"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| SerialNumber: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| PartNumber: {Convert.ToString(y["PartNumber"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| PartNumber: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Speed: {Convert.ToString(y["Speed"])} MHz\n");
                }
                catch
                {
                    Data.Temp.Add("| Speed: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| TotalWidth: {Convert.ToString(y["TotalWidth"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| TotalWidth: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| DataWidth: {Convert.ToString(y["DataWidth"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| DataWidth: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| TypeDetail: {Auxiliary.TypeDetailMemory(Convert.ToInt32(y["TypeDetail"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| TypeDetail: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Capacity: {Math.Floor(Convert.ToInt64(y["Capacity"]) / 1e+9)} Gb\n");
                }
                catch
                {
                    Data.Temp.Add("| Capacity: 101\n");
                }
            }
            u.Dispose();
            Data.Temp.Add(
                "-------------------\n" +
                "PhysicalMemoryArray\n" +
                "-------------------\n");
            u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
            foreach (ManagementObject y in u.Get())
            {
                try
                {
                    Data.Temp.Add($"-------------------\nTag: {Convert.ToString(y["Tag"])}\n-------------------\n");
                }
                catch
                {
                    Data.Temp.Add("Tag: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Location: {Auxiliary.LocationMemory(Convert.ToInt32(y["Location"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| Location: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MemoryDevices: {Convert.ToString(y["MemoryDevices"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| MemoryDevices: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MemoryErrorCorrection: {Auxiliary.MemoryErrorCorrection(Convert.ToInt32(y["MemoryErrorCorrection"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| MemoryErrorCorrection: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| UseMemory: {Auxiliary.UseMemory(Convert.ToInt32(y["Use"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| UseMemory: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MaxCapacity: {Math.Floor(Convert.ToInt32(y["MaxCapacity"]) / 1e+6)} Gb\n");
                }
                catch
                {
                    Data.Temp.Add("| MaxCapacity: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MaxCapacityEx: {Math.Floor(Convert.ToInt64(y["MaxCapacityEx"]) / 1e+6)} Gb\n");
                }
                catch
                {
                    Data.Temp.Add("| MaxCapacityEx: 101\n");
                }
            }
            u.Dispose();
            Temp = string.Join("", Data.Temp);
            return Temp;
        }
    }
}
