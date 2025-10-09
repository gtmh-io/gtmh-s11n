using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n
{
  public interface IS11nVisitor
  {
    void VisitPOD(string a_Name);
    void VisitPOD(string a_Name, string a_DefaultValue);
    void VisitInstance(string a_Name, string a_Type, bool a_Required);
    void VisitInstanceList(string a_Name, string a_Type, bool a_Required);
  }
}
