using CommonTypes;

namespace Components
{
    class Plugin2 : IPlugin
    {
        // neu  : setter-Injection anstelle von Constructor-Injection
        public IBanner Banner { get; set; }

        public Plugin2()
        {

        }

        public string echo(string message)
        {
            string text = "\nEcho from Plugin2 : " + message;
            return Banner != null ? Banner.Print() + text : "no banner " + text;
        }
    }
}