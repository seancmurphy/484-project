using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;

namespace Final_Project
{
  public class CurrencyRate
  {
    // Attributes
    private static string api_key = "7e81613c7729415db1e911dfe1f78182";

    // Behaviours
    public static double getConversionRate(string locale)
    {
      return parseRate(locale);
    }

    private static double parseRate(string locale)
    {
      // Build the API request URL
      string request_url = "http://openexchangerates.org/api/latest.json?app_id=" + api_key;
      
      var json = new WebClient().DownloadString(request_url);
      string serialized_json = Convert.ToString(json);
      double x = 0;

      return x;
    }
  }
}