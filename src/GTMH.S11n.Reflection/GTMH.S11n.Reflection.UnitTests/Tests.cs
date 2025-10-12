using Moq;

using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.Reflection.UnitTests;

public class Tests
{
  [Test]
  public async ValueTask FindInstantiableUnitTests()
  {
    var path = "GTMH.S11n.Reflection.UnitTests.dll";
    var ible = Instantiable.Find(path, null).ToArray();
    Func<Type,string> nm = ty=> ty.FullName??ty.Name;
    await Assert.That(ible.OrderBy(_=>_)).IsEquivalentTo( new[] { nm(typeof(IblNoIface)) } );
  }
  [Test]
  public async ValueTask FindInstantiableLibB()
  {
    var path = "packaged\\GTMH.S11n.Reflection.UnitTests.LibB.dll";
    var ible = Instantiable.Find(path, null).ToArray();
    await Assert.That(ible.OrderBy(_=>_)).IsEquivalentTo( new[] { "GTMH.S11n.Reflection.UnitTests.LibB.LibBInterfaceImpl" } );
  }
  [Test]
  public async ValueTask VisitPackaged()
  {
    var visitor = new Visitor();
    Instantiable.Visit("packaged\\GTMH.S11n.Reflection.UnitTests.LibB.dll", "GTMH.S11n.Reflection.UnitTests.LibB.LibBInterfaceImpl", visitor);
    await Assert.That(visitor.Visited).IsEquivalentTo(new[] { ("Instance", "GTMH.S11n.Reflection.UnitTests.LibA.LibAInterfaceType", true) });
    await Assert.That(visitor.ListVisited).IsEquivalentTo(new[] { ("InstanceList", "GTMH.S11n.Reflection.UnitTests.LibA.LibAInterfaceType", true) });
    await Assert.That(visitor.PODDefaultVisited).IsEquivalentTo(new[] { ("Name", "LibBInterfaceImpl") });
    await Assert.That(visitor.PODRequiredVisited).IsEmpty();

  }
  class Visitor : IS11nVisitor
  {
    public List<(string, string,bool)> Visited = new();
    public void Visit(string a_Name, Type a_Type, bool a_Required)=> Visited.Add((a_Name, a_Type.FullName??a_Type.Name, a_Required));

    public List<(string, string, bool)> ListVisited = new();
    public void VisitList(string a_Name, Type a_Type, bool a_Required)=>ListVisited.Add((a_Name, a_Type.FullName??a_Type.Name, a_Required));

    public List<string> PODRequiredVisited = new();
    public void VisitPOD(string a_Name)=> PODRequiredVisited.Add(a_Name);

    public List<(string, string)> PODDefaultVisited = new();
    public void VisitPOD(string a_Name, string a_DefaultValue)=> PODDefaultVisited.Add((a_Name, a_DefaultValue));
  }
}
