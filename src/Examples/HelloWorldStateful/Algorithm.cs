using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace HelloWorldStateful;

public partial class Algorithm
{
  [GTS11n(Instance=true, Required=true)]
  public IOperator Head { get; set; }
  [GTS11n(Instance=true, Required=true)]
  public readonly ImmutableArray<IOperator> Body;
  [GTS11n(Instance=true)]
  public IOperator ? Tail { get; }

  public StringBuilder Execute()
  {
    var rval = new StringBuilder();
    Head.Execute(rval);
    foreach( var op in Body) op.Execute(rval);
    Tail?.Execute(rval);
    return rval;
  }
}

