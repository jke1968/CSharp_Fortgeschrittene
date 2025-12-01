using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class MyDIContainer
    {
        public String PluginTypeName { get; set; }
        public String PluginAssemblyFileName { get; set; }

        public MyDIContainer()
        {
            PluginTypeName = "Library.Plugin2";
            PluginAssemblyFileName = "CSharpPlugin2.dll";
        }

        public IPlugin createPlugin()
        {
            // 1. Lade die Assembly von ihrem Speicherort
            Assembly assembly = Assembly.LoadFrom(PluginAssemblyFileName);
            string concreteType = PluginTypeName;
            // 2. bestimme den konkreten Datentyp aus der Assembly
            Type type = assembly.GetType(concreteType);
            if (type == null)
            {
                throw new Exception("MyDIContainer : Cannot create object for unknown type " + concreteType);
            }
            // 3. instanziiere gewünschtes Objekt
            Object o = Activator.CreateInstance(type);
            return (IPlugin)o;
        }
    }
}
