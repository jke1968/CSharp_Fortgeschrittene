using System;
namespace DelegateAndEventDemo
{
    class Observable
    {
        // the state of this Observable 
        private int value;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;
        public int Value {
            get
            {
                return value;
            }
            set
            {
                if (value != this.value)
                {
                    // Der Zustand des Observables hat sich geändert
                    OnValueChanged(new ValueChangedEventArgs(this.value,value));
                    this.value = value;
                }
            }     
        }

        private void OnValueChanged(ValueChangedEventArgs eventArgs)
        {
            // informiere alle registrierten Observer über die Änderung
            // indem die InvocationList des delegates aufgerufen wird
            ValueChanged?.Invoke(this, eventArgs);
            // ? ist der sog. "Elvis operator"
            // der Compiler erzeugt aus dem obigen Ausdruck folgenden Code:
            //var _valueChanged = ValueChanged;
            //if (_valueChanged != null)
            //{
            //    _valueChanged.Invoke(this, eventArgs);
            //}

        }
    }
}
