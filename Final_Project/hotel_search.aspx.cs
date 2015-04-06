using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.SqlClient;

namespace Final_Project
{
  public partial class hotel_search : System.Web.UI.Page
  {
    //values
    string hotelId_1;
    string hotelName_1;
    string hotelFeatures_1;
    string hotelAddress_1;
    string hotelRating_1;
    string hotelId_2;
    string hotelName_2;
    string hotelFeatures_2;
    string hotelAddress_2;
    string hotelRating_2;
    string hotelId_3;
    string hotelName_3;
    string hotelFeatures_3;
    string hotelAddress_3;
    string hotelRating_3;
    string strDestination;
    string strCheckIn;
    string strCheckOut;
    string strType;
    string strRooms;
    string strGuests;
    string strLength;
    string strDaily;
    string strPrice;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
      }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      DateTime checkinDate = DateTime.Parse(tbCheckin.Text);
      DateTime checkoutDate = DateTime.Parse(tbCheckout.Text);
      TimeSpan difference = checkoutDate - checkinDate;

      if(difference.TotalDays > 0)
      {
        //grab user input
        strDestination = tbCity.Text;
        strCheckIn = tbCheckin.Text;
        strCheckOut = tbCheckout.Text;
        strType = slRoomType.Value;
        strRooms = slRooms.Value;
        strGuests = slGuests.Value;

        //grab display data
        displayData(strDestination, strCheckIn, strCheckOut, strType, strRooms, strGuests);
      }
      else
      {
        warning.InnerHtml = "Must stay for at least one day.";
        warningRow.Style.Remove("display");
      }

    }

    public void displayData(string destination, string checkin, string checkout, string roomtype, string rooms, string guests)
    {
      //connection
      System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
      sc.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
      sc.Open();
      //command + sql protection for location
      System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
      cmd.Connection = sc;
      //cmd.Parameters.AddWithValue("@Destination", destination);

      //SQL statement to check for max modified date for verification
      cmd.CommandText = "SELECT TOP 3 hotelID, hotelName, hotelFeatures, hotelAddress, hotelRating FROM Hotels ORDER BY NEWID()";
      cmd.ExecuteNonQuery();

      System.Data.SqlClient.SqlDataReader reader;
      reader = cmd.ExecuteReader();

      //assigning data from the readers
      reader.Read();
      hotelId_1 = reader["hotelID"].ToString();
      hotelName_1 = reader["hotelName"].ToString();
      hotelFeatures_1 = reader["hotelFeatures"].ToString();
      hotelAddress_1 = reader["hotelAddress"].ToString();
      hotelRating_1 = reader["hotelRating"].ToString();

      reader.Read();
      hotelId_2 = reader["hotelID"].ToString();
      hotelName_2 = reader["hotelName"].ToString();
      hotelFeatures_2 = reader["hotelFeatures"].ToString();
      hotelAddress_2 = reader["hotelAddress"].ToString();
      hotelRating_2 = reader["hotelRating"].ToString();

      reader.Read();
      hotelId_3 = reader["hotelID"].ToString();
      hotelName_3 = reader["hotelName"].ToString();
      hotelFeatures_3 = reader["hotelFeatures"].ToString();
      hotelAddress_3 = reader["hotelAddress"].ToString();
      hotelRating_3 = reader["hotelRating"].ToString();

      reader.Close();
      sc.Close();

      //calculate day difference for use in price
      DateTime dtIn = Convert.ToDateTime(checkin);
      DateTime dtOut = Convert.ToDateTime(checkout);
      double dblDays = (dtOut.Date - dtIn.Date).TotalDays;
      strLength = dblDays.ToString();




      //price calculation
      double dblRooms = double.Parse(rooms);
      double dblPrice = 0;
      if (roomtype.Equals("Single"))
      {
        dblPrice = 50;
        dblPrice = dblPrice * dblRooms * dblDays;

      }
      else if (roomtype.Equals("Family"))
      {
        dblPrice = 65;
        dblPrice = dblPrice * dblRooms * dblDays;

      }
      else if (roomtype.Equals("Suite"))
      {
        dblPrice = 80;
        dblPrice = dblPrice * dblRooms * dblDays;

      }
      else if (roomtype.Equals("Executive Suite"))
      {
        dblPrice = 95;
        dblPrice = dblPrice * dblRooms * dblDays;

      }
      //the price is based on the amount of rooms and type of room
      //daily rate
      double dblDaily = dblPrice / dblDays;
      strDaily = dblDaily.ToString();

      //displaying everything
      lblHotelName1.Text = hotelName_1;
      lblCity1.Text = destination;
      lblAddress1.Text = hotelAddress_1;
      lblFeatures1.Text = hotelFeatures_1;
      lblRating1.Text = "Rating: " + hotelRating_1;
      lblPrice1.Text = "Total Price: " + dblPrice.ToString();

      double dblPrice2 = dblPrice * 1.05;
      lblHotelName2.Text = hotelName_2;
      lblCity2.Text = destination;
      lblAddress2.Text = hotelAddress_2;
      lblFeatures2.Text = hotelFeatures_2;
      lblRating2.Text = "Rating: " + hotelRating_2;
      lblPrice2.Text = "Total Price: " + dblPrice2.ToString();

      double dblPrice3 = dblPrice2 * 1.05;
      lblHotelName3.Text = hotelName_3;
      lblCity3.Text = destination;
      lblAddress3.Text = hotelAddress_3;
      lblFeatures3.Text = hotelFeatures_3;
      lblRating3.Text = "Rating: " + hotelRating_3;
      lblPrice3.Text = "Total Price: " + dblPrice3.ToString();

      //visibility
      result1.Visible = true;
      result2.Visible = true;
      result3.Visible = true;
    }
    
    protected void btnBuy1_Click(object sender, EventArgs e)
    {
      //connection
      System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
      sc.ConnectionString = @"Server = Localhost; Database=KPMG; Trusted_Connection=Yes";
      sc.Open();
      //command + sql protection for location
      System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
      cmd.Connection = sc;

      //SQL statement to check for max modified date for verification
      string query = "Insert into hotelReservations values('";
      query += strCheckIn + "', '";
      query += strCheckOut + "', '";
      query += strType + "', '";
      query += strRooms + "', '";
      query += strLength + "', '";
      query += strGuests + "', '";
      query += strDaily + "', '";
      query += strPrice + "', '";
      query += hotelId_1 + "', '";
      //this is going to be the reservation id
      query += "2')";
      cmd.CommandText = query;
      cmd.ExecuteNonQuery();
    }

    protected void prefCheck_CheckedChange(object sender, EventArgs e)
    {

    }

    protected void calendar1_Click(object sender, EventArgs e)
    {
      if (Calendar1.Visible == false)
      {
        Calendar1.Visible = true;
      }
      else
      {
        Calendar1.Visible = false;
      }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      tbCheckin.Text = Calendar1.SelectedDate.ToShortDateString();
      Calendar1.Visible = false;
    }

    protected void calendar2_Click(object sender, EventArgs e)
    {
      if (Calendar2.Visible == false)
      {
        Calendar2.Visible = true;
      }
      else
      {
        Calendar2.Visible = false;
      }
    }

    protected void calendar2_SelectionChanged(object sender, EventArgs e)
    {
      tbCheckout.Text = Calendar2.SelectedDate.ToShortDateString();
      Calendar2.Visible = false;
    }
  }
}