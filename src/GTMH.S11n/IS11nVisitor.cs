using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n
{
  public interface IS11nVisitor
  {
    void VisitPOD(string a_Name);
    void VisitPOD(string a_Name, string a_DefaultValue);
    void Visit(string a_Name, Type a_Type, bool a_Required);
    void VisitList(string a_Name, Type a_Type, bool a_Required);
  }
}
