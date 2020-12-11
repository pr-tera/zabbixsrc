using System;
using System.Collections.Generic;
using System.Management;

namespace zabbixscr.Standart
{

    class BoardMaker
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
            List<string> Temp = new List<string>();
            try
            {
                ManagementObjectSearcher i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject y in i.Get())
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
                        Temp.Add($"Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Manufacturer: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"Model: {Convert.ToString(y["Model"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Model: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"Product: {Convert.ToString(y["Product"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Product: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"SerialNumber: {Convert.ToString(y["SerialNumber"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"SerialNumber: WMIQuery error: {ex}\n");
                    }
                }
                i.Dispose();
                i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
                string Availability = string.Empty;
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        Temp.Add($"Availability: {Auxiliary.Availability_Motherbord(Convert.ToInt32(y["Availability"]), ref Availability)}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Availability: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"PrimaryBusType: {Convert.ToString(y["PrimaryBusType"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"PrimaryBusType: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"SecondaryBusType: {Convert.ToString(y["SecondaryBusType"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"SecondaryBusType: WMIQuery error: {ex}\n");
                    }
                }
                i.Dispose();
                i = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
                foreach (ManagementObject y in i.Get())
                {
                    try
                    {
                        Temp.Add($"BIOS Description: {Convert.ToString(y["Description"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"BIOS Description: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"BIOS Manufacturer: {Convert.ToString(y["Manufacturer"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"BIOS Manufacturer: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"Primary BIOS: {Convert.ToString(y["PrimaryBIOS"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"Primary BIOS: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"SMBIOS Present: {Convert.ToString(y["SMBIOSPresent"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"SMBIOS Present: WMIQuery error: {ex}\n");
                    }
                    try
                    {
                        Temp.Add($"BIOS Version: {Convert.ToString(y["Version"])}\n");
                    }
                    catch (Exception ex)
                    {
                        Temp.Add($"BIOS Version: WMIQuery error: {ex}\n");
                    }
                }
                i.Dispose();
            }
            catch
            {
                Temp.Add("101");
            }
            string t = string.Join("", Temp);
            return t;
        }
    }
}
