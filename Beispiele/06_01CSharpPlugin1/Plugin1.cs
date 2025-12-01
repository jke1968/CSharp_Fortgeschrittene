namespace Library
{
    public class Plugin1 : CommonTypes.IPlugin
    {
        public string Echo(string message)
        {
            return "echo from CSharp Plugin1 : "+message;
        }

    }
}
