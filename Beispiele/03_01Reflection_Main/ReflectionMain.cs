using Library;
using System.Reflection;


namespace _01_02Reflection
{
    class ReflectionMain
    {
        static void InspectAssembly(Assembly a)
        {
            Console.WriteLine($"Inspecting Assembly {a.GetName()}");
            Console.WriteLine($"Loaded from: {a.Location}");
            // Betrachte alle Datentypen in dieser Assembly:
            foreach (Type t in a.GetTypes())
            {
                Console.WriteLine($"Found {t.Name}");
                foreach(MethodInfo m in t.GetMethods())
                {
                    Console.WriteLine($"  Found {m.Name}");
                    foreach (ParameterInfo p in m.GetParameters())
                    {
                        Console.WriteLine($"    Found {p.Name} {p.ParameterType}");
                    }
                }
            }
        }

        static void PrimitiveFactoryPattern(String arg)
        {
            IWriter? writer = null;
            // Primitives Factory Pattern
            if (arg == "Library.NetworkWriter")
            {
                writer = new FileWriter();
            }
            else
            {
                writer = new NetworkWriter();
            }
            writer.Write("Hello");

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter Main defined in Assembly "+Assembly.GetExecutingAssembly());
            try
            {
                // Ziel: instanziiere ein Objket einer Klasse, deren Namen zur Compilezeit nicht bekannt ist
                // Schritt 1 : lade die Assembly mit den potentiellen Datentypen
                Assembly loadedAssembly = Assembly.Load("03_02ReflectionLibrary");
                Console.WriteLine("Assembly with types loaded");
                // Schritt 2 : lade den gewünschten  Typ aus der Assembly
                String typeToLoad = args[0];
                // Der Typ Type ist Teil des Reflection APIs von .NET
                Type? writerType = loadedAssembly.GetType(typeToLoad);
                if(writerType!=null)
                {
                    // Schritt 3: erzeuge ein Objekt aus dem "Type" Objekt
                    // Activator ist ebenfalls Teil des Reflection - APIs
                    IWriter? writer = (IWriter?)Activator.CreateInstance(writerType);
                    if(writer!=null)
                    {
                        writer.Write("Hello");
                    } 
                    else
                    {
                        Console.WriteLine($"Could not create IWriter object from {writerType}");
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot instantiate type from {typeToLoad}");
                }
                InspectAssembly( loadedAssembly );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Exit Main defined in Assembly " + Assembly.GetExecutingAssembly());
        }
    }
}
