namespace Library
{
    public class Plugin2 : CommonTypes.IPlugin
    {
        public string Echo(string message)
        {
            return "echo from CSharp Plugin2 : "+message;
        }
    }
}
