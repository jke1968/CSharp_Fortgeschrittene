using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateAndEventDemo
{
    class Observer
    {
        public string Name { get; set; }
        public Observer(string name)
        {
            Name = name;
        }
        public void ObservableChanged(object sender, ValueChangedEventArgs e)
        {
            Console.WriteLine($"Observer {Name} reports observable changed from {e.OldValue} to {e.NewValue}");
        }
    }
}

