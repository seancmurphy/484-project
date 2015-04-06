using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project
{
  public partial class _Default : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        bool vietnamese = false;
        Session["Vietnamese"] = vietnamese;
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
      string username = usernameInput.Value;
      string password = passwordInput.Value;
      string hash = "";
      string salt = "";
      const string prepend = "1000";
      string userType = "";

      try
      {
        //look up user by username and get hash
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=KPMG;Trusted_Connection=Yes;";
        sc.Open();

        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
        command.Connection = sc;

        // read the database
        command.CommandText = "select user_password_hash, user_password_salt from User_Password where user_id like @username";
        command.Parameters.AddWithValue("@username", username);
        command.ExecuteNonQuery();

        System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
          hash = reader.GetString(0);
          salt = reader.GetString(1);
        }

        hash = prepend + ":" + salt + ":" + hash;

        sc.Close();

        //Check the password
        bool verify = PasswordHash.ValidatePassword(password, hash);

        if (verify)
        {
          Session.Add("LoggedIn", true);
          Session.Add("UserType", userType);
          Response.BufferOutput = true;
          Response.Redirect("start.aspx");
        }
        else
        {
          //Tell the user their password was wrong
          warningText.InnerHtml = "Password is incorrect";
          warning.Attributes.Remove("style");
          warning.Attributes.Add("style", "display:block;");
        }
      }
      catch
      {
        //display warning when a username does not exist
        warningText.InnerHtml = "Username does not exist.";
        warning.Attributes.Remove("style");
        warning.Attributes.Add("style", "display:block;");
      }
    }

    protected void demoLoginButton_Click(object sender, EventArgs e)
    {
      string username = usernameInput.Value;
      string password = passwordInput.Value;

      // Dummy Usernames
      string userOneUsername = "userone@demo.com";
      string userTwoUsername = "usertwo@demo.com";
      string userThreeUsername = "userthree@demo.com";
      string userFourUsername = "demouser@demo.com";

      bool verify = false;

      if (username == userOneUsername)
      {
        string hash = "1000:YZhZtra4A6lhanlNVFndzbPdWQRAYbcm:IEHZQHBX3z6DujhXbmgy0xbcDUn/3/wj";
        string firstName = "Regular User";
        verify = PasswordHash.ValidatePassword(password, hash);

        if (verify)
        {
          Session.Add("UserType", "regular");
          Session.Add("FirstName", firstName);
          Session.Add("LoggedIn", true);
          Response.BufferOutput = true;
          Response.Redirect("start.aspx");
        }
        else
        {
          // Tell the user their password was wrong
          warningText.InnerHtml = "Password is incorrect";
          warning.Attributes.Remove("style");
          warning.Attributes.Add("style", "display:block;");
        }
      }
      else if(username == userTwoUsername)
      {
        string hash = "1000:GisYQPb3lsZEyotyUqTCNULxXFrGxCvL:NXh6j1sX4ZM4Mfr2KO5bUv2P/HfzzLHY";
        string firstName = "Assistant User";
        verify = PasswordHash.ValidatePassword(password, hash);

        if (verify)
        {
          Session.Add("UserType", "assistant");
          Session.Add("FirstName", firstName);
          Session.Add("LoggedIn", true);
          Response.BufferOutput = true;
          Response.Redirect("start.aspx");
        }
        else
        {
          // Tell the user their password was wrong
          warningText.InnerHtml = "Password is incorrect";
          warning.Attributes.Remove("style");
          warning.Attributes.Add("style", "display:block;");
        }
      }
      else if(username == userThreeUsername)
      {
        string hash = "1000:Fl9aus9SJieAfVq/7j//Kr/TAtnQReqt:sAGHwWUxpfQxCaVwAdwUGuXwvYefsVQh";
        string firstName = "Student User";
        verify = PasswordHash.ValidatePassword(password, hash);

        if (verify)
        {
          Session.Add("UserType", "student");
          Session.Add("FirstName", firstName);
          Session.Add("LoggedIn", true);
          Response.BufferOutput = true;
          Response.Redirect("start.aspx");
        }
        else
        {
          // Tell the user their password was wrong
          warningText.InnerHtml = "Password is incorrect";
          warning.Attributes.Remove("style");
          warning.Attributes.Add("style", "display:block;");
        }
      }
      else if (username == userFourUsername)
      {
        string hash = "1000:22TAgbVQAYd/lhFdg/jAr1J9SNblErmL:/3MPleDDB29sFObG/zet+83mD6L1Jjwv";
        string firstName = "Demo User";
        verify = PasswordHash.ValidatePassword(password, hash);
        
        if (verify)
        { 
          Session.Add("UserType", "regular");
          Session.Add("FirstName", firstName);
          Session.Add("LoggedIn", true);
          Response.BufferOutput = true;
          Response.Redirect("start.aspx");
        }
        else
        {
          // Tell the user their password was wrong
          warningText.InnerHtml = "Password is incorrect";
          warning.Attributes.Remove("style");
          warning.Attributes.Add("style", "display:block;");
        }
      }
      else
      {
        warningText.InnerHtml = "Username or password was incorrect.";
      }
    }

    protected void languageChange_CheckedChange(object sender, EventArgs e)
    {
      bool vietnamese = false;
      try
      {
        if (!CheckBox1.Checked)
        {
          //English
          vietnamese = false;
          Session.Add("Vietnamese", vietnamese);

          CheckBox1.Text = " Tiếng Việt";
          welcome.InnerHtml = "Welcome to KPMG Travel Booking";
          inst.InnerHtml = "Please log in:";
          usernameInput.Attributes.Remove("placeholder");
          usernameInput.Attributes.Add("placeholder", "Username");
          passwordInput.Attributes.Remove("placeholder");
          passwordInput.Attributes.Add("placeholder", "Password");
          btnSubmit.Text = "Log In";
          forgotPassword.InnerHtml = "Forget your password?";
        }
        else if (CheckBox1.Checked)
        {
          //Vietnamese
          vietnamese = true;
          Session.Add("Vietnamese", vietnamese);

          CheckBox1.Text = " English";
          welcome.InnerHtml = "Chào Mừng Đến Với Hệ thống Đặt Vé Du Lịch Của KPMG";
          inst.InnerHtml = "Vui Lòng Đăng Nhập";
          usernameInput.Attributes.Remove("placeholder");
          usernameInput.Attributes.Add("placeholder", "Tài Khoản");
          passwordInput.Attributes.Remove("placeholder");
          passwordInput.Attributes.Add("placeholder", "Mật Khẩu");
          btnSubmit.Text = "Đăng Nhập";
          forgotPassword.InnerHtml = "Quên Mật Khẩu?";
        }
        else
        {
          Console.WriteLine("Something Went Wrong");
        }
      }
      catch ( Exception error )
      {
        Console.WriteLine(error);
      }
    }
  }
}