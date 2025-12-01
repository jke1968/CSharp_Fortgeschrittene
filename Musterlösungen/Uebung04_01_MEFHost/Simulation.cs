using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using Uebung02MEFInterface;

namespace Uebung02MEFHost
{
    class Simulation
    {
        private ComposablePartCatalog planetCatalog = null;
        private ComposablePartCatalog vehicleCatalog = null;

        private CompositionContainer compositionContainer = null;
        private RegistrationBuilder registrationBuilder = null;

        private IEnumerable<IPlanet> planets = null;
        private IVehicle vehicle = null;

        public Simulation()
        {
            registrationBuilder = new RegistrationBuilder();
            registrationBuilder
                .ForTypesDerivedFrom<IPlanet>()
                .Export<IPlanet>();
            registrationBuilder
                .ForTypesDerivedFrom<IVehicle>()
                .Export<IVehicle>();

            planetCatalog = new DirectoryCatalog(@"..\..\planets", registrationBuilder);
            vehicleCatalog = new DirectoryCatalog(@"..\..\vehicles", registrationBuilder);
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(planetCatalog);
            catalog.Catalogs.Add(vehicleCatalog);
            compositionContainer = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
        }

        public void Start()
        {
            Console.WriteLine(Enumerable.Count(planets)+" Planeten gefunden ");    
            foreach (IPlanet p in planets)
            {
                Console.WriteLine
                    ("On Planet {0} with vehicle {1} weight {2} N",p.Name,p.Vehicle.Name,p.CalculateVehicleWeight());
            }
        }
        private void DoComposition()
        {
            planets = compositionContainer.GetExportedValues<IPlanet>();
            vehicle = compositionContainer.GetExportedValue<IVehicle>();
            // Auf allen Planeten wird mit dem gleichen Fahrzeug gefahren
            foreach (IPlanet planet in planets)
            {
                // Property Injection
                planet.Vehicle = vehicle;
            }
        }
        static void Main(string[] args)
        {
            var simulation = new Simulation();
            simulation.DoComposition();
            simulation.Start();
        }
    }
}
