using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;

namespace GTMH.S11n.Reflection;

public class Instantiable
{
  public static IEnumerable<string> Find(string a_AssemblyFile, Type? a_WithInterface)
  {
    if ( a_WithInterface!=null && ! a_WithInterface.IsInterface ) throw new ArgumentException("Expect and test against interface type");
    AssemblyLoadContext context = new AssemblyLoadContext(null, true );
    try
    {
      var ass = context.LoadFromAssemblyPath(a_AssemblyFile);
      // look for matching constructor as proxy
      // TODO this should be more robust
      var sig = new Type[] { typeof(IGTInitArgs) };
      foreach(var type in ass.GetTypes())
      {
        if ( type.IsInterface || type.IsAbstract ) continue;
        if ( a_WithInterface != null && !type.GetInterfaces().Contains(a_WithInterface) ) continue;
        var c = type.GetConstructor(sig);
        if ( c != null ) yield return type.FullName ?? type.Name; 
      }
    }
    finally
    {
      context.Unload();
    }
  }
}
