using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uebung02MEFInterface; 

namespace Uebung02MEFPluginErde
{
    public class Erde : IPlanet
    {
        private double g = 9.81;

        public double CalculateVehicleWeight()
        {
            return vehicle.Mass * g;
        }

        public string Name
        {
            get { return "Erde"; }
        }

        public Erde()
        {
            vehicle = null;
        }

        private IVehicle vehicle;
        public IVehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle=value;
            }
        }
    }
}
