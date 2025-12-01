using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uebung02MEFInterface;

namespace Uebung02MEFFahrzeug1
{
    public class Rover : IVehicle
    {
        private double mass;

        public string Name
        {
            get { return "Rover"; }
        }

        public double Mass
        {
            get { return mass; }
        }

        public Rover()
        {
            mass = 100;
        }
    }
}
