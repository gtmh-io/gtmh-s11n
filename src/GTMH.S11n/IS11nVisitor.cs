using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n
{
  public interface IS11nVisitor
  {
    void VisitMember(string a_Name, bool a_Required);
    void VisitInstance(string a_Name, bool a_Required);
    void VisitInstanceList(string a_Name, bool a_Required);
  }
}
