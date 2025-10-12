using GTMH.S11n.Reflection.UnitTests.LibA;

using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.Reflection.UnitTests.LibB;
public partial class LibBInterfaceImpl : LibAInterfaceType
{
  [GTS11n]
  public string Name { get; set; } = "LibBInterfaceImpl";
}
