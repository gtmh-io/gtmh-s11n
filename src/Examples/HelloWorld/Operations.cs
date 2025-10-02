using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld;

[GTS11n] // this must be marked explicitly since there's no s8d fields. It'd be good to be able to compile time warn
public partial class SPC : IOperator
{
  public void Execute() => Console.Write(' ');
}

[GTS11n] // this must be marked explicitly since there's no s8d fields. It'd be good to be able to compile time warn
public partial class EOM : IOperator
{
  public void Execute() => Console.WriteLine();
}

public partial class Mumble : IOperator
{
  [GTS11n(Required = true)]
  public string Murmur { get; private set; }
  public void Execute()=>Console.Write($"({Murmur.ToLower()})");
}

public partial class Shout : IOperator
{
  [GTS11n(Required = true)]
  public string Loudly { get; private set; }
  public void Execute()=>Console.Write($"{Loudly.ToUpper()}!");
}

public partial class Say : IOperator
{
  [GTS11n(Required=true)]
  public readonly string Normally;
  public void Execute() => Console.Write(Normally);
}
