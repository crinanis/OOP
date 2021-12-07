using System;
using System.IO;

namespace lab13
{
    public static class BKADirInfo
    {
        static DirectoryInfo getParentDirs(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                return dirInfo;

            Console.WriteLine($"{dirInfo.Name}");
            return getParentDirs(dirInfo.Parent);
        }

        public static void getDirinfo(string dir)
        {
            System.Console.WriteLine("********************************");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                System.Console.WriteLine("Файл не был найден");
                return;
            }
            Console.WriteLine($"Количество поддиректорий: {dirInfo.GetDirectories().Length}"); 
            Console.WriteLine($"Количество подфайлов: {dirInfo.GetFiles().Length}");
            Console.WriteLine($"Время создания директории: {dirInfo.CreationTime}");
            Console.WriteLine("\nРодительская директория:");
            getParentDirs(dirInfo.Parent);
            System.Console.WriteLine("********************************\n");

        }
    }
}