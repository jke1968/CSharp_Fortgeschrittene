namespace Uebung05_01_Tasks
{
    internal class Uebung05
    {

        static int Counter(int limit, ref bool stopped)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                if(stopped)
                {
                    break;
                }
                sum += i;
                Console.WriteLine($"Counter on Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            bool stopFlag1 = false;
            bool stopFlag2 = false;
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine($"enter Main on {Thread.CurrentThread.Name}");
            Task<int> t1 = Task.Run(() => Counter(10, ref stopFlag1));
            Task<int> t2 = Task.Run(() => Counter(10, ref stopFlag2));

            Console.WriteLine("Waiting...");
            Thread.Sleep(3000);
            stopFlag1 = true;
            Console.WriteLine($"Task1 returned {t1.Result}");
            Console.WriteLine("Waiting for task2 to return... ");
            Console.WriteLine($"Task2 returned {t2.Result}");
            Console.WriteLine($"exit Main on {Thread.CurrentThread.Name}");
        }
    }
}
