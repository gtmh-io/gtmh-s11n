using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.UnitTests.Impl
{
  [GTS11n]
  public interface IOperator
  {
    void Execute();
  }
  public partial class HasNotGTFieldsImplementsInterface : IOperator
  {
    public HasNotGTFieldsImplementsInterface() { }
    public void Execute() { }
  }
  public partial class DerivesHasNotGTFieldsImplementsInterface : HasNotGTFieldsImplementsInterface
  {
    public DerivesHasNotGTFieldsImplementsInterface() { }
  }
}
