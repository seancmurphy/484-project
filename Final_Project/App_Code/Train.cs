using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project
{
  public class Train
  {
    public string Select;
    public string Trainnumb;
    public string fromcode;
    public string fromcity;
    public string tocode;
    public string tocity;
    public string deptime;
    public string arrivaltime;
    public string price;

    public Train(int intselect, string sttrainnumb, string stfromcode, string stfromcity, string sttocode, string sttocity, string stdeptime, string starrivaltime, string stprice)
    {
      Select = intselect.ToString();
      Trainnumb = sttrainnumb;
      fromcode = stfromcode;
      tocode = sttocode;
      tocity = sttocity;
      deptime = stdeptime;
      arrivaltime = starrivaltime;
      price = stprice;
    }
  }
}