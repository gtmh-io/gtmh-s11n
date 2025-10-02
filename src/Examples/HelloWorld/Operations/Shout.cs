using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;
public partial class Shout : IOperator
{
  public Shout(string v) { Loudly = v; }

  [GTS11n(Required = true)]
  public string Loudly { get; private set; }
  public void Execute()=>Console.Write($"{Loudly.ToUpper()}!");
}
