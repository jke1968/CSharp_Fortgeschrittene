using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace DelegateAndEventDemo
{
    class DelegatesAsEventsMain
    {
        static void Main(String[] args)
        {
            Observable observable = new Observable();
            Observer observer1 = new Observer("observer1");
            Observer observer2 = new Observer("observer2");
            // registriere beide Observer beim Observable
            observable.ValueChanged += observer1.ObservableChanged;
            observable.ValueChanged += observer2.ObservableChanged;
            // ändere den Zustand des Observables
            observable.Value = 1;
            observable.Value = 2;
            // diese Zeile sollte nicht compiliert werden,
            // events sollten immer nur aus der Klasse selbst ausgelöst werden
            // wenn ValueChanges ein event ist, dann ist folgendes nicht mehr möglich
            //observable.ValueChanged(new object(), new EventArgs());
            // ausserdem geht nicht:
            // überschreiben der InvocationList
            // observable.ValueChanged = observer1.ObservableChanged;
            // und:
            // löschen der InvocationList
            // observable.ValueChanged = null;

            // -> Events sind also spezielle delegates mit eingeschränkter Funktionalität (s.o.)
        }
    }
}
