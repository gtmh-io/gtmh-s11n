using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.GUI
{
  public class LoadContext
  {
    private string m_BaseDirectory;
    public string Directory => m_BaseDirectory;
    public LoadContext()
    {
      m_BaseDirectory = System.IO.Directory.GetCurrentDirectory();
    }
    public LoadContext(string a_Assembly)
    {
      m_BaseDirectory = System.IO.Path.GetDirectoryName(a_Assembly) ?? System.IO.Directory.GetCurrentDirectory();
    }
    public string Resolve(string a_Path)
    {
      var dirName = System.IO.Path.GetDirectoryName(a_Path);
      if ( dirName==null ) return a_Path; // just a file name
      if ( dirName.StartsWith(m_BaseDirectory) ) return a_Path.Replace(m_BaseDirectory, "").TrimStart(System.IO.Path.DirectorySeparatorChar);
      // TODO - handle relative paths
      return a_Path;
    }
  }
}
