using System;
using System.Collections.Generic;
using System.Linq;
namespace Uebung12_LINQ
{
    class Program
    {
        static IEnumerable<int> ParseString(string s)
        {
            if (int.TryParse(s, out int result))
            {
                return new[] { result };
            }
            else
            {
                return Enumerable.Empty<int>();
            }
        }
        static void DemoLazyEvaluation()
        {
            List<int> numbers = new List<int>() { 1, 2, 3 };
            // define an expression that is to be evaluated at a later point in time
            IEnumerable<int> result = numbers.Where(a => a > 0);
            numbers.Add(4);
            // only now the expression in result is evaluated by reading from the variable numnbers
            // -> "lazy evaluation"
            result.ToList().ForEach(nr => System.Console.WriteLine(nr));
        }

        static void Main()
        {
            DemoLazyEvaluation();

            List<Employee> employees = new List<Employee>
            {
                new Employee("Vogts", 1000m, "Sales"),
                new Employee("Overath", 2000m, "Development"),
                new Employee("Breitner", 3000m, "Development"),
                new Employee("Beckenbauer",4000m,"Sales")
            };
            System.Console.WriteLine("-- Alle Angestellten");
            employees
                .ForEach(e => System.Console.WriteLine(e));
            System.Console.WriteLine("-- Alle Angestellten namens Breitner");
            employees
                .Where(e => e.Name == "Breitner")
                .ToList()
                .ForEach(e => System.Console.WriteLine(e));
            System.Console.WriteLine("-- Angestellte aus der Abteilung Development, sortiert nach Namen");
            employees
                .Where(e => e.Department == "Development")
                .OrderBy(e => e.Name)
                .ToList()
                .ForEach(e => System.Console.WriteLine(e));
            System.Console.WriteLine("-- Die Namen aller Mitarbeiter der Abteilung Sales");
            employees
                .Where(e => e.Department == "Sales")
                .Select(e => e.Name)
                .ToList()
                .ForEach(s => System.Console.WriteLine(s));
            System.Console.WriteLine("-- Die Summe aller Gehälter aus der Abteilung Sales");
            decimal? sum = employees
                .Where(e => e.Department == "Marketing")
                .Sum(e => e.Salary);
            if(sum==null) {
                Console.WriteLine("Cannot calculate sum");
            } 
            else
            {
                Console.WriteLine("sum = " + sum);
            }
            System.Console.WriteLine("-- Die Namen aller Mitarbeiter gruppiert nach Abteilung");
            employees
                .GroupBy(e => e.Department, e => e.Name)
                .ToList()
                .ForEach(grouping =>
                {
                    System.Console.WriteLine(grouping.Key);
                    grouping.ToList().ForEach(name => System.Console.WriteLine("  " + name));
                });

            System.Console.WriteLine("-- Angestellte aus der Abteilung Production, sortiert nach Namen");
            employees
                .Where(e => e.Department == "Production")
                .OrderBy(e => e.Name)
                .ToList()
                .ForEach(e => System.Console.WriteLine(e));

            //List<string> strings = new List<string>() { "1", "", "3" };

            //strings
            //    .Where(s => s.Count(char.IsDigit) == s.Count())
            //    .Select(s => int.Parse(s))
            //    .ToList()
            //    .ForEach(e => System.Console.WriteLine(e));

            //sum = strings
            //            .Where(s => s.All(char.IsDigit))
            //            .Where(s => s.Length != 0)
            //            .Select(s => int.Parse(s))
            //            .Sum();
            //System.Console.WriteLine("sum= " + sum);


        }
    }
}