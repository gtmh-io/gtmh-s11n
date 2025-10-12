using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.TypeResolution
{
  public class CurrLoadedAssemblies : ITypeResolver
  {
    public string DisolveType(object a_Value)
    {
      if ( a_Value == null ) return "";
      else return a_Value.GetType().FullName;
    }

    public Type ResolveType(string a_StringValue)
    {
      var rval = Type.GetType(a_StringValue);
      if ( rval != null ) return rval;
      foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        rval = assembly.GetType(a_StringValue);
        if(rval != null) return rval;
      }
      return null;
    }
  }
}
