using System;
using System.IO;

namespace zabbixscr
{
    class PlaceCalculation
    {
        /*
         *Класс описывает функции рекурсивного поиска для вычисления размера папок 
         */
         //Поиск по корневому каталогу
        public static double SizeUserDir(string Folber, ref double CatalogSize)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(Folber);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                    CatalogSize = CatalogSize + f.Length;
                }
                foreach (DirectoryInfo df in diA)
                {
                    SizeUserDir(df.FullName, ref CatalogSize);
                }
                return Math.Round((double)(CatalogSize / 1024 / 1024 / 1024), 2);
            }
            //catch (DirectoryNotFoundException)
            //{
            //    return 0;
            //}
            //catch (UnauthorizedAccessException)
            //{
            //    return 0;
            //}
            //catch (Exception)
            //{
            //    return 0;
            //}
            catch
            {
                return 0;
            }
        }
    }
}
