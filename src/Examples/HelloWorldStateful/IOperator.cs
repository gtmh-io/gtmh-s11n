using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldStateful;
[GTS11n] // ensures that any implementation is serialisable
public interface IOperator
{
  void Execute(StringBuilder a_State);
}
