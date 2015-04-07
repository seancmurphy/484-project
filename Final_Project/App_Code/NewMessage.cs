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
    private static string empID = "";
    
    //// Hotels
    private static string hotelConfNum = @"";
    
    //// Trains
    
    
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
    public void setEmpID(int EmpID)
    {
      empID = Convert.ToString(EmpID);
    }
    
    ////// Flight Set Methods
    
    
    ////// Hotel Set Methods
    public void setHotelConfNum(string newConfNum)
    {
      hotelConfNum = newConfNum;
    }
    
    ////// Car Set Methods
    public void setCarConfNum(string newConfNum)
    {
      CarConfNum = newConfNum;
    }
    
    //// Conf Messages
    
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