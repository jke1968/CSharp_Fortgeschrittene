using System.Collections.Generic;
using System.Linq;
using System;

namespace _01_03DelegatesAsParameters
{
    class DelegatesAsParametersMain
    {
        static List<Person> persons = new List<Person>
        { 
            new Person ( "Breitner",3000m ),
            new Person ( "Vogts", 1000m ),
            new Person ( "Overath", 1000m )
        };

        static void PrintElements<T>(List<T> list)
        {
            foreach (T element in list)
            {
                Console.WriteLine(element);
            }
        }

        static void SortBySalary_OldStyle()
        {
            // default Sortierung nach Name
            // persons.Sort();
            persons.Sort(new SalaryComparer());
        }
        static void SortBySalary_NewStyle()
        {
            // übergebe ein anonymes Delegate, 
            // vom Typ Comparison<T>
            // so muss nicht für jeden Aufruf von Sort eine neue Klasse definiert werden
            persons.Sort(delegate (Person p1, Person p2)
            {
                return p1.Salary.CompareTo(p2.Salary);
            });
        }

        static List<Person> FindInList_OldStyle()
        {
            // Suche nach Personen mit Gehalt == 1000
            List<Person> result = new List<Person>();
            foreach (var p in persons)
            {
                if(p.Salary==1000)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        static List<Person> FindInList_NewStyle()
        {
            return persons.FindAll(delegate (Person p) { return p.Salary == 1000; });
        }
        static decimal AggregateSalaries()
        {
            return persons.Aggregate(0m,delegate (decimal sum, Person p) { return sum + p.Salary; });
        }

        static void Main(string[] args)
        {
            SortBySalary_NewStyle();
            System.Console.WriteLine("Sorted persons: ");
            PrintElements(persons);
            FindInList_OldStyle();
            System.Console.WriteLine("Persons with salary 1000 ");
            PrintElements(FindInList_NewStyle());
            Console.WriteLine($"Sum of all salaries: {AggregateSalaries()}");
        }
    }
}
