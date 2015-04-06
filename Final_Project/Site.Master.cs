using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
  public partial class SiteMaster : MasterPage
  {
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
      // The code below helps to protect against XSRF attacks
      var requestCookie = Request.Cookies[AntiXsrfTokenKey];
      Guid requestCookieGuidValue;
      if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
      {
        // Use the Anti-XSRF token from the cookie
        _antiXsrfTokenValue = requestCookie.Value;
        Page.ViewStateUserKey = _antiXsrfTokenValue;
      }
      else
      {
        // Generate a new Anti-XSRF token and save to the cookie
        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        Page.ViewStateUserKey = _antiXsrfTokenValue;

        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        {
          HttpOnly = true,
          Value = _antiXsrfTokenValue
        };
        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        {
          responseCookie.Secure = true;
        }
        Response.Cookies.Set(responseCookie);
      }

      Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // Set Anti-XSRF token
        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
      }
      else
      {
        // Validate the Anti-XSRF token
        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
            || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        {
          throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        }
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        // Make sure they're allowed in
        bool loggedIn;
        try
        {
            loggedIn = (bool)(Session["loggedIn"]);
        }
        catch
        {
            loggedIn = false;
        }

        // If they're not, make them leave
        if(!loggedIn)
        {
            Response.BufferOutput = true;
            Response.Redirect("Default.aspx");
        }
        */

        // Figure out language stuff
        bool vietnamese;
        try
        {
          vietnamese = (bool)(Session["Vietnamese"]);
        }
        catch
        {
          vietnamese = false;
        }

        if (!vietnamese)
        {
          cbLanguageChange.Checked = false;
          changeLanguage(vietnamese);
        }
        else
        {
          cbLanguageChange.Checked = true;
          changeLanguage(vietnamese);
        }

        // What kind of user are they?
        string userType = (string)(Session["UserType"]);

        if (userType != null)
        {
          if(userType != "regular")
          {
            switch (userType)
            {
              case "student":
                li2.Style.Add("display", "none");
                li3.Style.Add("display", "none");
                li4.Style.Add("display", "none");
                li5.Style.Add("display", "none");
                break;
              case "assistant":
                li6.Style.Remove("display");
                break;
              default:
                break;
            }
          }
        }
        else
        {
          Session.Add("UserType", "regular");
        }
    }

    protected void languageChange_OnCheckedChange(object sender, EventArgs e)
    {
        bool vietnamese = false;
        try
        {
            if (!cbLanguageChange.Checked)
            {
                // Change it to English
                Session["Vietnamese"] = vietnamese;
                changeLanguage(vietnamese);
            }
            else if (cbLanguageChange.Checked)
            {
                // Change it to Vietnamese
                vietnamese = true;
                Session["Vietnamese"] = vietnamese;
                changeLanguage(vietnamese);
            }
            else
            {
                Console.WriteLine("Something Went Wrong");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
      // YOU CANT SIT WITH US
      bool sitWithUs = false;
      
      try
      {
        Session["LoggedIn"] = sitWithUs;
        Session["Vietnamese"] = false;
      }
      catch
      {
        Session.Add("LoggedIn", sitWithUs);
      }

      // Redirect to Login Page
      Response.BufferOutput = true;
      Response.Redirect("Default.aspx");
    }

    protected void changeLanguage(bool change)
    {
        if(!change)
        {
            cbLanguageChange.Text = " Tiếng Việt";
            WelcomeMessage.InnerHtml = "Welcome, " + (string)(Session["FirstName"]);
        }
        else
        {
            cbLanguageChange.Text = " English";
            WelcomeMessage.InnerHtml = "Chào mừng, " + (string)(Session["FirstName"]);
        }
    }

    protected void btnBookAnother_ServerClick(object sender, EventArgs e)
    {
        Session.Add("BookAnother", true);
    }
  }
}