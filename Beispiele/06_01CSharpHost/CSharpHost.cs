using System;
using System.Reflection;

namespace Host
{
    // demonstriert das DI Prinzip zunächst noch ohne MEF
    class CSharpHost
    {
        static void Main(string[] args)
        {
            // erfordert eine (VS) reference auf das IPlugin-Projekt
            // reference bedeutet:
            // 1. Der Compiler sucht im angegebenen Verzeichnis nach der Assembly
            // 2. die Assembly (also die dll) wird beim build in das target Verzeichnis
            // des Projekts kopiert
            CommonTypes.IPlugin plugin;
            try
            {
                // DI steht hier für "Dependency Injection"
                // DI initialisieren:
                MyDIContainer container = new MyDIContainer();
                // Konkretes Plugin-Objekt vom DI-Container beziehen
                plugin = container.createPlugin();
                if (plugin != null)
                {
                    // diese nächste Zeile möchte man nicht schreiben:
                    // plugin = new Plugin1();
                    Console.WriteLine(plugin.Echo("Hello"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name+" caught : "+e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
