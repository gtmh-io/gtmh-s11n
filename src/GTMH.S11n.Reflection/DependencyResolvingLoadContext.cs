using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace GTMH.S11n.Reflection;

public class DependencyResolvingLoadContext : AssemblyLoadContext
{
  private readonly AssemblyDependencyResolver _resolver;
  private readonly string _mainAssemblyPath;
  private readonly Dictionary<string, string> _assemblyPaths;

  public DependencyResolvingLoadContext(string mainAssemblyPath) : base(isCollectible: true)
  {
    _mainAssemblyPath = mainAssemblyPath;
    _resolver = new AssemblyDependencyResolver(mainAssemblyPath);

    // Build a dictionary of available assemblies in the same directory
    _assemblyPaths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    string directory = Path.GetDirectoryName(mainAssemblyPath)!;

    foreach(string dll in Directory.GetFiles(directory, "*.dll"))
    {
      string assemblyName = Path.GetFileNameWithoutExtension(dll);
      _assemblyPaths[assemblyName] = dll;
    }
  }

  protected override Assembly? Load(AssemblyName assemblyName)
  {
    // First try the built-in resolver
    string? assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
    if(assemblyPath != null)
    {
      return LoadFromAssemblyPath(assemblyPath);
    }

    // Then try our dictionary of assemblies in the same directory
    if(_assemblyPaths.TryGetValue(assemblyName.Name!, out string? path))
    {
      return LoadFromAssemblyPath(path);
    }

    // Let the default context handle it (for system assemblies)
    return null;
  }

  protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
  {
    string? libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
    if(libraryPath != null)
    {
      return LoadUnmanagedDllFromPath(libraryPath);
    }
    return IntPtr.Zero;
  }
}

