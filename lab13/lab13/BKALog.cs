using System;
using System.IO;

namespace lab13
{
    public static class BKALog
    {
        public static StreamWriter logfile;
        public static void writeToLog(string action, string fileName = "", string path = "")
        {
            using (logfile = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab13\lab13\log.txt", true))
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                logfile.WriteLine("********************************\n");
                logfile.WriteLine($"Действие: {action}");

                if (fileName.Length != 0)
                    logfile.WriteLine($"Имя файла: {fileName}");

                if (path.Length != 0)
                    logfile.WriteLine($"Путь: {path}");

                logfile.WriteLine($"Время: {time.ToLocalTime()}\n");
            }
        }

    }
}