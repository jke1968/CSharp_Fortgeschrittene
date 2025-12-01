using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Uebung05_LINQ
{
    class Uebung03LINQ
    {
        // handle <telefon> elements
        private static void printTelefon(XElement telefon)
        {
            Console.Write("  "+telefon.Element("land").Value);
            Console.Write("-" + telefon.Element("stadt").Value);
            Console.Write("-" + telefon.Element("nummer").Value);
            Console.Write(" ("+telefon.Attribute("type").Value+")");
            Console.WriteLine();
        }
        // handle <addresse> elements
        static void printAdresse(XElement adresse)
        {
            Console.Write(adresse.Element("name").Element("vorname").Value+" ");
            Console.WriteLine(adresse.Element("name").Element("nachname").Value);
            adresse
                .Elements()
                .Where( e => e.Name == "telefon")
                .ToList()
                .ForEach(e => printTelefon(e));
        }
        static void Main(string[] args)
        {
            XElement adressen = XElement.Load(@"adressen.xml");
            // get all <addresse> elements and sort them by <nachname>
            adressen
                .Elements()
                .OrderBy(e => e.Element("name").Element("nachname").Value)
                .ToList()
                .ForEach(e => printAdresse(e));
        }
    }
}