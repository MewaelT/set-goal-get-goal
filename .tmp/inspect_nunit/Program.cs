using System;
using System.Reflection;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: inspect <path-to-dll>");
            return 2;
        }
        var path = args[0];
        try
        {
            var asm = Assembly.LoadFrom(path);
            var t = asm.GetType("NUnit.Framework.Assert");
            if (t == null)
            {
                Console.WriteLine("Type NUnit.Framework.Assert not found");
                return 3;
            }
            Console.WriteLine("Methods on NUnit.Framework.Assert:");
            foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine(m.ToString());
            }
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 1;
        }
    }
}
