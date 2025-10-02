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
[GTS11n]
public partial class Say : IOperator
{
    [GTS11n(Required = true)]
    public readonly string Normally;
    
    public void Execute() => Console.Write(Normally);
}

[GTS11n]
public partial class Shout : IOperator
{
    [GTS11n(Required = true)]
    public string Loudly { get; private set; }
    
    public void Execute() => Console.Write($"{Loudly.ToUpper()}!");
}

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
