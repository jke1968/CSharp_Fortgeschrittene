using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung02MEFInterface
{
    public interface IPlanet
    {
        double CalculateVehicleWeight();
        String Name { get; }
        IVehicle Vehicle { get;  set; }
    }
}
