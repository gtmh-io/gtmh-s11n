using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;
[GTS11n] // this must be marked explicitly since there's no s8d fields. It'd be good to be able to compile time warn
public partial class EOM : IOperator
{
  public EOM() { }
  public void Execute() => Console.WriteLine();
}
