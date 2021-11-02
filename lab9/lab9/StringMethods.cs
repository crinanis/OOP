using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public static class StringMethods
    {
        public static string RemovePunctionMarks(string str)        // Удаление различных знаков препинания
        {
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("!", string.Empty);
            str = str.Replace("?", string.Empty);
            str = str.Replace("-", string.Empty);
            str = str.Replace(";", string.Empty);
            str = str.Replace("/", string.Empty);
            return str;
        }

        public static string AddToString(string str)                // Добавление символов
        {
            return str += "символ";
        }

        public static string Upper(string str)                      // Замена букв на заглавные
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToUpper(str[i]));
            }
            return str;
        }

        public static string Lower(string str)                      // Замена букв на строчные
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToLower(str[i]));
            }
            return str;
        }
        public static string RemoveSpase(string str)                // Удаление пробелов
        {
            return str.Replace(" ", string.Empty);
        }
    }
}