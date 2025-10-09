using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI
{
  public partial class InstantiableControl : UserControl
  {
    public InstantiableControl()
    {
      InitializeComponent();
    }

    public InstantiableControl(Assembly a_Ass, string? a_Implements)
    {
      InitializeComponent();
      var context = new AssemblyLoadContext(null, true);
      try
      {
        foreach(var type in a_Ass.GetTypes())
        {

        }
      }
      finally
      {
        context.Unload();
      }
    }

    public bool Any() => m_Items.Items.Count > 0;
  }
}
