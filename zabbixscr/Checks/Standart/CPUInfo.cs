using System;
using System.Collections.Generic;
using System.Management;

namespace zabbixscr.Standart
{
    class CPUInfo
    {
        internal static string Value
        {
            get
            {
                object _value = WMIQuery();
                if (_value.GetType() == typeof(string))
                {
                    string i = Convert.ToString(_value);
                    if (string.IsNullOrEmpty(i))
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
                ManagementObjectSearcher u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject y in u.Get())
                {
                    try
                    {
                        Temp.Add($"-------------------\nDeviceID: {Convert.ToString(y["DeviceID"])}\n-------------------\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"DeviceID: WMIQuery error: {ex}\n");
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
                        Temp.Add($"| Name: {Convert.ToString(y["Name"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Name: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Caption: {Convert.ToString(y["Caption"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Caption: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| ProcessorType: {Auxiliary.ProcessorType(Convert.ToInt32(y["ProcessorType"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| ProcessorType: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| SocketDesignation: {Convert.ToString(y["SocketDesignation"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| SocketDesignation: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| AddressWidth: {Convert.ToString(y["AddressWidth"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| AddressWidth: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Architecture: {Auxiliary.ArchitectureCPU(Convert.ToInt32(y["Architecture"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Architecture: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| Availability: {Auxiliary.AvailabilityCPU(Convert.ToInt32(y["Availability"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| Availability: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| CpuStatus: {Auxiliary.CpuStatus(Convert.ToInt32(y["CpuStatus"]), ref _temp)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add("| CpuStatus: WMIQuery error: {ex}\n");
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
                        Temp.Add($"| CurrentClockSpeed: {Convert.ToString(y["CurrentClockSpeed"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| CurrentClockSpeed: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| MaxClockSpeed: {Convert.ToString(y["MaxClockSpeed"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| MaxClockSpeed: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| ExtClock: {Convert.ToString(y["ExtClock"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| ExtClock: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| L2CacheSize: {Convert.ToString(y["L2CacheSize"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| L2CacheSize: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| L3CacheSize: {Convert.ToString(y["L3CacheSize"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| L3CacheSize: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| NumberOfCores: {Convert.ToString(y["NumberOfCores"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| NumberOfCores: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| NumberOfEnabledCore: {Convert.ToString(y["NumberOfEnabledCore"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| NumberOfEnabledCore: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| NumberOfLogicalProcessors: {Convert.ToString(y["NumberOfLogicalProcessors"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| NumberOfLogicalProcessors: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| ThreadCount: {Convert.ToString(y["ThreadCount"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| ThreadCount: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| ProcessorId: {Convert.ToString(y["ProcessorId"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| ProcessorId: WMIQuery error: {ex}\n");
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
                        Temp.Add($"| PowerManagementSupported: {Convert.ToString(y["PowerManagementSupported"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| PowerManagementSupported: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| SecondLevelAddressTranslationExtensions: {Convert.ToString(y["SecondLevelAddressTranslationExtensions"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| SecondLevelAddressTranslationExtensions: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| VirtualizationFirmwareEnabled: {Convert.ToString(y["VirtualizationFirmwareEnabled"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| VirtualizationFirmwareEnabled: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"| VMMonitorModeExtensions: {Convert.ToString(y["VMMonitorModeExtensions"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"| VMMonitorModeExtensions: WMIQuery error: {ex}\n");
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
