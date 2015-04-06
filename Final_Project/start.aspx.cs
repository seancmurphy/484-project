using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
  public partial class booking : System.Web.UI.Page
  {
    bool planeChecked = false;
    bool trainChecked = false;
    bool hotelChecked = false;
    bool carChecked = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        bool vietnamese = false;
        if (Session["Vietnamese"] == null)
        {
            Session.Add("Vietnamese", vietnamese);
        }
        else
        {
           vietnamese = (bool)(Session["Vietnamese"]);
        }
      if(vietnamese)
      {
        // Change the language of everything on the page
      }

      // Hide what they don't need
      string userType = (string)(Session["UserType"]);

      if(userType == "student")
      {
        HotelCheckBox.Visible = false;
        CarCheckBox.Visible = false;
      }

      // Are we booking for someone else?
      bool bookAnother = false;
      if (Session["BookAnother"] == null)
      {
          Session.Add("BookAnother", bookAnother);
      }
      else
      {
          bookAnother = (bool)(Session["BookAnother"]);
      }

      if(bookAnother)
      {
        ddlWho.Visible = true;
      }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
      try
      {
        if(FlightCheckBox.Checked) {planeChecked = true;}
        if(HotelCheckBox.Checked) {hotelChecked = true;}
        if(CarCheckBox.Checked) {carChecked = true;}
        if(TrainCheckBox.Checked) {trainChecked = true;}

        Session["PlaneChecked"] = planeChecked;
        Session["HotelChecked"] = hotelChecked;
        Session["CarChecked"] = carChecked;
        Session["TrainChecked"] = trainChecked;

        Response.BufferOutput = true;

        if(planeChecked)
        {
          Response.Redirect("plane_search.aspx");
        }
        else if (!planeChecked && trainChecked)
        {
          Response.Redirect("train_search.aspx");
        }
        else if(!planeChecked && !trainChecked && hotelChecked)
        {
          Response.Redirect("hotel_search.aspx");
        }
        else if(!planeChecked && !hotelChecked && !trainChecked && carChecked)
        {
          Response.Redirect("car_search.aspx");
        }
        else
        {
          searchWarning.InnerHtml = "Please select something to book.";
        }
      }
      catch (Exception error)
      {
        Console.WriteLine(error);
      }
    }
  }
}