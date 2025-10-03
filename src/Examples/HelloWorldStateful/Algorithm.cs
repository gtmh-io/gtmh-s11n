using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace HelloWorldStateful;

public partial class Algorithm : IOperator
{
  [GTS11n(Instance=true, Required=true)]
  public IOperator Head { get; set; }
  [GTS11n(Instance=true, Required=true)]
  public readonly ImmutableArray<IOperator> Body;
  [GTS11n(Instance=true)]
  public IOperator ? Tail { get; }

  public void Execute(StringBuilder a_State)
  {
    Head.Execute(a_State);
    foreach( var op in Body) op.Execute(a_State);
    Tail?.Execute(a_State);
  }
}

