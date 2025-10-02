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
public interface IOperator
{
    void Execute();
}

// Create implementations with serialization attributes
public partial class Say : IOperator
{
    [GTS11n(Required = true)]
    public readonly string Normally;
    public void Execute() => Console.Write(Normally);
}
public partial class Shout : IOperator
{
    [GTS11n(Required = true)]
    public string Loudly { get; private set; }
    
    public void Execute() => Console.Write($"{Loudly.ToUpper()}!");
}
[GTS11n]
public partial class SPC : IOperator { public void Execute() => Console.Write(' '); }
[GTS11n]
public partial class EOM : IOperator { public void Execute() => Console.WriteLine(); }


// Define your object graph
public partial class Algorithm
{
    [GTS11n(Instance = true, Required = true)]
    public IOperator Head { get; set; }
    
    [GTS11n(Instance = true, Required = true)]
    public readonly ImmutableArray<IOperator> Body;
    
    [GTS11n(Instance = true)]
    public IOperator? Tail { get; }
}

```
You can now instantiate a complex object process from simple configuration

```csharp
var cfg = new DictionaryConfig()
{
    {"Head", "HelloWorld.Say"},
    {"Head.Normally", "Hello"},
    {"Body.Array-Length", "5"},
    {"Body.0", "HelloWorld.SPC"},
    {"Body.1", "HelloWorld.Mumble"},
    {"Body.1.Murmur", "wasting time"},
    {"Body.2", "HelloWorld.Mumble"},
    {"Body.2.Murmur", "coffee time"},
    {"Body.3", "HelloWorld.SPC"},
    {"Body.4", "HelloWorld.Shout"},
    {"Body.4.Loudly", "World"},
    {"Tail", "HelloWorld.EOM"}
};

var algo = new Algorithm(cfg.ForInit());

// Execute the algorithm
algo.Head.Execute();                    // Prints: Hello
foreach(var op in algo.Body) op.Execute(); // Prints: (wasting time)(coffee time) WORLD!
algo.Tail?.Execute();                   // Prints: newline
