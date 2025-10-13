using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace GTMH.S11n.Reflection;

public class Instantiable
{
  public static IEnumerable<string> Find(string a_AssemblyFile, Type? a_WithInterface)
  {
    if ( a_WithInterface!=null && ! a_WithInterface.IsInterface ) throw new ArgumentException("Expect and test against interface type");
    var ass = Assembly.LoadFrom(a_AssemblyFile);
    foreach(var type in ass.GetTypes())
    {
      if ( type.IsInterface || type.IsAbstract ) continue;
      if ( a_WithInterface != null && !type.GetInterfaces().Contains(a_WithInterface) ) continue;
      // look for matching constructor as proxy
      var c = type.GetConstructors(System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Instance).Where(_=>IsConstructible(_)).SingleOrDefault();
      
      if ( c != null ) yield return type.FullName ?? type.Name; 
    }
  }

  public static bool IsConstructible(ConstructorInfo a_Constructor)
  {
    Func<ParameterInfo[],bool> isMatchSig = parameters=>
    {
      if ( parameters.Length != 1 ) return false;
      return parameters[0].ParameterType.FullName==typeof(IGTInitArgs).FullName; // can't rely on compare capital T type
    };
    return isMatchSig(a_Constructor.GetParameters());
  }

  public static void Visit(string a_AssemblyFile, string a_ClassName, IS11nVisitor a_Visitor)
  {
    var ass = Assembly.LoadFrom(a_AssemblyFile);
    var type = ass.GetTypes().Where(_=>_.FullName==a_ClassName).SingleOrDefault();
    if ( type == null ) throw new ArgumentException("Couldn't find type in assembly");
    var vm = type.GetMethods(BindingFlags.Static|BindingFlags.Public).Where(_=>_.Name=="S11nVisit").Single(); // bork hard
    vm.Invoke(null, new[] { a_Visitor } ); // and again
  }
}
