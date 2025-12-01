using System;

namespace DelegateDemo
{
    class DelegatesMain 
    {
        // definiere einen Delegate-Typ
        // ein Delegate definiert den Typ einer Methode / Funktion
        // dieses Delegate heisst "Compute" und beschreibt eine Methode,
        // die einen int - Wert zurückgibt und einen Parameter vom Typ int hat
        delegate int Compute(int i);

        static int Square(int i)
        {
            Console.WriteLine("Square called");
            return i * i;
        }
        static int Cube(int i)
        {
            Console.WriteLine("Cube called");
            return i * i * i;
        }
        static void InvokeDelegate(Compute c)
        {
            // Console.WriteLine($"result= {c.Invoke(2)}");
            Console.WriteLine($"result= {c(2)}");
        }
        static void Main(String[] args)
        {
            // Definiere 2 delegate Instanzen
            // Speziell: zwei delegates vom Typ Compute
            // Man sieht:
            // 1. Funktionen können Variablen vom Typ delegate zugewiesen werden

            Compute c1 = Square;
            Compute c2 = Cube;
            InvokeDelegate(c1);
            InvokeDelegate(c2);
            Compute c3 = c1;
            // füge der sog. "InvocationList" des delegates c3
            // ein weiteres delegate zu:
            c3 += c2;
            Console.WriteLine("****");
            InvokeDelegate(c3);
            // entferne das delegate c2 aus der InvocationList von c3
            c3 -= c2;
            Console.WriteLine("****");
            InvokeDelegate(c3);
        }
    }
}
