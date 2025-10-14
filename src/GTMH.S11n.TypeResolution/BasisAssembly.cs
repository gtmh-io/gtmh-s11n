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
      if ( m_Basis.Location == null ) throw new ArgumentException($"Assembly '{a_Assembly}' has no location"); // dunno how this could happen
    }

    public string DisolveType(object a_Value)
    {
      if ( a_Value == null ) return "";
      var ty = a_Value.GetType();
      if ( ty.Assembly == m_Basis) return ty.FullName??ty.Name;
      return $"{ty.FullName??ty.Name},{GetRelativePath(ty.Assembly.Location)}";
    }

    public static string GetRelativePath(string a_BasisFile, string a_FileName)
    {
      a_BasisFile = a_BasisFile.Replace("\\", "/");
      a_FileName = a_FileName.Replace("\\", "/");
      if ( a_BasisFile == a_FileName ) return "";
      var basisToks = a_BasisFile.Split('/');
      var fileToks = a_FileName.Split('/');

      var idxTok =0;
      var maxTok = Math.Min(basisToks.Length, fileToks.Length)-1; 
      for( ; idxTok<maxTok; ++idxTok )
      {
        if ( basisToks[idxTok] != fileToks[idxTok] ) break;
      }

      if(idxTok == basisToks.Length - 1)
      {
        // file is rooted under basis tok directory
        return string.Join("/", fileToks.Skip(idxTok));
      }
      else if(idxTok == 0)
      {
        // no common root
        return a_FileName;
      }
      else
      {
        return string.Join("/", Enumerable.Repeat("..", basisToks.Length-idxTok-1).Concat(fileToks.Skip(idxTok)));
      }
    }

    public string GetRelativePath(string a_FileName)
    {
      return GetRelativePath(m_Basis.Location, a_FileName);
    }

    public static string GetAbsolutePath(string a_BasisFile, string a_RelPathFile)
    {
      Func<string,string> mkAbsolute = path=>
      {
        if ( path.Length>1 && path[1]==':') return path;
        else return $"/{path}";
      };
      if ( a_RelPathFile == "" ) return a_BasisFile;
      a_BasisFile = a_BasisFile.Replace("\\", "/");
      a_RelPathFile = a_RelPathFile.Replace("\\", "/");
      // is non-relative path?
      if ( a_RelPathFile.First() == '/' || (a_RelPathFile.Length>1 && a_RelPathFile[1]==':') ) return a_RelPathFile;

      var basisToks = a_BasisFile.Split('/');
      var fileToks = a_RelPathFile.Split('/');
      if(fileToks.Length == 1)
      {
        return mkAbsolute(string.Join("/", basisToks.Reverse().Skip(1).Reverse().Concat(fileToks)));
      }
      var backDirs = fileToks.Count(_=>_=="..");
      return mkAbsolute(string.Join("/", basisToks.Reverse().Skip(1+backDirs).Reverse().Concat(fileToks.Skip(backDirs))));
    }

    public string GetAbsolutePath(string a_FileName)
    {
      if ( a_FileName == "" ) return m_Basis.Location;
      var basisDir = System.IO.Path.GetDirectoryName(m_Basis.Location);
      if ( basisDir==null ) return a_FileName;
      return System.IO.Path.Combine(basisDir, a_FileName).Replace("\\", "/");
    }

    public Type ResolveType(string a_StringValue)
    {
      var idx = a_StringValue.IndexOf(',');
      if ( idx == -1 ) return m_Default.ResolveType(a_StringValue);
      var assembly = a_StringValue.Substring(idx+1).Trim();
      var cls = a_StringValue.Substring(0, idx);
      var rval = m_Default.ResolveType(cls);
      if ( rval != null ) return rval;
      var loader= new Loader();
      var ass = loader.Load(GetAbsolutePath(assembly));
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
        AppDomain.CurrentDomain.AssemblyResolve += ResolveFromCurrentContext;
        try
        {
          return Assembly.LoadFrom(assemblyPath);
        }
        finally
        {
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
