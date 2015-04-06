using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace Final_Project
{
  public partial class profile : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {

        for (var i = 1; i < 13; i++)
        {
          var item = new ListItem
          {
            Text = i.ToString(),
            Value = i.ToString()
          };
          DDLMonth.Items.Add(item);
        }

        for (var i = 2015; i < 2025; i++)
        {
          var item = new ListItem
          {
            Text = i.ToString(),
            Value = i.ToString()
          };
          DDLYear.Items.Add(item);
        }


        if (!IsPostBack)
        {

          System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
          sc.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
          sc.Open();

          System.Data.SqlClient.SqlCommand fill = new System.Data.SqlClient.SqlCommand();
          fill.Connection = sc;

          String search = "1";

          //Preventing SQl injection
          fill.Parameters.AddWithValue("@search", search);

          //SQL statement to connect all the tables

          fill.CommandText = "select user_account.user_id, user_account.user_first_name, user_account.user_last_name, user_account.address_line_1, user_account.address_line_2, ";
          fill.CommandText += "user_account. address_city, user_account.address_state, user_account.address_postal_code, user_account.phone, [Credit_Card].[Card_Number], ";
          fill.CommandText += "[Credit_Card].Expiration_Date_Month, [Credit_Card].Expiration_Date_Year, [Credit_Card].CVV_Number from user_account inner join [dbo].[Credit_Card] on ";
          fill.CommandText += "[dbo].[Credit_Card].[User_ID] = dbo.User_Account.[User_ID] where user_account.user_id = @search";
          fill.ExecuteNonQuery();
          System.Data.SqlClient.SqlDataReader reader;
          reader = fill.ExecuteReader();


          if (reader.HasRows)
          {
            reader.Read();
            tbEmpId.Text = reader[0].ToString();
            tbFirstName.Text = reader[1].ToString();
            tbLastName.Text = reader[2].ToString();
            tbAddyLineOne.Text = reader[3].ToString();
            tbAddyLineTwo.Text = reader[4].ToString();
            tbCity.Text = reader[5].ToString();
            DDLState.Text = reader[6].ToString();
            tbPostalCode.Text = reader[7].ToString();
            tbPhone.Text = reader[8].ToString();
            tbCardNum.Text = reader[9].ToString();
            DDLMonth.Text = reader[10].ToString();
            DDLYear.Text = reader[11].ToString();
            tbCardSecCode.Text = reader[12].ToString();
          }
          else
          {
            notify.InnerHtml = "User cannot be found in the database.";
          }

        }

        else
        {

        }


      }
      catch
      {
        notify.InnerHtml = "Error connecting to the database!";
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      try
      {

        //reconnect to database
        System.Data.SqlClient.SqlConnection save_connection = new System.Data.SqlClient.SqlConnection();
        save_connection.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
        save_connection.Open();

        //update statement
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.Connection = save_connection;

        //  String firstname = txtFirst.Text;
        //  String lastname = txtLast.Text;


        //Preventing SQl injection
        update.Parameters.AddWithValue("@first", tbFirstName.Text);
        update.Parameters.AddWithValue("@last", tbLastName.Text);
        update.Parameters.AddWithValue("@line1", tbAddyLineOne.Text);
        update.Parameters.AddWithValue("@line2", tbAddyLineTwo.Text);
        update.Parameters.AddWithValue("@city", tbCity.Text);
        update.Parameters.AddWithValue("@state", DDLState.Text);
        update.Parameters.AddWithValue("@zip", tbPostalCode.Text);
        update.Parameters.AddWithValue("@phone", tbPhone.Text);
        update.Parameters.AddWithValue("@ID", tbEmpId.Text);


        update.CommandText = "exec UpdateUser @first, @last, @line1, @line2, @city, @state, @zip, @phone, @ID";
        update.ExecuteNonQuery();
        save_connection.Close();


        //reconnect to database
        System.Data.SqlClient.SqlConnection save_connection2 = new System.Data.SqlClient.SqlConnection();
        save_connection2.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
        save_connection2.Open();

        //update statement
        System.Data.SqlClient.SqlCommand update2 = new System.Data.SqlClient.SqlCommand();
        update2.Connection = save_connection2;

        String month = DDLMonth.Text;
        String Year = DDLYear.Text;


        update2.Parameters.AddWithValue("@Credit", tbCardNum.Text);
        update2.Parameters.AddWithValue("@Month", month);
        update2.Parameters.AddWithValue("@Year", Year);
        update2.Parameters.AddWithValue("@CVV", tbCardSecCode.Text);
        update2.Parameters.AddWithValue("@ID", tbEmpId.Text);

        update2.CommandText = "exec UpdateUser2 @Credit, @Month, @Year, @CVV, @ID";
        update2.ExecuteNonQuery();
        save_connection2.Close();

        notify.Style.Remove("display");
        notify.InnerHtml = "Changes Saved Successfully";

      }

      catch
      {
        notify.InnerHtml = "Error";
      }
    }
  }
}