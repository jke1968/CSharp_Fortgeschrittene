using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace _05_02XML2LINQ
{
    class XML2LINQMain
    {
        static void PrintPerson(XElement e)
        {
            // Gib den Elementinhalt und den Inhalt des Attributs salary aus
            Console.WriteLine("{0,-10} {1}", e.Value, e.Attribute("salary").Value);
        }
        static IEnumerable<XElement> GetPersonElements()
        {
            // der XMLReader ist ein sog. pull-parser
            // -> liest die XML Datei zeilenweise ein
            // -> performanter als XElement.Load() bei großen XML-Dateien
            using (XmlReader reader = XmlReader.Create(@"persons.xml"))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        // überprüfe jeden Element-Node des XML Files
                        case XmlNodeType.Element:
                            if (reader.Name == "person")
                            {
                                Console.WriteLine("<person> element read");
                                XElement el = XElement.ReadFrom(reader) as XElement;
                                if (el != null)
                                    yield return el; // jump back into calling function, while preserving state
                            }
                            break;
                    }
                }
            } // call reader.Dispose() here
        }
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            // Lese XML 
            // Variante I : mit XElement.Load
            //XElement persons = XElement.Load(@"persons.xml");
            //Console.WriteLine("XML Datei gelesen");
            //persons.Elements()
            //    .Where(xelement => xelement.Attribute("salary").Value.Equals("1000"))
            //    .OrderByDescending(xelement => xelement.Value)
            //    .ToList()
            //    .ForEach(xelement => Console.WriteLine("name: " + xelement.Value + " salary: " + xelement.Attribute("salary").Value));



            // Variante II : mit XMLReader +yield
            foreach (XElement element in GetPersonElements())
            {
                PrintPerson(element);
            }

            Console.WriteLine("exit");
        }

    }
}
