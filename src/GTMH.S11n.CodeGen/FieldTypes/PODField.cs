using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.FieldTypes
{
  public abstract class PODField : IFieldType
  {
    public readonly string Name;
    public readonly GTFieldAttrs Attrs;
    public readonly string DefaultValue;
    public PODField(string a_Name, GTFieldAttrs a_Attrs, string a_DefaultValue)
    {
      Name = a_Name;
      Attrs = a_Attrs;
      DefaultValue = a_DefaultValue;
      if ( DefaultValue != null ) DefaultValue=a_DefaultValue.Replace("\"", "");
    }
    abstract public void WriteGather(Code code);
    abstract public void WriteInitialisation(Code code);
    public void WriteVisitation(Code code)
    {
      if(DefaultValue == null)
      {
        code.WriteLine($"a_Visitor.VisitPOD(\"{this.Name}\");");
      }
      else
      {
        code.WriteLine($"a_Visitor.VisitPOD(\"{this.Name}\", \"{DefaultValue}\");");
      }
    }
  }
}
