using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung04Events
{
    class ShareObserver
    {
        public ShareObserver()
        {

        }
        public void PrintWarning(object sender, LimitReachedEventArgs args)
        {
            Console.WriteLine("Observer : limit reached at "+args.currentValue);
        }
    }
}
