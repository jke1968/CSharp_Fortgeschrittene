using System;

namespace Uebung04Events
{
    class Share 
    {
        public decimal Limit { get; set; }
        public event EventHandler<LimitReachedEventArgs> LimitReached;
        protected virtual void OnLimitReached(LimitReachedEventArgs e)
        {
            LimitReached?.Invoke(this, e);
        }
        decimal value;
        public decimal Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                if ( this.value > Limit )
                {
                    OnLimitReached(new LimitReachedEventArgs(this.value));
                }
            }
        }
    }
}
