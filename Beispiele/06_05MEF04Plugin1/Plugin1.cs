using System;

namespace Components
{
    class Plugin1 : CommonTypes.IPlugin
    {
        // neu  : setter-Injection anstelle von Constructor-Injection
        public CommonTypes.IBanner Banner { get; set; }
        public Plugin1() {}
        public string echo(string message)
        {
            string text = "\nEcho from Plugin1 : " + message;
            return Banner != null ? Banner.Print() + text : "no banner " + text;
        }
    }
}
