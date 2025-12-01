using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Uebung01_Library
{
    public class Utility
    {
        private static int level = 0;
        private static HashSet<String> names = new HashSet<String>();
        private void PrintNameAndVersion(Assembly a, int level)
        {
            for (int i = 0; i < level; i++) { Console.Write(" "); }
            Console.WriteLine(
                "Level {0} {1} {2} {3} {4}",
                level,
                a.GetName().Name,
                a.GetName().Version,
                a.CodeBase,
                a.GlobalAssemblyCache
            );
        }
        private void ShowDependencyGraph(AssemblyName uniqueName)
        {
            // Assembly already loaded ?
            if (names.Contains(uniqueName.Name)) { return; }
            names.Add(uniqueName.Name);
            // Assembly has not been loaded yet:
            Assembly a = Assembly.Load(uniqueName);
            PrintNameAndVersion(a, level);
            AssemblyName[] referencedAssemblies = a.GetReferencedAssemblies();
            if (referencedAssemblies.Length!=0 )
            {
                level++;
                foreach (AssemblyName aName in referencedAssemblies)
                { 
                    // call this method recursively
                    ShowDependencyGraph(aName);
                }
            }
        }
        public void ShowInfo()
        {
            ShowDependencyGraph(this.GetType().Assembly.GetName());
        }
    }
}
