using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Operations;

public partial class Mumble : IOperator
{
  public Mumble(string v) { Murmur=v; }

  [GTS11n(Required = true)]
  public string Murmur { get; private set; }
  public void Execute()=>Console.Write($"({Murmur.ToLower()})");
}
