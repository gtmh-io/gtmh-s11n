using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldStateful;

public partial class SPC : IOperator { public void Execute(StringBuilder a_State) => a_State.Append(' '); }

public partial class EOM : IOperator { public void Execute(StringBuilder a_State) => a_State.AppendLine(); }

public partial class WithContent
{
  [GTS11n(Required = true)]
  public string Value { get; private set; }
}

public partial class Mumble : WithContent, IOperator { public void Execute(StringBuilder a_State)=>a_State.Append($"({Value.ToLower()})"); }

public partial class Shout : WithContent, IOperator { public void Execute(StringBuilder a_State)=>a_State.Append($"{Value.ToUpper()}!"); }

public partial class Say : WithContent, IOperator { public void Execute(StringBuilder a_State) => a_State.Append(Value); }
