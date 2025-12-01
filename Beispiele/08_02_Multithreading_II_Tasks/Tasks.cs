namespace _08_02_Multithreading_II_Tasks
{
    internal class Tasks
    {
        static int Print(char c)
        {
            Console.WriteLine($"enter Print on {Thread.CurrentThread.Name}");
            int i = 0;
            for (; i < 10; i++)
            {
                // lasse den aktuellen Thread 1000 ms warten
                Console.WriteLine($"Print c={c} on Thread {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"exit Print on {Thread.CurrentThread.Name}");
            return i;
        }


        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine($"enter Main on {Thread.CurrentThread.Name}");
            // verwende ein Task Objekt, um die Methode Print auf einem separaten Thread auszuführen
            Task<int> task = Task.Run(() => Print('x'));


            Console.WriteLine("Waiting for Task to complete...");
            // der Main wird beim Abfragen des Results der Task solange blockiert, 
            // bis die Methode der Task zurückkehrt
            int result = task.Result;
            // Falls die Task eine void Methode startet:
            // task.Wait();
            Console.WriteLine($"result = {result}");
            Console.WriteLine($"exit Main on {Thread.CurrentThread.Name}");
        }
    }
}
