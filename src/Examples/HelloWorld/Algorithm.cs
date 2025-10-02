using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

using GTMH.S11n;

namespace HelloWorld;

public partial class Algorithm
{
  [GTS11n(Instance=true, Required=true)]
  public IOperator Head { get; set; }
  [GTS11n(Instance=true, Required=true)]
  public readonly ImmutableArray<IOperator> Body;
  [GTS11n(Instance=true)]
  public IOperator ? Tail { get; }
}
