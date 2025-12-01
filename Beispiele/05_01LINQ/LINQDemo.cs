using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_01LINQ
{
    class LINQDemo
    {

        static List<Person> persons = new List<Person>()
        {
            new Person("Stroustrup",3000),
            new Person("Hejlsberg",1000),
            new Person("Ritchie",3000)
        };


        static void PrintElements<T>(IEnumerable<T> sequence)
        {
            foreach (T element in sequence) { Console.WriteLine(element); }
        }

        static void LINQQueryNotation()
        {
            // "from p in persons select p" ist eine sog. LINQ expression
            // "Language INtegrated Query" und wird hier noch nicht ausgewertet,
            // sondern erst beim Zugriff auf den Ausdruck, wie z.B. in PrintElements
            // -> "lazy / deferred evaluation"
            Console.WriteLine("All persons:");
            IEnumerable<Person> sequence = from p in persons select p;
            PrintElements(sequence);
            Console.WriteLine("All persons with salary = 1000");
            sequence = from p in persons where p.Salary == 3000 select p;
            PrintElements(sequence);
            Console.WriteLine("From all persons with salary = 1000 select only name");
            var names = from p in persons where p.Salary == 3000 select p.Name;
            PrintElements(names);
            Console.WriteLine("From all persons with salary = 1000 select only name, order by name");
            names = from p in persons where p.Salary == 3000 orderby p.Name select p.Name;
            PrintElements(names);
            Console.WriteLine("Select sum of all salaries:");
            var sum = sequence.Sum(p => p.Salary);
            Console.WriteLine($"sum of all salaries of persons with salary = 3000 {sum}");
        }

        static void DemoLINQDotNotation()
        {
            // Die Namen aller Personen mit Salary = 2000
            // absteigend sortiert nach Name:
            //
            // da alle Methoden aus Enumerable (Where, Select, Order ...)
            // auf IEnumerables anwendbar sind UND IEnumerables zurückgeben,
            // sind sie einfach komponierbar
            persons
                .Where(p => p.Salary == 3000)
                .OrderByDescending(p => p.Name)
                .Select(p => p.Name)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("START");
            // LINQQueryNotation();
            DemoLINQDotNotation();
            Console.WriteLine("EXIT");
        }
    }
}
