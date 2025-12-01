using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung04Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Observing share ... ");
            Share share = new Share();
            share.Limit = 500;
            ShareObserver observer = new ShareObserver();
            // register Observer object with Observable
            share.LimitReached += observer.PrintWarning;
            for (int i = 0; i < 3; i++)
            {
                share.Value += 222;
                Console.WriteLine("Value : "+share.Value);
            }
        }
    }
}
