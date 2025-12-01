using System.Linq;

namespace _05_01ExtensionMethods
{
    static class ExtensionMethods
    {
        // Definiere eine Extension Method für die Klasse string
        // d.h. NoOFNumbers kann für jedes Objekt vom Typ String aufgerufen werden
        // etwas allgemeiner:
        // eine ExtensionMethod kann für alle Objekte des rechts neben "this"
        // genannten Typs aufgerufen werden
        public static int NoOfNumbers(this string s)
        {
            // verwende die Extension Method "Count" (aus der Klasse "Enumerable")
            // die hier für ein Objekt des Typs String angewandt wird,
            // was funktioniert, weil die Klasse String das Interface "IEnumerable<char>"
            // implementiert
            return s.Count( c => char.IsNumber(c));
        }
    }
}
