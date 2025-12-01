using CommonTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Reflection;

// neu: Property Injection
namespace Host
{
    class MEF04Host : IDisposable
    {
        private IEnumerable<IPlugin> plugins = null;
        private IEnumerable<IBanner> banners = null;

        private ComposablePartCatalog partCatalog = null;
        private CompositionContainer compositionContainer = null;
        private RegistrationBuilder registrationBuilder = null;

        public MEF04Host()
        {

            registrationBuilder = new RegistrationBuilder();
            registrationBuilder
                .ForTypesDerivedFrom<IPlugin>()
                .Export<IPlugin>();
            // neu: kein besonderer ctor-Aufruf mehr, sodnern default-Konstruktor
            registrationBuilder
                .ForTypesDerivedFrom<IBanner>()
                .Export<IBanner>();

            partCatalog = new DirectoryCatalog(@"..\..\Plugins", registrationBuilder);
            compositionContainer = new CompositionContainer(partCatalog, CompositionOptions.DisableSilentRejection);


        }
        public void DoComposition()
        {
            try
            {
                plugins = compositionContainer.GetExportedValues<IPlugin>(); 
                banners = compositionContainer.GetExportedValues<IBanner>();
                // wenn gewünscht, verknüpfe Plugin Objekt mit Banner Objekt per "setter injection" / "property injection"
                foreach (IPlugin plugin in plugins)
                {
                    // plugin.Banner = compositionContainer.GetExportedValueOrDefault<IBanner>();
                    plugin.Banner = banners.First();
                }

            }
            catch (ReflectionTypeLoadException e)
            {
                Console.WriteLine("Caught ReflectionTypeLoadException " + e.Message);
                foreach (Exception ex in e.LoaderExceptions)
                {
                    Console.WriteLine("LoaderException\n" + ex.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught  " + e.GetType().Name + " " + e.Message);
            }
        }
        public void ListObjects()
        {
            if (banners != null)
            {
                Console.WriteLine("Found " + Enumerable.Count(banners) + " banners");
                foreach (IBanner banner in banners)
                {
                    Console.WriteLine(banner.GetType().ToString());
                }
            }
            else
            {
                Console.WriteLine("No banners found");
            }

            if (plugins != null)
            {
                Console.WriteLine("Found " + Enumerable.Count(plugins) + " plugins");
                foreach (IPlugin plugin in plugins)
                {
                    Console.WriteLine(plugin.echo("Hello"));
                }
            }
            else
            {
                Console.WriteLine("No plugins found");
            }
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing ...");
            this.compositionContainer.Dispose();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MEF04");
            MEF04Host p = new MEF04Host();
            p.DoComposition();
            p.ListObjects();
            p.Dispose();
        }

    }
}
