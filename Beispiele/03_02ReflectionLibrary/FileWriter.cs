using System;

namespace Library

{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine("Writing to file : {0}",message);
        }
    }
}
