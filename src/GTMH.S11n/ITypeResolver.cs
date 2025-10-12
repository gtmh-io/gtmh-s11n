using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n
{
  public interface ITypeResolver
  {
    string DisolveType(object a_Value);
    Type ResolveType(string a_StringValue);
  }
}
