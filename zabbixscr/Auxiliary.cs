using System;
using System.Collections.Generic;
using System.IO;
using System.Management;

namespace zabbixscr
{
    /*
     * Класс описывает вспомогательные функции
     */
    class Auxiliary
    {
        public static string AvailabilityMB(int Number, ref string CpuStatus)
        {
            string[] Cpu_Status = new string[] { "Other","Unknown","Running/Full Power","Warning","In Test","Not Applicable","Power Off","Off Line","Off Duty","Degraded","Not Installed","Install Error","Power Save - Unknown","Power Save - Low Power Mode","Power Save - Standby","Power Cycle","Power Save - Warning","Paused","Not Ready","Not Configured","Quiesced"};
            return CpuStatus = Cpu_Status[Number - 1];
        }
        public static string CpuStatus(int Number, ref string CpuStatus)
        {
            string[] Cpu_Status = new string[] { "Unknown", "CPU Enabled", "CPU Disabled by User via BIOS Setup", "CPU Disabled By BIOS (POST Error)", "CPU is Idle", "Reserved", "Reserved ", "Other" };
            return CpuStatus = Cpu_Status[Number];
        }
        public static string AvailabilityCPU(int Number, ref string AvailabilityCPU)
        {
            string[] Availability_CPU = new string[] { "Other","Unknown","Running/Full Power","Running or Full Power","Warning","In Test","Not Applicable","Power Off","Off Line","Off Duty","Degraded","Not Installed", "Install Error","Power Save - Unknown","Power Save - Low Power Mode","Power Save - Standby","Power Cycle","Power Save - Warning","Paused","Not Ready","Not Configured","Quiesced" };
            return AvailabilityCPU = Availability_CPU[Number - 1];
        }
        public static string ArchitectureCPU(int Number, ref string ArchitectureCPU)
        {
            if (Number == 9)
            {
                ArchitectureCPU = "x64";
            }
            else
            {
                string[] Architecture_CPU = new string[] { "x86", "MIPS", "Alpha", "PowerPC", "ARM", "ia64" };
                ArchitectureCPU = Architecture_CPU[Number];
            }
            return ArchitectureCPU;
        }
        public static string ProcessorType(int Number, ref string ProcessorType)
        {
            string[] Processor_Type = new string[] { "Other", "Unknown", "Central Processor", "Math Processor", "DSP Processor", "Video Processor" };
            return ProcessorType = Processor_Type[Number - 1];
        }
        public static string UseMemory(int Number, ref string UseMemory)
        {
            string[] Use_Memory = new string[] { "Reserved", "Other", "Unknown", "System memory", "Video memory", "Flash memory", "Non-volatile RAM", "Cache memory" };
            return UseMemory = Use_Memory[Number];
        }
        public static string MemoryErrorCorrection(int Number, ref string MemoryErrorCorrection)
        {
            string[] MemoryError_Correction = new string[] { "Reserved", "Other", "Unknown", "None", "Parity", "Single-bit ECC", "Multi-bit ECC", "CRC"};
            return MemoryErrorCorrection = MemoryError_Correction[Number];
        }
        public static string LocationMemory(int Number, ref string LocationMemory)
        {
            string[] Location_Memory = new string[] { "Reserved", "Other", "Unknown", "System board or motherboard", "ISA add-on card", "EISA add-on card", "PCI add-on card", "MCA add-on card", "PCMCIA add-on card", "Proprietary add-on card", "NuBus", "PC-98/C20 add-on card", "PC-98/C24 add-on card", "PC-98/E add-on card", "PC-98/Local bus add-on card"};
            return LocationMemory = Location_Memory[Number];
        }
        public static string MemoryType(int Number, ref string MemoryType)
        {
            string[] Memory_Type = new string[] { "Other", "Unknown", "DRAM", "EDRAM", "VRAM", "SRAM", "RAM", "ROM", "FLASH", "EEPROM", "FEPROM", "EPROM", "CDRAM", "3DRAM", "SDRAM", "SGRAM", "RDRAM", "DDR", "DDR2", "DDR2 FB-DIMM", "Reserved", "Reserved", "Reserved", "DDR3", "FBD2", "DDR4", "LPDDR", "LPDDR2", "LPDDR3", "LPDDR4" };
            return MemoryType = Memory_Type[Number - 1];
        }
        public static string FormFactorMemory(int Number, ref string FormFactor)
        {
            string[] Form_Factor = new string[] { "Unknown", "Other", "SIP", "DIP", "ZIP", "SOJ", "Proprietary", "SIMM", "DIMM", "TSOP", "PGA", "RIMM", "SODIMM", "SRIMM", "SMD", "SSMP", "QFP", "TQFP", "SOIC", "LCC", "PLCC", "BGA", "FPBGA", "LGA"};
            return FormFactor = Form_Factor[Number];
        }
        public static string TypeDetailMemory(int Number, ref string TypeDetail)
        {
            switch (Number)
            {
                case 1:
                    TypeDetail = "Reserved";
                    break;
                case 2:
                    TypeDetail = "Other";
                    break;
                case 4:
                    TypeDetail = "Unknown";
                    break;
                case 8:
                    TypeDetail = "Fast-paged";
                    break;
                case 16:
                    TypeDetail = "Static column";
                    break;
                case 32:
                    TypeDetail = "Pseudo-static";
                    break;
                case 64:
                    TypeDetail = "RAMBUS";
                    break;
                case 128:
                    TypeDetail = "Synchronous";
                    break;
                case 256:
                    TypeDetail = "CMOS";
                    break;
                case 512:
                    TypeDetail = "EDO";
                    break;
                case 1024:
                    TypeDetail = "Window DRAM";
                    break;
                case 2048:
                    TypeDetail = "Cache DRAM";
                    break;
                case 4096:
                    TypeDetail = "Non-volatile";
                    break;
            }
            return TypeDetail;
        }
        public static string UserDir(string UserDir, ref string ExUserDir)
        {
            DirectoryInfo Dir = new DirectoryInfo(UserDir + ".1ESKA");
            if (Dir.Exists)
            {
                if (Dir.LastWriteTime.Year == DateTime.Now.Year)
                {
                    ExUserDir = Dir.FullName;
                }
                else
                {
                    ExUserDir = UserDir;
                }
            }
            else
            {
                ExUserDir = UserDir;
            }
            return ExUserDir;
        }
        public static string[] SplittoMass(string Source, ref string[] Output)
        {
            Output = Source.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return Output;
        }
        //Список папок пользователей с последней записью в этом году
        public static string GetUserDirList(ref string UserDirList)
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users");
            foreach (var item in Dir.GetDirectories())
            {
                if (item.LastWriteTime.Year == DateTime.Now.Year)
                {
                    UserDirList += item.Name + " ";
                }
            }
            return UserDirList;
        }
        public void SMART()
        {
            try
            {           
                var dicDrives = new Dictionary<int, HDD>();
                var wdSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                int iDriveIndex = 0;
                foreach (ManagementObject drive in wdSearcher.Get())
                {
                    var hdd = new HDD();
                    hdd.Model = drive["Model"].ToString().Trim();
                    hdd.Type = drive["InterfaceType"].ToString().Trim();
                    dicDrives.Add(iDriveIndex, hdd);
                    iDriveIndex++;
                }
                var pmsearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                iDriveIndex = 0;
                foreach (ManagementObject drive in pmsearcher.Get())
                {
                    if (iDriveIndex >= dicDrives.Count)
                        break;
                    dicDrives[iDriveIndex].Serial = drive["SerialNumber"] == null ? "None" : drive["SerialNumber"].ToString().Trim();
                    iDriveIndex++;
                }
                var searcher = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
                searcher.Scope = new ManagementScope(@"\root\wmi");
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus");
                iDriveIndex = 0;
                foreach (ManagementObject drive in searcher.Get())
                {
                    dicDrives[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                    iDriveIndex++;
                }
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictData");
                iDriveIndex = 0;
                foreach (ManagementObject data in searcher.Get())
                {
                    Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                    for (int i = 0; i < 30; ++i)
                    {
                        try
                        {
                            int id = bytes[i * 12 + 2];
                            int flags = bytes[i * 12 + 4];
                            bool failureImminent = (flags & 0x1) == 0x1;
                            int value = bytes[i * 12 + 5];
                            int worst = bytes[i * 12 + 6];
                            int vendordata = BitConverter.ToInt32(bytes, i * 12 + 7);
                            if (id == 0) continue;

                            var attr = dicDrives[iDriveIndex].Attributes[id];
                            attr.Current = value;
                            attr.Worst = worst;
                            attr.Data = vendordata;
                            attr.IsOK = failureImminent == false;
                        }
                        catch
                        {
                            
                        }
                    }
                    iDriveIndex++;
                }
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictThresholds");
                iDriveIndex = 0;
                foreach (ManagementObject data in searcher.Get())
                {
                    Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                    for (int i = 0; i < 30; ++i)
                    {
                        try
                        {

                            int id = bytes[i * 12 + 2];
                            int thresh = bytes[i * 12 + 3];
                            if (id == 0) continue;

                            var attr = dicDrives[iDriveIndex].Attributes[id];
                            attr.Threshold = thresh;
                        }
                        catch
                        {
                            
                        }
                    }

                    iDriveIndex++;
                }
                foreach (var drive in dicDrives)
                {
                    Console.WriteLine(" DRIVE ({0}): " + drive.Value.Serial + " - " + drive.Value.Model + " - " + drive.Value.Type, ((drive.Value.IsOK) ? "OK" : "BAD"));
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
}
