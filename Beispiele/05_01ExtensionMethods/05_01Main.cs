using System;

namespace _05_01ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "A1B2C3";
            Console.WriteLine($"Anzahl der Ziffern in {s} : {s.NoOfNumbers()}");
        }
    }
}
