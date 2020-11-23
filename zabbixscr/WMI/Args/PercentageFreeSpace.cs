using System;

namespace zabbixscr.WMI.Args
{
    class PercentageFreeSpace
    {
        internal static string Size
        {
            get
            {
                return _size();
            }
            private set
            {
                _size();
            }
        }
        private static string _size()
        {
            double t = Math.Round(Convert.ToDouble(FreeSpaceLD.Value) / Convert.ToDouble(SizeLD.Size) * 100);
            return Convert.ToString(t);
        }
    }
}
