using System.IO;

namespace lab13
{
    public static class BKAFileInfo
    {
        public static void getFileinfo(string file)
        {
            System.Console.WriteLine("********************************");
            FileInfo fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                System.Console.WriteLine("Файл не был найден");
                return;
            }
            System.Console.WriteLine($"Полный путь: {fileInfo.FullName}");
            System.Console.WriteLine($"Размер: {fileInfo.Length} byte");
            System.Console.WriteLine($"Имя: {fileInfo.Name}");
            System.Console.WriteLine($"Полное расширение: {fileInfo.Extension}");
            System.Console.WriteLine($"Полное время создания: {fileInfo.CreationTime}");
            System.Console.WriteLine("********************************\n");
        }

    }
}