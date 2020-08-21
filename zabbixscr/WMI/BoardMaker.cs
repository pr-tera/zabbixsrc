using System;
using System.Management;

namespace zabbixscr.WMI
{

    class BoardMaker
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
            ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject y in i.Get())
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
                    Data.Temp.Add($"Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                }
                catch
                {
                    Data.Temp.Add("Manufacturer: 101\n");
                }
                try
                {
                    Data.Temp.Add($"Model: {Convert.ToString(y["Model"])}\n");
                }
                catch
                {
                    Data.Temp.Add("Model: 101\n");
                }
                try
                {
                    Data.Temp.Add($"Product: {Convert.ToString(y["Product"])}\n");
                }
                catch
                {
                    Data.Temp.Add("Product: 101\n");
                }
                try
                {
                    Data.Temp.Add($"SerialNumber: {Convert.ToString(y["SerialNumber"])}\n");
                }
                catch
                {
                    Data.Temp.Add("SerialNumber: 101\n");
                }
            }
            i.Dispose();
            i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
            string Availability = string.Empty;
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    Data.Temp.Add($"Availability: {Auxiliary.AvailabilityMB(Convert.ToInt32(y["Availability"]), ref Availability)}\n");
                }
                catch
                {
                    Data.Temp.Add("Availability: 101\n");
                }
                try
                {
                    Data.Temp.Add($"PrimaryBusType: {Convert.ToString(y["PrimaryBusType"])}\n");
                }
                catch
                {
                    Data.Temp.Add("PrimaryBusType: 101\n");
                }
                try
                {
                    Data.Temp.Add($"SecondaryBusType: {Convert.ToString(y["SecondaryBusType"])}\n");
                }
                catch
                {
                    Data.Temp.Add("SecondaryBusType: 101\n");
                }
            }
            i.Dispose();
            i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject y in i.Get())
            {
                try
                {
                    Data.Temp.Add($"BIOS Description: {Convert.ToString(y["Description"])}\n");
                }
                catch
                {
                    Data.Temp.Add("BIOS Description: 101\n");
                }
                try
                {
                    Data.Temp.Add($"BIOS Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                }
                catch
                {
                    Data.Temp.Add("BIOS Manufacturer: 101\n");
                }
                try
                {
                    Data.Temp.Add($"Primary BIOS: {Convert.ToString(y["PrimaryBIOS"])}\n");
                }
                catch
                {
                    Data.Temp.Add("Primary BIOS: 101\n");
                }
                try
                {
                    Data.Temp.Add($"SMBIOS Present: {Convert.ToString(y["SMBIOSPresent"])}\n");
                }
                catch
                {
                    Data.Temp.Add("SMBIOS Present: 101\n");
                }
                try
                {
                    Data.Temp.Add($"BIOS Version: {Convert.ToString(y["Version"])}\n");
                }
                catch
                {
                    Data.Temp.Add("BIOS Version: 101\n");
                }
            }
            i.Dispose();
            string t = string.Join("", Data.Temp);
            return t;
        }
    }
}
