using System;
using System.Collections.Generic;
using System.Management;

namespace zabbixscr.Standart
{
    class MemoryInfo
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (string.IsNullOrEmpty(i) || i.Contains("101"))
                    {
                        return "Error";
                    }
                    else
                    {
                        return i;
                    }
                }
                else
                {
                    return "Error";
                }
            }
        }
        private static object WMIQuery()
        {
            string _temp = string.Empty;
            List<string> Temp = new List<string>();
            try
            {
                ManagementObjectSearcher u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject y in u.Get())
                {
                    try
                    {
                        Temp.Add($"-------------------\nTag: {Convert.ToString(y["Tag"])}\n-------------------\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Tag: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| BankLabel: {Convert.ToString(y["BankLabel"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| BankLabel: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| DeviceLocator: {Convert.ToString(y["DeviceLocator"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| DeviceLocator: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Manufacturer: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| FormFactor: {Auxiliary.FormFactorMemory(Convert.ToInt32(y["FormFactor"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| FormFactor: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MemoryType: {Auxiliary.MemoryType(Convert.ToInt32(y["MemoryType"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MemoryType: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| InterleavePosition: {Convert.ToString(y["InterleavePosition"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| InterleavePosition: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| InterleaveDataDepth: {Convert.ToString(y["InterleaveDataDepth"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| InterleaveDataDepth: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Model: {Convert.ToString(y["Model"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Model: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| SerialNumber: {Convert.ToString(y["SerialNumber"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| SerialNumber: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| PartNumber: {Convert.ToString(y["PartNumber"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| PartNumber: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Speed: {Convert.ToString(y["Speed"])} MHz\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Speed: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| TotalWidth: {Convert.ToString(y["TotalWidth"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| TotalWidth: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| DataWidth: {Convert.ToString(y["DataWidth"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| DataWidth: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| TypeDetail: {Auxiliary.TypeDetailMemory(Convert.ToInt32(y["TypeDetail"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| TypeDetail: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Capacity: {Math.Floor(Convert.ToInt64(y["Capacity"]) / 1e+9)} Gb\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Capacity: WMIQuery error: {ex}\n");
                    }
                }
                u.Dispose();
                Temp.Add(
                    "-------------------\n" +
                    "PhysicalMemoryArray\n" +
                    "-------------------\n");
                u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
                foreach (ManagementObject y in u.Get())
                {
                    try
                    {
                        Temp.Add($"-------------------\nTag: {Convert.ToString(y["Tag"])}\n-------------------\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Tag: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Location: {Auxiliary.LocationMemory(Convert.ToInt32(y["Location"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Location: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MemoryDevices: {Convert.ToString(y["MemoryDevices"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MemoryDevices: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MemoryErrorCorrection: {Auxiliary.MemoryErrorCorrection(Convert.ToInt32(y["MemoryErrorCorrection"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MemoryErrorCorrection: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| UseMemory: {Auxiliary.UseMemory(Convert.ToInt32(y["Use"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| UseMemory: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MaxCapacity: {Math.Floor(Convert.ToInt32(y["MaxCapacity"]) / 1e+6)} Gb\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MaxCapacity: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MaxCapacityEx: {Math.Floor(Convert.ToInt64(y["MaxCapacityEx"]) / 1e+6)} Gb\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MaxCapacityEx: WMIQuery error: {ex}\n");
                    }
                }
                u.Dispose();
            }
            catch
            {
                Temp.Add("101");
            }
            _temp = string.Join("", Temp);
            return _temp;
        }
    }
}
