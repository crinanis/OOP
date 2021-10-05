using System;

namespace lab4
{
    public class Node
    {
        private Node next;
        private string info;

        public Node NextNode
        {
            get => next;
        }
        public Node SetNextNode(Node _nextNode) => next = _nextNode;
        public string Date
        {
            get => info;
            set => info = value;
        }
    }

    public class List
    {
        public class Owner
        {
            public Owner(string Name, string org) //конструктор, добавляющий владельцев
            {
                id++;
                name = Name;
                organisation = org;
            }
            public void ShowInfo()                  //метод вывод информации
            {
                Console.WriteLine($"Id:             {id}");
                Console.WriteLine($"Имя:            {name}");
                Console.WriteLine($"Организация:    {organisation}\n");
            }
            private static int id = 0;
            private string name;
            private string organisation;
        }
        public class Date                   //вложенный класс, содержащий дату
        {
            public Date()                   //конструктор
            {
                time = DateTime.Now;
            }
            public void ShowDate()          //метод для вывода времени
            {
                Console.WriteLine(time);
            }
            private DateTime time;
        }

        private Node tail = null;
        private Node head = null;

        public Owner _owner { get; set; }
        public Date _date { get; set; }
        public int Length { get; private set; }

        public List()                       //конструктор списка
        {
            head = null;
            tail = null;
            Length = 0;
        }

        public Node GetHead => head;
        public void Add(string _date)
        {
            if (head == null)                       //проверяем, пусть ли список
            {
                head = new Node();                  //создаём новый элемент списка
                head.Date = _date;                  //добавляем в него дату
                tail = head;
                head.SetNextNode(null);
            }
            else
            {
                Node tempNode = new Node();         //создаём новый элемент списка
                tempNode.Date = _date;              //добавляем в него дату
                tail.SetNextNode(tempNode);         //следующим добавляем этот элемент
                tail = tempNode;                    //и в сам tail
                tempNode.SetNextNode(null);         //за tail null
            }
            Length++;
        }

        public string GetByIndex(int i)             //получение элемента списка по индексу
        {
            Node node = head;
            for (int index = 0; index < i; ++index)
            {
                node = node.NextNode;
            }
            return node.Date;
        }

        public void Show()                          //вывод списка
        {
            Node i = head;
            while (i != null)
            {
                Console.Write(i.Date + " ");
                i = i.NextNode;
            }
            Console.WriteLine();
        }

        public void Remove(string _date)                    //удаление элемента по дате
        {
            Node i = head;
            Node iNext = head.NextNode;
            if (i.Date == _date)                            //если в списке один элемент
            {
                head = i.NextNode;                          //в head - следующий за ним
                Console.WriteLine($" {_date} удален");
                Length--;
                return;
            }
            while (iNext != null)
            {
                if (iNext.Date == _date)
                {
                    i.SetNextNode(iNext.NextNode);
                    Console.WriteLine($" {_date} удален");
                    Length--;
                    return;
                }
                i = i.NextNode;
                iNext = iNext.NextNode;
            }
            Console.WriteLine($" {_date} не найден");
        }

        //Перегрузка операций-----------------------------------------------------------------------------------------------------------------------------------------
        public static List operator !(List obj1)                //Инверсия элементов
        {
            List listNew = new List();
            for (int i = obj1.Length - 1; i >= 0; i--)
            {
                listNew.Add(obj1.GetByIndex(i));
            }
            return listNew;
        }
        public static List operator +(List obj1, List obj2)     //Объединение списков
        {
            List newList = new List();
            for (int i = 0; i < obj1.Length; ++i)
            {
                newList.Add(obj1.GetByIndex(i));
            }
            for (int i = 0; i < obj2.Length; ++i)
            {
                newList.Add(obj2.GetByIndex(i));
            }
            return newList;
        }

        public static bool operator !=(List obj1, List obj2)
        {
            if (obj1.Length != obj2.Length) return true;
            Node i1 = obj1.GetHead;
            Node i2 = obj2.GetHead;
            while (i1 != null)
            {
                if (i1.Date != i2.Date) return true;
                i1 = i1.NextNode;
                i2 = i2.NextNode;
            }
            return false;
        }

        public static bool operator ==(List obj1, List obj2)    ///Равенство списков
        {
            if (obj1 != obj2) return false;
            else return true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("Список 1:");
            List list = new List();
            list.Add("Наруто");
            list.Add("Саске");
            list.Add("Сакура");
            list.Show();
            list.Remove("Сакура");
            list.Remove("Коноха");
            list.Show();


            Console.WriteLine("\nСписок 2:");
            List list2 = new List();
            list2.Add("Какаши");
            list2.Show();


            Console.WriteLine("\nСписок 3 (объединение 1-го и 2-го):");
            List list3 = list + list2;
            list3.Show();


            Console.WriteLine("\nCумма элементов списка 3:");
            list3.Sum();


            Console.WriteLine("\nСписок 4 (инверсия списка 3):");
            list3 = !list3;
            list3.Show();


            Console.WriteLine("\nСписок 3 усечен до 5 символов:");
            list3.СropList(5);
            list3.Show();


            Console.WriteLine("\nРавны ли список 4 и 5?");
            List list4 = new List();
            List list5 = new List();
            list4.Add("12345");
            list5.Add("12345");
            list4.Show();
            list5.Show();
            if (list5 == list4) Console.WriteLine("Да, равны.");
            if (list5 != list4) Console.WriteLine("Нет, не равны.");


            Console.WriteLine("\n\nOwners:");
            list4._owner = new List.Owner("Ксения", "LeverX");
            list5._owner = new List.Owner("Михаил Круг", "Microsoft");
            list4._owner.ShowInfo();
            list5._owner.ShowInfo();


            Console.WriteLine("\nДаты:");
            list4._date = new List.Date();
            list5._date = new List.Date();
            Console.WriteLine("\n Вывод даты для 4-го списка: ");
            list4._date.ShowDate();
            Console.WriteLine("\n Вывод даты для 5-го списка: ");
            list5._date.ShowDate();
        }
    }
}