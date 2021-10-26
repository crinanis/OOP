using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    partial class Program
    {
        public static void LoadFromFile(ref CollectionType<Geometric_figure> objCollectionType)
        {
            string text = "";

            using (StreamReader sr = new StreamReader(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab8\lab8\1.txt"))
            {
                while (sr.ReadLine() != null)
                {
                    text = sr.ReadLine();
                    switch (text)
                    {
                        case "Circle":
                            objCollectionType.Add(new Circle());
                            break;
                        case "Rectangle":
                            objCollectionType.Add(new Rectangle());
                            break;
                        case "Figures":
                            objCollectionType.Add(new Figures(20));
                            break;
                    }
                }
            }
        }
    }

    partial class CollectionType<T>
    {
        public void SaveInFile()
        {
            using (StreamWriter sw = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab8\lab8\2.txt", false))
            {
                Node<T> i = GetHead;
                sw.WriteLine($"{DateTime.Now}-----------------------------------");
                while (i != null)
                {
                    sw.WriteLine(i.Date);
                    i = i.NextNode;
                }
            }
        }
    }
}

