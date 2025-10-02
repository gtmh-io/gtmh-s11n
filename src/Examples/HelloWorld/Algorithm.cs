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

  public Algorithm(IOperator a_Head, IEnumerable<IOperator> a_Body, IOperator? a_Tail)
  {
    Head = a_Head;
    Body = a_Body.ToImmutableArray();
    Tail = a_Tail;
  }
}
