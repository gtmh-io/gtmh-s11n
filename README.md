# GTMH.S11n - Polymorphic Object Serialization for C#

A lightweight, attribute-based serialization library for C# that enables easy configuration and instantiation of polymorphic object graphs through simple key-value pairs.

## 🎯 What is GTMH.S11n?

GTMH.S11n (serialization) provides a clean, declarative way to serialize and deserialize complex object hierarchies, with special support for:
- **Polymorphic types** - Serialize interfaces and abstract classes
- **Immutable objects** - Support for readonly fields and init-only properties  
- **Simple configuration** - Use dictionaries, JSON, or any key-value store
- **Type-safe** - Compile-time checking with source generators
- **Minimal boilerplate** - Just add attributes, no manual mapping code

## 🚀 Quick Example

Here's a simple "Hello World" that demonstrates polymorphic serialization:
```csharp
// Define your interface
[GTS11n] // ensures that any implementation is serialisable
public interface IOperator { void Execute(StringBuilder a_State); }

// Define your implementations
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

// Define your algorithm structure
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

```
You can now instantiate a complex object process from simple configuration

```csharp
var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorldStateful.Say" },
  {"Head.Value", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorldStateful.SPC" },
  {"Body.1", "HelloWorldStateful.Mumble" },
  {"Body.1.Value", "wasting time" },
  {"Body.2", "HelloWorldStateful.Mumble" },
  {"Body.2.Value", "coffee time" },
  {"Body.3", "HelloWorldStateful.SPC" },
  {"Body.4", "HelloWorldStateful.Shout" },
  {"Body.4.Value", "World" },
  {"Tail", "HelloWorldStateful.EOM" }
};

var algo = new Algorithm(cfg.ForInit());
Console.WriteLine(algo.Execute());

```
Output
```code
Hello (wasting time)(coffee time) WORLD!
```
