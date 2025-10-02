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
public interface IOperator { void Execute(); }

// Define your implementations
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


// Define your object graph
public partial class Algorithm
{
    // A single non-nullable head operation
    [GTS11n(Instance = true, Required = true)]
    public IOperator Head { get; set; }
    
    // a variable number of operations in the body
    [GTS11n(Instance = true, Required = true)]
    public readonly ImmutableArray<IOperator> Body;
    
    // an optional tail operation
    [GTS11n(Instance = true)]
    public IOperator? Tail { get; }
}

```
You can now instantiate a complex object process from simple configuration

```csharp
var cfg = new DictionaryConfig()
{
  {"Head", "HelloWorld.Say" },
  {"Head.Value", "Hello" },
  {"Body.Array-Length", "5" },
  {"Body.0", "HelloWorld.SPC" },
  {"Body.1", "HelloWorld.Mumble" },
  {"Body.1.Value", "wasting time" },
  {"Body.2", "HelloWorld.Mumble" },
  {"Body.2.Value", "coffee time" },
  {"Body.3", "HelloWorld.SPC" },
  {"Body.4", "HelloWorld.Shout" },
  {"Body.4.Value", "World" },
  {"Tail", "HelloWorld.EOM" }
};

var algo = new Algorithm(cfg.ForInit());

// Execute the algorithm
algo.Head.Execute();                    // Prints: Hello
foreach(var op in algo.Body) op.Execute(); // Prints: (wasting time)(coffee time) WORLD!
algo.Tail?.Execute();                   // Prints: newline

```
Output
```code
Hello (wasting time)(coffee time) WORLD!
```
