using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Final_Project
{
  public class NewMessage
  {
    // Attributes
    private static int empID = 0;
    
    //// Planes
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
    
    //// Hotels
    private static string hotelConfNum = @"";
    
    //// Trains
    private static string trainConfNum = @"";
    
    //// Cars
    private static string CarConfNum = @"";
    
    //// Message Bodies
    private static string FlightBaseMessage = @"";
    private static string HotelBaseMessage = @"";
    private static string TrainBaseMessage = @"";
    private static string CarBaseMessage = @"";
    
    // Behaviors
    static public void SendConfirmationMessage(string to, string subject, string type)
    {
      MailAddress fromAddress = new MailAddress("kpmg.booking@gmail.com", "KPMG Travel");
      MailAddress toAddress = new MailAddress(to);
      const string fromPassword = "kpmgtravelbooking";

      SmtpClient smtp = new SmtpClient
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
      };

      MailMessage mail = new MailMessage(toAddress, fromAddress);
      mail.IsBodyHtml = true;
      
      switch (type)
      {
        case "flight":
          mail.Subject = "Flight Confirmation";
          mail.Body = FlightBaseMessage;
          break;
        case "train":
          mail.Subject = "Train Travel Confirmation";
          mail.Body = TrainBaseMessage;
          break;
        case "hotel":
          mail.Subject = "Hotel Reservation Confirmation";
          mail.Body = HotelBaseMessage;
          break;
        case "car":
          mail.Subject = "Vehicle Reservation Confirmation";
          mail.Body = CarBaseMessage;
          break;
        default:
          break;
      }
      smtp.Send(mail);
    }
    
    //// Set Methods
    
    ////// Flight Set Methods
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
    
    ////// Hotel Set Methods
    public void setHotelConfNum(string newConfNum)
    {
      hotelConfNum = newConfNum;
    }
    
    ////// Train Set Methods
    public void setTrainConfNum(string newConfNum)
    {
      trainConfNum = newConfNum;
    }
    
    ////// Car Set Methods
    public void setCarConfNum(string newConfNum)
    {
      CarConfNum = newConfNum;
    }
    
    //// Create confirmation messages
    static public void createFlightConfirmationMessage()
    {
      FlightBaseMessage = @"
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
                                  <span>Employee ID: " + empID.Convert.ToString(); + @"</span>
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
    
    static public void createTrainConfirmationMessage()
    {
      TrainBaseMessage = @"";
    }
    
    static public void createHotelConfirmationMessage()
    {
      HotelBaseMessage = @"";
    }
    
    static public void createCarConfirmationMessage()
    {
      CarBaseMessage = @"";
    }
  }
}