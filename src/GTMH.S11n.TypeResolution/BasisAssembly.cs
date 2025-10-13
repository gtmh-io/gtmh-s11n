using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GTMH.S11n.TypeResolution
{
  public class BasisAssembly : ITypeResolver
  {
    ITypeResolver m_Default = new CurrLoadedAssemblies();
    private Assembly m_Basis;
    public BasisAssembly(string a_Assembly)
    {
      if ( a_Assembly==null ) throw new ArgumentNullException(nameof(a_Assembly));
      var loader= new Loader();
      m_Basis = loader.Load(a_Assembly);
    }

    public string DisolveType(object a_Value)
    {
      if ( a_Value == null ) return "";
      var ty = a_Value.GetType();
      if ( ty.Assembly == m_Basis) return ty.FullName??ty.Name;
      return $"{ty.FullName??ty.Name},{GetRelative(ty.Assembly.Location)}";
    }

    private string GetRelative(string a_FileName)
    {
      return a_FileName;
    }

    private string GetAbsolute(string a_Path)
    {
      if ( a_Path == "" ) return m_Basis.Location;
      return a_Path;
    }

    public Type ResolveType(string a_StringValue)
    {
      var idx = a_StringValue.IndexOf(',');
      if ( idx == -1 ) return m_Default.ResolveType(a_StringValue);
      var assembly = a_StringValue.Substring(idx+1).Trim();
      var cls = a_StringValue.Substring(0, idx);
      var rval = m_Default.ResolveType(cls);
      //if ( rval != null ) return rval;
      var loader= new Loader();
      var ass = loader.Load(GetAbsolute(assembly));
      rval = ass.GetTypes().Where(_=>_.FullName==cls).SingleOrDefault();
      if ( rval == null ) throw new S11nException($"Failed load '{cls}' from '{assembly}'");
      return rval;
    }
    public class Loader
    {
      private readonly Dictionary<string, Assembly> _currentAssemblies;
      public Loader()
      {
        // Cache current loaded assemblies
        _currentAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic)
            .ToDictionary(a => a.GetName().Name, a => a);
      }

      public Assembly Load(string assemblyPath)
      {
        // Subscribe to resolve event
        AppDomain.CurrentDomain.AssemblyResolve += ResolveFromCurrentContext;

        try
        {
          // Load the assembly
          return Assembly.LoadFrom(assemblyPath);
        }
        finally
        {
          // Unsubscribe to prevent memory leaks
          AppDomain.CurrentDomain.AssemblyResolve -= ResolveFromCurrentContext;
        }
      }

      private Assembly ResolveFromCurrentContext(object sender, ResolveEventArgs args)
      {
        var assemblyName = new AssemblyName(args.Name);

        // First try exact match from current context
        if(_currentAssemblies.TryGetValue(assemblyName.Name, out var assembly))
        {
          return assembly;
        }

        // Try to find in currently loaded assemblies
        return AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == assemblyName.Name);
      }
    }
  }
}
