﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Final_Project
{
  public class FlightConfirmation
  {
    // Attributes
    private static string BaseMessage = @"";
    
    private static string flightConfNum = @"";

    private static string flightInfo = @"";
    private static string flightDepartInfo = @"";
    private static string flightArriveInfo = @"";
    private static string flightStopsInfo = @"";
    private static string flightClassInfo = @"";

    private static string returnFlightInfo = @"";
    private static string returnFlightDepartInfo = @"";
    private static string returnFlightArriveInfo = @"";
    private static string returnFlightStopsInfo = @"";
    private static string returnFlightClassInfo = @"";

    // Constructors
    public FlightConfirmation()
    {
    
    }
    
    public FlightConfirmation(string fli, string fdi, string fai,
                              string fsi, string fci, string rfli,
                              string rfdi, string rfai, string rfsi,
                              string rfci)
    {
      flightInfo = fli;
      flightDepartInfo = fdi;
      flightArriveInfo = fai;
      flightStopsInfo = fsi;
      flightClassInfo = fci;
      
      returnFlightInfo = rfli;
      returnFlightDepartInfo = rfdi;
      returnFlightArriveInfo = rfai;
      returnFlightStopsInfo = rfsi;
      returnFlightClassInfo = rfci;
    }

    // Behaviors
    static private string createWeatherBlock(string city_input)
    {
      string city = city_input.Replace(" ", "_");
      string url = @"http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&mode=xml&units=imperial&cnt=5";
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load(url);

      var ser = new XmlSerializer(typeof(Weatherdata));
      var obj = (Weatherdata)ser.Deserialize(new StringReader(xmlDoc.OuterXml));

      string ugh = obj.Location.name + ", " + obj.Location.country;

      string build = @"
                      <table>
                        <tr>
                          <th>" + obj.Forecast.Time[0].Day + @"</th>
                          <th>" + obj.Forecast.Time[1].Day + @"</th>
                          <th>" + obj.Forecast.Time[2].Day + @"</th>
                          <th>" + obj.Forecast.Time[3].Day + @"</th>
                          <th>" + obj.Forecast.Time[4].Day + @"</th>
                        </tr>
                        <tr>
                          <td>Low: " + obj.Forecast.Time[0].Temperature.Min + @"F</td>
                          <td>Low: " + obj.Forecast.Time[1].Temperature.Min + @"F</td>
                          <td>Low: " + obj.Forecast.Time[2].Temperature.Min + @"F</td>
                          <td>Low: " + obj.Forecast.Time[3].Temperature.Min + @"F</td>
                          <td>Low: " + obj.Forecast.Time[4].Temperature.Min + @"F</td>
                        </tr>
                        <tr>
                          <td>High: " + obj.Forecast.Time[0].Temperature.Max + @"F</td>
                          <td>High: " + obj.Forecast.Time[1].Temperature.Max + @"F</td>
                          <td>High: " + obj.Forecast.Time[2].Temperature.Max + @"F</td>
                          <td>High: " + obj.Forecast.Time[3].Temperature.Max + @"F</td>
                          <td>High: " + obj.Forecast.Time[4].Temperature.Max + @"F</td>
                        </tr>
                      </table>
                      ";
    
      string output = @"";

      return output;
    }

    static public void createFlightConfirmationMessage(string EmpID)
    {
      BaseMessage = @"
                    <!DOCTYPE html>
                    <html>
                      <head>
                        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
                        <title>Demystifying Email Design</title>
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
                      </head>
                      <body style=""font-family:sans-serif;width:980px;"">
                        <img style=""display:block;margin:0 auto;width:980px;height:95px;"" src=""https://dl.dropboxusercontent.com/u/982704/banner.png"" />
                        <br />
                        <table>
                          <tr>
                            <h3 style=""color:navy;"">Travel Confirmation</h3>
                          </tr>
                          <tr>
                            <span>Confirmation #: " + flightConfNum + @"</span>
                          </tr>
                          <tr>
                            <span>Employee ID: " + EmpID + @"</span>
                          </tr>
                        </table>
                        <table>
                          <tr>
                            <th>Air Itinerary</th>
                          </tr>
                          <tr>
                            <span style=""text-decoration:underline;"">Departure Flight</span>
                          </tr>
                          <tr>
                            <td><span>Flight/Equip: </span></td>
                            <td><span>" + flightInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Depart: </span></td>
                            <td><span>" + flightDepartInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Arrive: </span></td>
                            <td><span>" + flightArriveInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Stops: </span></td>
                            <td><span>" + flightStopsInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Class: </span></td>
                            <td><span>" + flightClassInfo + @"</span></td>
                          </tr>
                        </table>
                        <table>
                          <tr>
                            <span style=""text-decoration:underline;"">Return Flight</span>
                          </tr>
                          <tr>
                            <td><span>Flight/Equip: </span></td>
                            <td><span>" + returnFlightInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Depart: </span></td>
                            <td><span>" + returnFlightDepartInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Arrive: </span></td>
                            <td><span>" + returnFlightArriveInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Stops: </span></td>
                            <td><span>" + returnFlightStopsInfo + @"</span></td>
                          </tr>
                          <tr>
                            <td><span>Class: </span></td>
                            <td><span>" + returnFlightClassInfo + @"</span></td>
                          </tr>
                        </table>
                      </body>
                    </html>
                    ";
    }

    // Get Methods
    public string getBaseMessage()
    {
      return BaseMessage;
    }

    // Set Methods
    public void setFlightConfNumber(string confNum)
    {
      flightConfNum = confNum;
    }

    public void setFlightInfo(string newFlightInfo)
    {
      flightInfo = newFlightInfo;
    }

    public void setFlightDepartInfo(string newDepartInfo)
    {
      flightDepartInfo = newDepartInfo;
    }

    public void setFlightArriveInfo(string newArriveInfo)
    {
      flightArriveInfo = newArriveInfo;
    }

    public void setFlightStopsInfo(string newStopsInfo)
    {
      flightStopsInfo = newStopsInfo;
    }

    public void setFlightClassInfo(string newClassInfo)
    {
      flightClassInfo = newClassInfo;
    }



    public void setReturnFlightInfo(string newFlightInfo)
    {
      returnFlightInfo = newFlightInfo;
    }

    public void setReturnFlightDepartInfo(string newDepartInfo)
    {
      returnFlightDepartInfo = newDepartInfo;
    }

    public void setReturnFlightArriveInfo(string newArriveInfo)
    {
      returnFlightArriveInfo = newArriveInfo;
    }

    public void setReturnFlightStopsInfo(string newStopsInfo)
    {
      returnFlightStopsInfo = newStopsInfo;
    }

    public void setReturnFlightClassInfo(string newClassInfo)
    {
      returnFlightClassInfo = newClassInfo;
    }
  }
}