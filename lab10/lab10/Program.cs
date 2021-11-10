using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Concurrent;


namespace lab10
{
    class Books : IDictionary
    {
        private ArrayList _books;
        
        public Books()
        {
            _books = new ArrayList();
        }
        // методы
        public int IndexOfKey(object key)                       // получить индекс по ключу
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (((DictionaryEntry)_books[i]).Key == key)
                    return i;
            }
            return -1;                                          // ключ не найден, вернуть -1
        }   
    
        public object this[object key]                          // получить или внести запись по ключу
        {
            get
            {
                return ((DictionaryEntry)_books[IndexOfKey(key)]).Value;
            }
            set
            {
                _books[IndexOfKey(key)] = new DictionaryEntry(key, value);
            }
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return new BooksEnum(_books);
        }

        public void RemoveAt(int index)
        {
            _books.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return ((DictionaryEntry)_books[index]).Value;
            }
            set
            {
                object key = ((DictionaryEntry)_books[index]).Key;
                _books[index] = new DictionaryEntry(key, value);
            }
        }

        public void Add(object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("Элемент с таким же ключом уже существует в этой коллекции");
            }
            _books.Add(new DictionaryEntry(key, value));
        }

        public void Clear()
        {
            _books.Clear();
        }

        public bool Contains(object key)
        {
            if (IndexOfKey(key) != -1)
            {
                return false;
            }
            else return true;
        }

        // свойства
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection Keys
        {
            get
            {
                ArrayList KeyCollection = new ArrayList(_books.Count);
                for (int i = 0; i < _books.Count; i++)
                {
                    KeyCollection.Add(((DictionaryEntry)_books[i]).Key);
                }
                return KeyCollection;

            }
        }

        public void Remove(object key)
        {
            _books.RemoveAt(IndexOfKey(key));
        }

        public ICollection Values
        {
            get
            {
                ArrayList ValueCollections = new ArrayList(_books.Count);
                for (int i = 0; i < _books.Count; i++)
                {
                    ValueCollections.Add(((DictionaryEntry)_books[i]).Value);
                }
                return ValueCollections;
            }
        }

        public void CopyTo(Array array, int index)
        {
            _books.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return _books.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return _books.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return _books.SyncRoot;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BooksEnum(_books);
        }
    }

    public class BooksEnum : IDictionaryEnumerator
    {
        public ArrayList _books;

        int position = -1;                                          // ставим позицию в -1 до первого вызова MoveNext()

        public BooksEnum(ArrayList list)
        {
            _books = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _books.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _books[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }

        public object Key
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_books[position]).Key;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object Value
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_books[position]).Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Books Dystopia = new Books();
            Dystopia.Add("1984", "Джордж Оруэлл");
            Dystopia.Add("О дивный новый мир", "Олдос Хаксли");
            Dystopia.Add("Кысь", "Татьяна Никитична Толстая");
            Dystopia.Add("Бегущий человек", "Стивен Кинг");
            Dystopia.Add("Повелитель мух", "Уильям Голден");
            Dystopia.Add("Вожделеющее семя", "Эноти Бёрджесс");

            Console.WriteLine("\nСписок всех авторов: ");
            foreach (string i in Dystopia.Values)
                Console.WriteLine(i);

            Console.WriteLine("\nСписок всех книг:");
            foreach (string i in Dystopia.Keys)
                Console.WriteLine(i);

            Console.WriteLine("\nКто написал роман-антиутопию под названием 1984?");
            Console.WriteLine(Dystopia["1984"]);

            Dystopia.Remove("Кысь");
            Console.WriteLine("\nСписок книг после удаления Кысь");
            foreach (string i in Dystopia.Keys)
                Console.WriteLine(i);

            Books Drama = new Books();
            Drama.Add("Фауст", "Иоганн Гёте");
            Drama.Add("Беприданница", "Александр Островский");
            Drama.Add("Вишнёвый сад", "Антон Чехов");
            Drama.Add("На дне", "Максим Горький");

            List<Books> Library = new List<Books>();
            Library.Add(Dystopia);
            Library.Add(Drama);

            Console.WriteLine("\n Выводим авторов из библиотеки:  ");
            foreach(Books prod in Library)
            {
                Console.WriteLine(prod[0]);
            }


            //2. Создаём обобщенную коллекцию и заполняем ее данными

            ConcurrentBag<int> nums = new ConcurrentBag<int>();             // В случае выбора ConcurrentBag мы получаем гарантию, что код не упадёт в многопоточной работе. 
                                                                            // Порядок не имеет значения

            for (int i = 0; i < 20; i++) nums.Add(i);                       // добавление элементов в коллекцию
            Console.WriteLine("\nЭлементы первой коллекции до изменения:");
            foreach (int a in nums)
                Console.WriteLine(a);

            int n;
            for (int i = 0; i < 4; i++)
            {
                nums.TryTake(out n);                                        // удаление элементов из коллекции
                Console.WriteLine(n);
            }

            Console.WriteLine("\nЭлементы первой коллекции после изменения:");
            foreach (int a in nums)
                Console.WriteLine(a);

            // Создание второй коллекции и зарполнение её элементами предыдущей коллекции

            List<int> nums2 = new List<int>();

            while (!nums.IsEmpty)
            {
                if (nums.TryTake(out n))
                {
                    nums2.Add(n);
                }
            }

            Console.WriteLine("\nЭлементы второй коллекции:");
            foreach (int a in nums2)
                Console.WriteLine(a);

            if (nums2.Contains(11)) Console.WriteLine("\nnums2 содержит '11'");
            else Console.WriteLine("\nnums2 не содержит '11'");

            //3. Создайте объект наблюдаемой коллекции ObservableCollection<T>. 
            //Создайте произвольный метод и зарегистрируйте его на событие CollectionChange. 
            //Напишите демонстрацию с добавлением и удалением элементов. В качестве типа T используйте свой класс из таблицы.

            ObservableCollection<Books> MyColletion = new ObservableCollection<Books>();                //пользовательский интерфейс получает информацию об изменениях коллекции

            MyColletion.CollectionChanged += MyCollection_onChange;

            MyColletion.Add(Dystopia);
            MyColletion[0] = Drama;
            MyColletion.RemoveAt(0);
        }

        private static void MyCollection_onChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлен элемент в коллекцию MyCollection");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удалён элемент в коллекцию MyCollection");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Изменен элемент в коллекцию MyCollection");
                    break;
            }
        }
    }
}
