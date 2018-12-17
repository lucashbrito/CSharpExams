using System;
using System.Reflection;

namespace Chapter3
{
    public class DebugSymbol
    {
        public void DebugDirective()
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Not debug");
#endif
        }

        public void UseCustomSymbol()
        {
#if MySymbol
Console.WriteLine("Custom symbol is defined");
#endif
        }
    }

    public class Assemblies<T>
    {
        public Assembly LoadAssembly<T>()
        {
#if !WINRT
            Assembly assembly = typeof(T).Assembly;
#else
Assembly assembly = typeof(T).GetTypeInfo().Assembly;
#endif
            return assembly;
        }
    }
}
