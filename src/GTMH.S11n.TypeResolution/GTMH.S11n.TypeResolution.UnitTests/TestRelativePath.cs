namespace GTMH.S11n.TypeResolution.UnitTests;

public class TestRelativePath
{
  [Test]
  public async ValueTask Same()
  {
    var basis = "c:/path/to/file.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, basis)).EqualTo("");
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, "")).EqualTo(basis);
  }
  [Test]
  public async ValueTask SameDir()
  {
    var basis = "c:/path/to/file.dll";
    var file = "c:/path/to/other.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, file)).EqualTo("other.dll");
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, "other.dll")).EqualTo(file);
  }
  [Test]
  public async ValueTask NoCommonRoot()
  {
    var basis = "c:/path/to/file.dll";
    var file = "d:/path/to/other.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, file)).EqualTo(file);
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, file)).EqualTo(file);
  }
  [Test]
  public async ValueTask SubDir()
  {
    var basis = "c:/path/to/file.dll";
    var file = "c:/path/to/sub_dir/other.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, file)).EqualTo("sub_dir/other.dll");
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, "sub_dir/other.dll")).EqualTo(file);
  }
  [Test]
  public async ValueTask BackDir()
  {
    var basis = "c:/path/to/file.dll";
    var file = "c:/path/other.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, file)).EqualTo("../other.dll");
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, "../other.dll")).EqualTo(file);
  }
  [Test]
  public async ValueTask BackAnother()
  {
    var basis = "c:/path/to/file.dll";
    var file = "c:/path/to_another/other.dll";
    await Assert.That(BasisAssembly.GetRelativePath(basis, file)).EqualTo("../to_another/other.dll");
    await Assert.That(BasisAssembly.GetAbsolutePath(basis, "../to_another/other.dll")).EqualTo(file);
  }
}
