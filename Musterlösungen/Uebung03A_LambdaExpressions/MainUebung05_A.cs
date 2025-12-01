using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung04_LambdaExpressions
{
    class MainUebung05_A
    {

        static int CompareToNull(string? s1, string? s2)
        {
            if (s1==null&&s2==null)
            {
                return 0;
            } 
            if (s1==null)
            {
                return -1;
            } 
            if (s2==null)
            {
                return 1;
            } 
            return s1.CompareTo(s2);
        }

        static void Main(string[] args)
        {
            List<Artikel> list = new List<Artikel>();
            list.Add(new Artikel(102, "Schraube", 0.35m));
            list.Add(new Artikel(100, null, 0.35m));
            list.Add(new Artikel(101, "Schraube", 0.15m));
            Console.WriteLine("*** Artikelliste");
            list.ForEach(a => Console.WriteLine(a));
            // list.Sort((a1, a2) => a1.Name.CompareTo(a2.Name));
            list.Sort((a1, a2) => CompareToNull (a1.Name,a2.Name));
            Console.WriteLine("*** Artikelliste sortiert nach Name");
            list.ForEach(a => Console.WriteLine(a));
            Console.WriteLine("*** Artikel mit Nr = 100");
            Console.WriteLine(list.Find(a => a.Nr == 100));
            Console.WriteLine("*** Alle Artikel namens Schraube");
            List<Artikel> found = list.FindAll(a => a.Name=="Schraube");
            found.ForEach(a => Console.WriteLine(a));
            Console.Write("*** Summe der Preise: ");
            Console.WriteLine(list.Aggregate(0m, (sum, a2) => sum + a2.Preis));
            // Console.WriteLine("*** Alle Namen existieren ? "+list.TrueForAll(a => a.Name != null));
            Console.WriteLine("*** Alle Artikel mit Namen");
            found = list.FindAll(a => a.Name != null);
            found.ForEach(a => Console.WriteLine(a));

        }
    }
}
