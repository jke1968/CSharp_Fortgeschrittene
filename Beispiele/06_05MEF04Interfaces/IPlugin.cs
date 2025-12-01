using System;

namespace CommonTypes
{
    // gemeinsames Interface für Hostprogramm und Komponenten
    public interface IPlugin
    {
        // Property-Injection des Banners
        IBanner Banner { get; set; }
        String echo(String message);
    }
}
