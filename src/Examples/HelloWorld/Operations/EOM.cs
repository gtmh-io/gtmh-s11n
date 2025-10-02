using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;
public partial class EOM : IOperator
{
  public EOM() { }
  [GTS11n]
  public int Ignore;
  public void Execute() => Console.WriteLine();
}
