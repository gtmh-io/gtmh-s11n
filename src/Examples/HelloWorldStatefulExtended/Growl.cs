using HelloWorldStateful;

using System.Text;

namespace HelloWorldStatefulExtended;

public partial class Growl : WithContent, IOperator
{
  public void Execute(StringBuilder a_State)
  {
    a_State.Append($"Grr ...{Value}...rrr");
  }
}
