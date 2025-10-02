using GTMH.S11n;

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld;

[GTS11n] // ensures that any implementation is serialisable
public interface IOperator { void Execute(); }
