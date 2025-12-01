using System;
using System.Reflection;
using Uebung01_Library;
namespace Uebung01_AssembliesUndReflection
{
    // Assembly.Load() sucht nach der Assembly, 
    // die im Manifest als Abhängigkeit hinterlegt ist 
    // 1.) zunächst im GAC  
    // 2.) dann im lokalen Verzeichnis
    // -> dabei wird Name + Versionsnummer + Language + public key token berücksichtigt

    // mit Assembly.Load(String) kann nach einer spezifischen Assembly (-> Versnr. )  
    // gesucht werden

    class Uebung01Main
    {
        //static void AppDomainDemo()
        //{
        //    AppDomain currentDomain = AppDomain.CurrentDomain;

        //    AppDomainSetup setup = new AppDomainSetup();
        //    setup.ApplicationBase =
        //        currentDomain.SetupInformation.ApplicationBase + @"newdomainfolder\";

        //    AppDomain newDomain = AppDomain.CreateDomain("NewDomain", null, setup);

        //    Console.WriteLine("Application base of {0}:\r\n\t{1}",
        //        currentDomain.FriendlyName, currentDomain.SetupInformation.ApplicationBase);
        //    Console.WriteLine("Application base of {0}:\r\n\t{1}",
        //        newDomain.FriendlyName, newDomain.SetupInformation.ApplicationBase);
            
        //    newDomain.Load("Uebung01_Library, Version=1.0.0.3, Culture=neutral, PublicKeyToken=41b56b9112d3da09");
        //    // if the domain gets unloaded, all assemblies in this domain 
        //    // get unloaded as well
        //    AppDomain.Unload(newDomain);
        //    //Console.WriteLine("Application base of {0}:\r\n\t{1}",
        //    //    newDomain.FriendlyName, newDomain.SetupInformation.ApplicationBase);
        //}

        static void Main(string[] args)
        {
            System.Console.WriteLine("START");
            // lade Assembly mit Versionsnummer 
            Assembly assembly = Assembly.Load
               ("Uebung01_Library, Version=1.0.0.1, Culture=neutral, PublicKeyToken=70180d67336e7782");
            // lade Assembly ohne Versionsnummer 
            // Assembly assembly = Assembly.Load("Uebung01_Library");
            Type type = assembly.GetType("Uebung01_Library.Utility");
            // dieser cast funktioniert nur, wenn zuvor per Assembly.Load die passende Version
            // der (Strongly Named) Assembly "Uebung01_Library" 
            // aus dem GAC oder dem Verzeichnis der *.exe geladen worden ist
            // Der Datentyp Utility kommt aus der zur Compilezeit als
            // Abhängigkeit bekannten Assembly -> evtl. Konflikt mit der explizit geladenenen Assembly
            Utility utility = (Utility)Activator.CreateInstance(type);
            utility.ShowInfo();
            System.Console.WriteLine("STOP");
        }
    }
}
