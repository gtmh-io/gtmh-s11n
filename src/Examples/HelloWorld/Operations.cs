using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld;

public partial class SPC : IOperator { public void Execute() => Console.Write(' '); }

public partial class EOM : IOperator { public void Execute() => Console.WriteLine(); }

public partial class WithContent
{
  [GTS11n(Required = true)]
  public string Value { get; private set; }
}

public partial class Mumble : WithContent, IOperator { public void Execute()=>Console.Write($"({Value.ToLower()})"); }

public partial class Shout : WithContent, IOperator { public void Execute()=>Console.Write($"{Value.ToUpper()}!"); }

public partial class Say : WithContent, IOperator { public void Execute() => Console.Write(Value); }
