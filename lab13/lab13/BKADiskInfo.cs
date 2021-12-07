using System;

namespace lab13
{
    public static class BKADiskInfo
    {
        public static void getFreeDrivesSpace()
        {
            var allDrives = System.IO.DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                Console.WriteLine("********************************");
                Console.WriteLine($"Имя диска: {drive.Name}");
                Console.WriteLine($"Тип диска: {drive.DriveType}");
                if (!drive.IsReady) continue;
                Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                Console.WriteLine($"Путь: {drive.RootDirectory}");
                Console.WriteLine($"Полный объём: {drive.TotalSize / Math.Pow(10, 9)} Gbyte");
                Console.WriteLine($"Свободный объём: {drive.TotalFreeSpace / Math.Pow(10, 9)} Gbyte");
                Console.WriteLine($"Доступный объём: {drive.AvailableFreeSpace / Math.Pow(10, 9)} Gbyte");
                Console.WriteLine("********************************\n");
            }
        }
    }
}