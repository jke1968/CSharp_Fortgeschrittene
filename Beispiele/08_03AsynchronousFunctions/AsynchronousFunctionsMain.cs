using System;
using System.Threading;
using System.Threading.Tasks;

namespace _08_03AsynchronousFunctions
{
    class AsynchronousFunctionsMain
    {
        static async void DoWork()
        {
            Console.WriteLine("Start DoWork on thread {0}", Thread.CurrentThread.ManagedThreadId);
            // await heisst : warte nicht-blockierend, 
            // d.h. kehre sofort zum Aufrufer zurück
            await Task.Run(() => {
                Console.WriteLine("Working on thread {0}", Thread.CurrentThread.ManagedThreadId);
                for (int i=0; i<Int32.MaxValue; i++) {};
            });
            // nur in Konsolenanwendungen: der Rest der asynchronen Funktion 
            // wird auf dem Thread der Task ausgeführt,
            // da kein Synchronization-Context in Konsolenanwendungen existiert
            // -> in GUI-Anwendungen wird die nächste Zeile (wieder) auf dem GUI Thread ausgeführt
            Console.WriteLine("Done on thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main on thread {0}",Thread.CurrentThread.ManagedThreadId);
            DoWork();
            Console.WriteLine("Continuing on thread {0} ", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(7000);
            Console.WriteLine("Exit Main on thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
