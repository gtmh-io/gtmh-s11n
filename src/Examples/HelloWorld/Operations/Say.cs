using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;

public partial class Say : IOperator
{
  [GTS11n(Required=true)]
  public readonly string Normally;

  public Say(string v) { Normally=v; }

  public void Execute() => Console.Write(Normally);
}
