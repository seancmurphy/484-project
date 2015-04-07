using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Final_Project
{
  public partial class train_search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
      string From = ddlFrom.Text;
      string To = ddlTo.Text;
      GridView1.Visible = true;
      GridView2.Visible = true;
      DateTime todate = CalendarTO.SelectedDate;
      DateTime fromdate = CalReturn.SelectedDate;

      try
      {
        
        if (From == To)
        {
          lblError.Text = "Please select two different cities to travel between.";

        }
        else if (todate > fromdate)
        {
          lblCalError.Text = "Please select a return date that is after your departure date.";
        }
        else if (todate.Equals("1/1/0001 12:00:00 AM"))
        {
          lblCalError.Text = "Please select a departure date.";
        }
        else if (fromdate.Equals("1/1/0001 12:00:00 AM"))
        {
          lblCalError.Text = "Please select a return date.";
        }
        else
        {
          lblError.Text = "";
          lblCalError.Text = "";
          System.Data.SqlClient.SqlConnection sc1 = new System.Data.SqlClient.SqlConnection();
          sc1.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
          sc1.Open();

          System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand();
          cmd1.Connection = sc1;
          cmd1.Parameters.AddWithValue("@FromCode", From);
          cmd1.Parameters.AddWithValue("@ToCode", To);

          //SQL statement to check for max modified date for verification
          cmd1.CommandText = "select  * from dbo.Train_Schedule where [From_Station_City] = @FromCode and To_Station_City = @ToCode";
          cmd1.ExecuteNonQuery();

          System.Data.SqlClient.SqlDataReader reader1;
          reader1 = cmd1.ExecuteReader();
          reader1.Read();

          DataTable dt = new DataTable();
          dt.Columns.Add("Select");
          dt.Columns.Add("Train Number");
          dt.Columns.Add("From Code");
          dt.Columns.Add("From");
          dt.Columns.Add("To Code");
          dt.Columns.Add("To");
          dt.Columns.Add("Dep Time");
          dt.Columns.Add("Arrival Time");
          dt.Columns.Add("Price");

          DataRow dr = dt.NewRow();

          int i = 1;
          int z = 0;

          while (reader1.Read())
          {

            // RadioButton radioButton1 = new RadioButton();
            // radioButton1.GroupName = "Departure_Buttons";
            // radioButton1.Checked += RadioButton_Checked;

            dt.Rows.Add(i.ToString(), reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), reader1[3].ToString(), reader1[4].ToString(), reader1[5].ToString(), reader1[6].ToString(), reader1[7].ToString());

            Train[] traindata = new Train[reader1.FieldCount];
            traindata[z] = new Train(i, reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), reader1[3].ToString(), reader1[4].ToString(), reader1[5].ToString(), reader1[6].ToString(), reader1[7].ToString());

            i = i + 1;
            z = z + 1;
          }

          GridView1.DataSource = dt;
          GridView1.DataBind();


          System.Data.SqlClient.SqlCommand cmdCount = new System.Data.SqlClient.SqlCommand();
          cmdCount.Connection = sc1;
          cmdCount.Parameters.AddWithValue("@FromCode", From);
          cmdCount.Parameters.AddWithValue("@ToCode", To);

          //   cmdCount.CommandText = "select  Row_Number() over (order by From_Station_City) as Row_Number from dbo.Train_Schedule where [From_Station_City] = @FromCode and To_Station_City = @ToCode";
          // cmdCount.ExecuteNonQuery();

          // ddlNumb.DataSource = cmdCount;

          sc1.Close();

          Label12.Visible = true;
          Label13.Visible = true;
          lblReturn.Text = fromdate.ToString("M/dd/yyyy");
          lblDepart.Text = todate.ToString("M/dd/yyyy");

          //SQL to get the return table
          System.Data.SqlClient.SqlConnection sc2 = new System.Data.SqlClient.SqlConnection();
          sc2.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
          sc2.Open();


          System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
          cmd2.Connection = sc2;
          cmd2.Parameters.AddWithValue("@FromCode", From);
          cmd2.Parameters.AddWithValue("@ToCode", To);

          cmd2.CommandText = "select  * from dbo.Train_Schedule where [From_Station_City] = @ToCode and To_Station_City = @FromCode";
          cmd2.ExecuteNonQuery();

          System.Data.SqlClient.SqlDataReader reader2;
          reader2 = cmd2.ExecuteReader();
          reader2.Read();

          DataTable dt2 = new DataTable();

          dt2.Columns.Add("Select");
          dt2.Columns.Add("Train Number");
          dt2.Columns.Add("From Code");
          dt2.Columns.Add("From");
          dt2.Columns.Add("To Code");
          dt2.Columns.Add("To");
          dt2.Columns.Add("Dep Time");
          dt2.Columns.Add("Arrival Time");
          dt2.Columns.Add("Price");

          DataRow dr2 = dt.NewRow();

          i = 1;
          z = 0;

          while (reader2.Read())
          {
            dt2.Rows.Add(i.ToString(), reader2[0].ToString(), reader2[1].ToString(), reader2[2].ToString(), reader2[3].ToString(), reader2[4].ToString(), reader2[5].ToString(), reader2[6].ToString(), reader2[7].ToString());

            Train[] traindata2 = new Train[reader2.FieldCount];
            traindata2[z] = new Train(i, reader2[0].ToString(), reader2[1].ToString(), reader2[2].ToString(), reader2[3].ToString(), reader2[4].ToString(), reader2[5].ToString(), reader2[6].ToString(), reader2[7].ToString());

            i++;
            z++;
          }

          GridView2.DataSource = dt2;
          GridView2.DataBind();
        }
      }
      catch
      {
        lblError.Text = "We Caught an error!";
      }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      NewMessage.SendConfirmationMessage("bander@dukes.jmu.edu", "Reserve Trip", "regular");
    }
  }
}