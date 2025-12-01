
namespace _08_03Locks
{
    internal class Locks
    {

        private static bool printed = false;
        private static Object my_lock = new Object();

        private static void PrintOnce()
        {
            { // Start der "critical section"
                lock (my_lock) // nur ein Thread kann Eigentümer des Locks sein
                if(!printed)
                {
                    Console.WriteLine("Once");
                    printed = true;
                }
            } // Ende der "critical section"
        }

        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => PrintOnce());
            Task t2 = Task.Run(() => PrintOnce());
            t1.Wait();
            t2.Wait();
        }

    }
}
