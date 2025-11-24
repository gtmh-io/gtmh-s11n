using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTMH.S11n.FieldTypes
{
  public class EnumField : PODField
  {
    public readonly string Type;
    public EnumField(string a_Name, string a_Type, GTFieldAttrs a_Attrs, string a_Default): base(a_Name, a_Attrs, Clean(a_Default))
    {
      Type = a_Type;
    }

    static string Clean(string a_DefaultValue) => a_DefaultValue.Split('.').Last();

    public override void WriteGather(Code code)
    {
      code.WriteLine($"a_Args.Add(\"{this.Name}\", {this.Name}.ToString());");
    }

    public override void WriteInitialisation(Code code)
    {
      code.WriteLine("{");
      using(code.Indent())
      {
        if(Attrs.AKA == null)
        {
          code.WriteLine($"var tmp = a_Args.GetValue(\"{this.Name}\", {this.Name}.ToString());");
        }
        else
        {
          code.WriteLine($"var tmp = a_Args.GetValue(\"{this.Name}\", GTInitArgs.NoValue);");
          code.WriteLine($"if ( tmp == GTInitArgs.NoValue ) tmp = a_Args.GetValue(\"{Attrs.AKA}\", {this.Name}.ToString());");
        }

        code.WriteLine($"if( Enum.TryParse<{this.Type}>(tmp, out {this.Type} _tmp)) {this.Name}=_tmp;");
        code.WriteLine($"else throw new ArgumentException(\"Could not convert to {this.Type}\");");
      }
      code.WriteLine("}");
    }
  }
}
