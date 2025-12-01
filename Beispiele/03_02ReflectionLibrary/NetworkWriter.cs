namespace Library
{
    public class NetworkWriter : IWriter
    {
        private void f(string message)
        {
            System.Console.WriteLine("method f called with message= {0}",message);
        }
        public void Write(string message)
        {
            System.Console.WriteLine("Writing to network : {0}",message);
        }
    }
}
