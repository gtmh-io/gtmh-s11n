using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.Reflection.UnitTests;

public partial class IblNoIface
{
  [GTS11n]
  public string Value { get; set; } = "Value";
}
