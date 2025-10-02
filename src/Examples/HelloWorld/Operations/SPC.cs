using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;
internal partial class SPC : IOperator
{
  public SPC() { }
  [GTS11n]
  public int Ignore;
  public void Execute() => Console.Write(' ');
}
