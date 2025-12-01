using System;

// für ngen Installation:
// in ProjectProperties->Build Events->"Post Build Events Command Line" eintragen:
// %WINDIR%\Microsoft.Net\Framework\v4.0.30319\ngen.exe install "$(TargetPath)" 

namespace _01_01Assemblies
{
    class AssembliesMain
    {      
        static void PrintMessage()
        {
            System.Console.WriteLine
            (
                "Process: {0}",System.Diagnostics.Process.GetCurrentProcess()

            );   
        }
        static void Main(string[] args)
        {  
            if (args[0] == "1")
            {
                PrintMessage();
            }
            ;
        }
    }
}