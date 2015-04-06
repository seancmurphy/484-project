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
    public static string baseMessage = @"
                                        <!DOCTYPE html>
                                        <html>
                                          <head>
                                            <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
                                            <title>Demystifying Email Design</title>
                                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
                                          </head>
                                          <body>
                                            <img style=""display:block;margin:0 auto;"" src="""" />
                                            <br /> 
                                          </body>
                                        </html>
                                        ";
    
    static public void SendReceiptMessage(string to, string subject)
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
      mail.Subject = subject;
      mail.Body = baseMessage;
      smtp.Send(mail);
    }
  }
}