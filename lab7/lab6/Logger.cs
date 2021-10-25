using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab6
{
    public static class Logger
    {
        public static void Log(ArgumentException exc, bool fileLogger, bool consoleLogger)
        {
            if (fileLogger) FileLogger(exc);
            if (consoleLogger)
            {
                if (exc is InvalidFigureNameException)
                    ConsoleLogger(exc as InvalidFigureNameException);
                else if (exc is InvalidLifeTimeException)
                    ConsoleLogger(exc as InvalidLifeTimeException);
            }
        }

        private static void FileLogger(Exception exc)
        {
            string error = $"{DateTime.Now}, Information: {exc.Message}";
            using (StreamWriter file = new StreamWriter(@"..\..\..\log.txt", true))
            {
                file.WriteLine(error);
                file.Close();
            }
        }

        private static void ConsoleLogger(InvalidFigureNameException exc)
        {
            Console.WriteLine($"\n\tОшибка");
            Console.WriteLine($"Сообщение: {exc.Message}");
            Console.WriteLine($"Неправильное имя: {exc.Value}");
            Console.WriteLine("-> Место возникновения: {0}", exc.TargetSite);
            foreach (DictionaryEntry d in exc.Data)
                Console.WriteLine("-> {0} {1}", d.Key, d.Value);
        }

        private static void ConsoleLogger(InvalidLifeTimeException exc)
        {
            Console.WriteLine($"\n\tОшибка");
            Console.WriteLine($"Сообщение: {exc.Message}");
            Console.WriteLine($"Время существования объекта: {exc.Value}");
            Console.WriteLine("-> Место возникновения: {0}", exc.TargetSite);
            foreach (DictionaryEntry d in exc.Data)
                Console.WriteLine("-> {0} {1}", d.Key, d.Value);
        }
    }
}
