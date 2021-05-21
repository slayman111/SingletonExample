using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Element element = new Element();
            int a = 1, a1 = 2, a2 = 3;
            double b = 2.2;
            string c = "string";
            char d = 'd';

            object[] entity = new object[6];
            entity[0] = element.Registry<int>().GetOrAdd(a);
            entity[1] = element.Registry<double>().GetOrAdd(b);
            entity[2] = element.Registry<string>().GetOrAdd(c);
            entity[3] = element.Registry<char>().GetOrAdd(d);
            entity[4] = element.Registry<int>().GetOrAdd(a1);
            entity[5] = element.Registry<int>().GetOrAdd(a2);

            Console.WriteLine("Элементы: ");
            foreach (var e in entity)
                Console.WriteLine(e);

            Console.Write("Первый элемент типа int: " + element.GetFirstOfType<int>());

            Console.WriteLine("\nКол-во элементов типа int: " + element.CountOfType<int>());

            Console.ReadKey();
        }
    }
}
