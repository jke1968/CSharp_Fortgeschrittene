using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uebung04Events
{
    public class LimitReachedEventArgs : EventArgs
    {
        public readonly decimal currentValue;
        public LimitReachedEventArgs(decimal currentValue)
        {
            this.currentValue = currentValue;
        }

    }
}
