using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace zabbixscr
{
    public class SMBIOSdata
    {
        public string memory;
        private byte m_byMajorVersion;
        private byte m_byMinorVersion;
        private int m_dwLen;
        private byte[] m_pbBIOSData;
        public List<SMBIOStable> p_oSMBIOStables;
        private const string OUT_OF_SPEC = "<OUT OF SPEC>";

        public SMBIOSdata()
        {
            m_pbBIOSData = new byte[] { };
            p_oSMBIOStables = new List<SMBIOStable>();
        }

        public void GetRawData(string hostname = "localhost")
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + hostname + "\\root\\WMI");
                scope.Connect();
                ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM MSSmBios_RawSMBiosTables");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
                ManagementObjectCollection coll = searcher.Get();
                foreach (ManagementObject queryObj in coll)
                {
                    if (queryObj["SMBiosData"] != null) m_pbBIOSData = (byte[])(queryObj["SMBiosData"]);
                    if (queryObj["SmbiosMajorVersion"] != null) m_byMajorVersion = (byte)(queryObj["SmbiosMajorVersion"]);
                    if (queryObj["SmbiosMinorVersion"] != null) m_byMinorVersion = (byte)(queryObj["SmbiosMinorVersion"]);
                    //if (queryObj["Size"] != null) m_dwLen = (long)(queryObj["Size"]);
                    m_dwLen = m_pbBIOSData.Length;
                }
            }
            catch
            {
            }
        }
        public void GetTables()
        {
            int i = 0;
            while (i < m_dwLen)
            {
                SMBIOStable p_oTable = new SMBIOStable();
                p_oTable.m_bTableType = m_pbBIOSData[i];
                p_oTable.m_bFormattedSectionLength = m_pbBIOSData[i + 1];
                p_oTable.m_wHandle = BitConverter.ToInt16(m_pbBIOSData, i + 2);

                int wUnformattedSectionStart = i + p_oTable.m_bFormattedSectionLength;
                p_oTable.p_bFormattedSection = m_pbBIOSData.Skip(i).Take(p_oTable.m_bFormattedSectionLength).ToArray();

                for (int j = i + p_oTable.m_bFormattedSectionLength; ; j++)
                {
                    if ((m_pbBIOSData[j] == 0) && (m_pbBIOSData[j + 1] == 0))
                    {
                        p_oTable.p_bUnformattedSection = m_pbBIOSData.Skip(i + p_oTable.m_bFormattedSectionLength).Take(j - i - p_oTable.m_bFormattedSectionLength).ToArray();
                        i = j + 2;
                        break;
                    }
                }
                if (p_oTable.p_bUnformattedSection.Length > 0) p_oTable.p_sStrings = Encoding.ASCII.GetString(p_oTable.p_bUnformattedSection).Split('\0');
                p_oSMBIOStables.Add(p_oTable);
            }
        }
        public void ParseTable(SMBIOStable table)
        {
            switch (table.m_bTableType)
            {
                case 17:
                    Console.WriteLine(Dmi_memory_type(table.p_bFormattedSection[18]));
                    break;
            }
        }
        public static void ParseTable1(SMBIOStable table)
        {
            switch (table.m_bTableType)
            {
                case 17:
                    Console.WriteLine(string.Join(",", table.p_sStrings));
                    break;
            }
        }
        private string Dmi_memory_type(int code)
        {
            string[] MEMORY_TYPES = new string[] { "Other", "Unknown", "DRAM", "EDRAM", "VRAM", "SRAM", "RAM", "ROM", "FLASH", "EEPROM", "FEPROM", "EPROM", "CDRAM", "3DRAM", "SDRAM", "SGRAM", "RDRAM", "DDR", "DDR2", "DDR2 FB-DIMM", "Reserved", "Reserved", "Reserved", "DDR3", "FBD2", "DDR4", "LPDDR", "LPDDR2", "LPDDR3", "LPDDR4" };
            return MEMORY_TYPES[code - 1];
        }
    }
}
