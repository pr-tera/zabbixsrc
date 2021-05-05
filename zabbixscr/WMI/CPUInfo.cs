using System;
using System.Management;

namespace zabbixscr.WMI
{
    class CPUInfo
    {
        internal static string Info
        {
            get 
            {
                return _info();
            }
            private set
            {
                _info();
            }
        }
        private static string _info()
        {
            string Temp = string.Empty;
            ManagementObjectSearcher u = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject y in u.Get())
            {
                try
                {
                    Data.Temp.Add($"-------------------\nDeviceID: {Convert.ToString(y["DeviceID"])}\n-------------------\n");
                }
                catch
                {
                    Data.Temp.Add("DeviceID: 101\n");
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
                    Data.Temp.Add($"| Name: {Convert.ToString(y["Name"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| Name: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Caption: {Convert.ToString(y["Caption"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| Caption: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| ProcessorType: {Auxiliary.ProcessorType(Convert.ToInt32(y["ProcessorType"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| ProcessorType: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| SocketDesignation: {Convert.ToString(y["SocketDesignation"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| SocketDesignation: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| AddressWidth: {Convert.ToString(y["AddressWidth"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| AddressWidth: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Architecture: {Auxiliary.ArchitectureCPU(Convert.ToInt32(y["Architecture"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| Architecture: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| Availability: {Auxiliary.AvailabilityCPU(Convert.ToInt32(y["Availability"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| Availability: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| CpuStatus: {Auxiliary.CpuStatus(Convert.ToInt32(y["CpuStatus"]), ref Temp)}\n");
                }
                catch
                {
                    Data.Temp.Add("| CpuStatus: 101\n");
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
                    Data.Temp.Add($"| CurrentClockSpeed: {Convert.ToString(y["CurrentClockSpeed"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| CurrentClockSpeed: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| MaxClockSpeed: {Convert.ToString(y["MaxClockSpeed"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| MaxClockSpeed: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| ExtClock: {Convert.ToString(y["ExtClock"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| ExtClock: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| L2CacheSize: {Convert.ToString(y["L2CacheSize"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| L2CacheSize: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| L3CacheSize: {Convert.ToString(y["L3CacheSize"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| L3CacheSize: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| NumberOfCores: {Convert.ToString(y["NumberOfCores"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| NumberOfCores: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| NumberOfEnabledCore: {Convert.ToString(y["NumberOfEnabledCore"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| NumberOfEnabledCore: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| NumberOfLogicalProcessors: {Convert.ToString(y["NumberOfLogicalProcessors"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| NumberOfLogicalProcessors: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| ThreadCount: {Convert.ToString(y["ThreadCount"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| ThreadCount: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| ProcessorId: {Convert.ToString(y["ProcessorId"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| ProcessorId: 101\n");
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
                    Data.Temp.Add($"| PowerManagementSupported: {Convert.ToString(y["PowerManagementSupported"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| PowerManagementSupported: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| SecondLevelAddressTranslationExtensions: {Convert.ToString(y["SecondLevelAddressTranslationExtensions"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| SecondLevelAddressTranslationExtensions: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| VirtualizationFirmwareEnabled: {Convert.ToString(y["VirtualizationFirmwareEnabled"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| VirtualizationFirmwareEnabled: 101\n");
                }
                try
                {
                    Data.Temp.Add($"| VMMonitorModeExtensions: {Convert.ToString(y["VMMonitorModeExtensions"])}\n");
                }
                catch
                {
                    Data.Temp.Add("| VMMonitorModeExtensions: 101\n");
                }
            }
            u.Dispose();
            Temp = string.Join("", Data.Temp);
            return Temp;
        }
    }
}
