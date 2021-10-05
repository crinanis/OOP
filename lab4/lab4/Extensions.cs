using System;

namespace lab4
{
    public static class Extensions
    {
        public static void СropList(this List obj, int size)       //Усечение строки до заданной длины
        {
            Node i = obj.GetHead;
            while (i != null)
            {
                i.Date = i.Date.Substring(0, size);
                i = i.NextNode;
            }
        }

        public static void Sum(this List obj)                      //Сумма элементов списка
        {
            int total_sum = 0;  
            Node i = obj.GetHead;

            while (i != null)
            {
                total_sum++;
                i = i.NextNode;
            }
            Console.WriteLine(total_sum);
        }
    }

}