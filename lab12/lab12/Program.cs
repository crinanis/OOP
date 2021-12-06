using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace lab12
{
    class Program
    {
        #region airline
        public interface pampam { }
        public partial class Airline: pampam
        {
            public int Sum(int a, int b) { return a + b; }

            public static int NumOfFlights = 0;     //статичсеское поле, хранящее количество созданных объектов
            public readonly int id;                 //поле, доступное только для чтения
            private string Country;
            private int Flight_Number;              //закрытые поля
            private string Airplane_type;
            private DateTime Departure;
            private string Day;

            public string Destination                       //общедоступные свойства
            {
                get { return this.Country; }
                private set { this.Country = value; }
            }
            public int Flight
            {
                get { return this.Flight_Number; }        //ограничили доступ по set, т.е. свойство доступно только для чтения
            }
            public string Airplane
            {
                get { return this.Airplane_type; }
                set { this.Airplane_type = value; }
            }
            public DateTime Flight_Time
            {
                get { return this.Departure; }
                private set { this.Departure = value; }
            }
            public string Day_of_week
            {
                get { return this.Day; }
                set { this.Day = value; }
            }
        }

        public partial class Airline
        {
            //конструктор с параметрами по умолчанию
            public Airline()
            {
                this.id = Airline.NumOfFlights++;
                this.Country = "";
                this.Flight_Number = 0;
                this.Airplane_type = "";
                this.Departure = DateTime.MinValue;
                this.Day = "";
            }
            //конструктор базового класса
            public Airline(string Country, int Flight_Number, string Airplane_Type, DateTime Departure, string Day)
            {
                this.id = Airline.NumOfFlights++;
                this.Country = Country;
                this.Departure = Departure;
                this.Airplane_type = Airplane_Type;
                this.Day = Day;
                this.Flight_Number = Flight_Number;
            }
            //статический конструктор
            static Airline() { Console.WriteLine("Вызвался статический конструктор\n"); }
            ~Airline()
            {
                Airline.NumOfFlights--;
            }

            public override bool Equals(object obj)                 //переопределение метода Equals()
            {
                Airline temp = obj as Airline;
                if (temp == null)
                    return false;
                return (temp.Departure == this.Departure && temp.Day == this.Day && temp.Country == this.Country && temp.Flight_Number == this.Flight_Number && temp.Airplane_type == this.Airplane_type);
            }
            public override int GetHashCode()                       //переопределение метода GetHashCode()
            {
                Console.WriteLine("Вызвался переопределенный метод GetHashCode");
                return base.GetHashCode();
            }
            public override string ToString()                       //переопределение метода ToString()
            {
                return ($"Пункт назначения: {this.Country}, День недели: {this.Day}, Номер рейса: {this.Flight_Number}, Тип самолёта: {this.Airplane_type}");
            }

            public static void sort_by_day(Airline[] arr, string dep_day)                  //статический метод вывода информации
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Day_of_week.Equals(dep_day))
                    {
                        Console.WriteLine($"Пункт назначения: {arr[i].Destination}");
                        Console.WriteLine($"Номер рейса: { arr[i].Flight}");
                        Console.WriteLine($"Тип самолёта: {arr[i].Airplane}");
                        Console.WriteLine($"День недели: { arr[i].Day_of_week}");
                        Console.WriteLine($"Время отлёта: { (arr[i].Flight_Time).ToLongTimeString()}");
                    }
                }
            }

            public static void sort_by_destination(Airline[] arr, ref string place)         //статический метод вывода информации + используем параметр ref (передаём параметр по ссылке)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Destination == place)
                    {
                        Console.WriteLine($"Пункт назначения: {arr[i].Destination}");
                        Console.WriteLine($"Номер рейса: { arr[i].Flight}");
                        Console.WriteLine($"Тип самолёта: {arr[i].Airplane}");
                        Console.WriteLine($"День недели: { arr[i].Day_of_week}");
                        Console.WriteLine($"Время отлёта: { (arr[i].Flight_Time).ToLongTimeString()}");
                    }
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Полное имя сборки: " + AssemblyName.GetAssemblyName(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\bin\Debug\net5.0\ref\lab12.dll") + "\n");
            
            Reflector.all_ClassComponents_toFile("lab12.Program+Airline");
            Console.WriteLine("Все компоненты класса 'lab12.Program+Airline' были записаны в файл.\n");

            Reflector.public_ClassComponents_toFile("lab12.Program+Airline");
            Console.WriteLine("Публичные компоненты класса 'lab12.Program+Airline' были записаны в файл.\n");

            Reflector.fieldsANDproperties_ClassComponents_toFile("lab12.Program+Airline");
            Console.WriteLine("Поля и свойства класса 'lab12.Program+Airline' были записаны в файл.\n");

            Reflector.interfaces_ClassComponents_toFile("lab12.Program+Airline");
            Console.WriteLine("Интерфейсы класса 'lab12.Program+Airline' были записаны в файл.\n");

            Reflector.methodsWITHparams_ClassComponents_toFile("lab12.Program+Airline", "String");
            Console.WriteLine("Методы которые включают параметр типа 'String' класса 'lab12.Program+Airline' были записаны в файл.\n");

            Reflector.lateBinding("lab12.Program+Airline");
        }

        public class Reflector
        {
            public static void all_ClassComponents_toFile(string className)                         //информация и о всех компонентах класса
            {
                Type classType = Type.GetType(className, true, true);            //статический метод для получения типа класса
                using (StreamWriter file = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\all_classComponents.txt"))
                {
                    file.WriteLine($">>>>>>>>>>>>Информация о классе  {className}");
                    file.WriteLine($"Количество свойств: {classType.GetProperties().Length}");        
                    file.WriteLine($"Количество методов: {classType.GetMethods().Length}");             
                    file.WriteLine($"Количество конструкторов: {classType.GetConstructors().Length}");   
                    file.WriteLine($"Количество полей: {classType.GetFields().Length}");                
                    file.WriteLine($">>>>>>>>>>>>");
                    foreach (MemberInfo item in classType.GetMembers())                             //возвращает все члены типа в виде массива объектов MemberInfo
                        file.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
                }
            }

            public static void public_ClassComponents_toFile(string className)                      //информация о публичных компонентах класса
            {
                Type classType = Type.GetType(className, true, true);
                using (StreamWriter file = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\public_classComponents.txt"))
                {
                    file.WriteLine($">>>>>>>>>>>>Информация о классе {className}");
                    file.WriteLine($"Количество публичных свойств: {classType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length}");
                    file.WriteLine($"Количество публичных методов: {classType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Length}");
                    file.WriteLine($"Количество публичных конструкторов: {classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length}");
                    file.WriteLine($"Количество публичных полей: {classType.GetFields(BindingFlags.Public | BindingFlags.Instance).Length}");
                    file.WriteLine($">>>>>>>>>>>>");
                    foreach (MemberInfo item in classType.GetMembers(BindingFlags.Public | BindingFlags.Instance))
                        file.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
                }
            }

            public static void fieldsANDproperties_ClassComponents_toFile(string className)            //информация о полях и свойствах класса
            {
                Type classType = Type.GetType(className, true, true);
                using (StreamWriter file = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\fieldsANDproperties_classComponents.txt"))
                {
                    file.WriteLine($">>>>>>>>>>>>Информация о классе {className}");
                    file.WriteLine($"Количество свойств: {classType.GetProperties().Length}");
                    file.WriteLine($"Количество полей: {classType.GetFields().Length}");
                    file.WriteLine($">>>>>>>>>>>>");
                    file.WriteLine("\nПоля:");
                    foreach (MemberInfo item in classType.GetFields())
                        file.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");

                    file.WriteLine("\nСвойства:");
                    foreach (MemberInfo item in classType.GetProperties())
                        file.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
                }
            }

            public static void interfaces_ClassComponents_toFile(string className)
            {
                Type classType = Type.GetType(className, true, true);
                using (StreamWriter file = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\interfaces_classComponents.txt"))
                {
                    file.WriteLine($">>>>>>>>>>>>Информация о классе {className}");
                    file.WriteLine($"Количество интерфейсов: {classType.GetInterfaces().Length}");
                    file.WriteLine($">>>>>>>>>>>>");
                    foreach (MemberInfo item in classType.GetInterfaces())
                        file.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
                }
            }

            public static void methodsWITHparams_ClassComponents_toFile(string className, string paramType)
            {
                Type classType = Type.GetType(className, true, true);
                using (StreamWriter file = new StreamWriter(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\methodsWITHparams_classComponents.txt"))
                {
                    file.WriteLine($">>>>>>>>>>>>Информация о классе {className}");
                    int count = 0;
                    foreach (MethodInfo method in classType.GetMethods())
                        foreach (ParameterInfo p in method.GetParameters())
                            if (paramType.Equals(p.ParameterType.Name))
                                count++;

                    file.WriteLine($"Количество методов с параметром типа {paramType}: {count}");

                    if (count != 0)
                    {
                        file.WriteLine($">>>>>>>>>>>>");
                        foreach (MethodInfo method in classType.GetMethods())
                        {
                            string modificator = "";
                            if (method.IsPrivate)
                                modificator += "private ";
                            if (method.IsAbstract)
                                modificator += "abstract ";
                            if (method.IsPublic)
                                modificator += "public ";
                            if (method.IsStatic)
                                modificator += "static ";
                            if (method.IsVirtual)
                                modificator += "virtual ";

                            bool isConsiste = false;
                            foreach (ParameterInfo param in method.GetParameters())
                            {
                                if (paramType.Equals(param.ParameterType.Name))
                                {
                                    isConsiste = true;
                                    break;
                                }
                            }

                            if (isConsiste)
                            {
                                file.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");

                                ParameterInfo[] parameters = method.GetParameters();
                                for (int i = 0; i < parameters.Length; i++)
                                {
                                    file.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                                    if (i + 1 < parameters.Length) file.Write(", ");
                                }
                                file.WriteLine(")");
                                isConsiste = false;
                            }
                        }
                    }
                }
            }

            public static void lateBinding(string className, string methodName = "Sum")
            {
                Type classType = Type.GetType(className, false, true);
                object obj = Activator.CreateInstance(classType);                           //создаём объект класса
                MethodInfo methodInfo = classType.GetMethod(methodName);
                StreamReader streamReader = new StreamReader(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab12\lab12\paramsForSum.txt");

                object result = methodInfo.Invoke(obj, new object[] { Convert.ToInt32(streamReader.ReadLine()), Convert.ToInt32(streamReader.ReadLine()) });
                Console.WriteLine($"Результат invoked функции: {result}");
            }
        }
    }
}
