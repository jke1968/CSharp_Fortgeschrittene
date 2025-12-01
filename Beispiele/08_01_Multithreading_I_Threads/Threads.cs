namespace _08_01_Multithreading_I_Threads
{
    internal class Threads
    {
        static void Print(char c, int waitTime)
        {
            Console.WriteLine($"enter Print on {Thread.CurrentThread.Name}");
            for (int i = 0; i < 10; i++)
            {
                // lasse den aktuellen Thread 1000 ms warten
                Console.WriteLine($"Print c={c} on Thread {Thread.CurrentThread.Name}");
                Thread.Sleep(waitTime);
            }
            Console.WriteLine($"exit Print on {Thread.CurrentThread.Name}");
        }


        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine($"enter Main on {Thread.CurrentThread.Name}");
            Thread t1 = new Thread(() => Print('x',500));
            t1.Name = "Thread1";
            Thread t2 = new Thread(() => Print('y',1000));
            t2.Name = "Thread2";
            t1.Start(); // startet die Methode, die mit diesem Thread verknüpft ist
            t2.Start();
            Console.WriteLine("Waiting for t1 to end ...");
            t1.Join(); // blockiert den aktuellen Thread solange, bis die Methode von t1 zurückkehrt
            Console.WriteLine("Waiting for t2 to end ...");
            t2.Join(); // s.o.
            Console.WriteLine($"exit Main on {Thread.CurrentThread.Name}");
        }
    }
}
