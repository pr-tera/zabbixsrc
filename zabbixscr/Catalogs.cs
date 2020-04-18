using System;
using System.IO;
using System.Collections.Generic;

namespace zabbixscr
{
    /*
     * Класс описывающий функции подготовки информации для вывода
     */ 
    class Catalogs
    {
        public List<string> BigUser = new List<string>();//Папки пользователя больше 10 гб
        //public List<string> SizeBigUser = new List<string>();//Размер папок пользователя
        static string UserDirList = Auxiliary.GetUserDirList(ref UserDirList);
        static string[] Output = Auxiliary.SplittoMass(UserDirList, ref Output);
        double CatalogSize = 0;
        const string HomeDirUsers = @"C:\Users\";
        public void GetUserFolber()
        {
            foreach (var i in Output)
            {
                CatalogSize = PlaceCalculation.SizeUserDir(HomeDirUsers + i, ref CatalogSize);
                if (CatalogSize > 10)
                {
                    BigUser.Add($"{{\"{{#USERDIR}}\":\"{i.Substring(0, i.LastIndexOf("."))}\"}}");
                }
            }
        }
        public void GetSizeUserFolber(string arg, ref Double Out)
        {
            string ExUserDir = null;
            ExUserDir = Auxiliary.UserDir(HomeDirUsers + arg, ref ExUserDir);
            CatalogSize = PlaceCalculation.SizeUserDir(ExUserDir, ref CatalogSize);
            Out = CatalogSize;
        }
    }
}
