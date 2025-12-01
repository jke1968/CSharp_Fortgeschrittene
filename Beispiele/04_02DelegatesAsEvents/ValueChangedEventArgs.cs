using System;

namespace DelegateAndEventDemo
{
    public class ValueChangedEventArgs : EventArgs
    {
        private int oldValue;
        private int newValue;

        public ValueChangedEventArgs(int oldValue, int newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public int OldValue { get { return oldValue; }  }
        public int NewValue { get { return newValue; } }
    }
}