using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
  public partial class CreateUser : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      string username = usernameInput.Value;
      string password = passwordInput.Value;

      string hash = PasswordHash.CreateHash(password);

      crap.InnerHtml = hash;
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
      string password = "password";
      string input = "1000:bqVNexMhMYb1PpjG9YHapko/QklubuiG:7c259eFPM23U07V9APJxiT+mrRTfL6cO";
      
      bool x = PasswordHash.ValidatePassword(password,input);

      if(x)
      {
        crap.InnerHtml = "success";
      }
      else
      {
        crap.InnerHtml = "fail";
      }
    }
  }
}