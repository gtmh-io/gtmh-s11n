using GTMH.S11n.TypeResolution;

using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n
{
  public class GTParseArgs : IGTParseArgs
  {
    Dictionary<string, string> m_Value = new Dictionary<string, string>();
    public Dictionary<string, string> Value=> m_Value;

    Stack<string> m_Context = new Stack<string>();
    string m_Prefix = "";

    ITypeResolver m_TypeResolution;

    public GTParseArgs(ITypeResolver a_TypeResolver)
    {
      if ( a_TypeResolver == null ) throw new ArgumentNullException(nameof(a_TypeResolver));
      m_TypeResolution = a_TypeResolver;
    }
    
    public void Add(string a_Key, string a_Value)
    {
      var key = m_Prefix=="" ? a_Key : $"{m_Prefix}.{a_Key}";
      m_Value.Add(key, a_Value);
    }
    struct Context_t : IDisposable
    {
      public Action OnDipose;
      public void Dispose()
      {
        OnDipose();
      }
    }
    public IDisposable Context(string a_Name)
    {
      m_Context.Push(a_Name);
      m_Prefix=string.Join(".", m_Context);
      return new Context_t { OnDipose = () =>
      {
        m_Context.Pop();
        m_Prefix=string.Join(".", m_Context);
      } };
    }

    public void S11nGather(dynamic a_Instance)
    {
      a_Instance.S11nGather(this);
    }

    public string DisolveType(object a_Value) => m_TypeResolution.DisolveType(a_Value);
    
  }
}
