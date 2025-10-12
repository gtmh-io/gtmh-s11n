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
    //Func<Type,string> nm = ty=> ty.FullName??ty.Name;
    await Assert.That(ible.OrderBy(_=>_)).IsEquivalentTo( new[] { "GTMH.S11n.Reflection.UnitTests.LibB.LibBInterfaceImpl" } );
  }
}
