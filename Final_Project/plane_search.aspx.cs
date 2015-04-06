using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Final_Project
{
  public partial class search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
      }
    }

    protected void prefCheck_CheckedChange(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      /*
      // QPXRequest sendRequest = new QPXRequest();

      sendRequest.Request.Passengers.AdultCount = int.Parse(tbAdults.Text);//1;
      sendRequest.Request.Passengers.ChildCount = int.Parse(tbChildren.Text);//0;
      sendRequest.Request.Passengers.InfantInLapCount = int.Parse(tbLap.Text);//0;
      sendRequest.Request.Passengers.InfantInSeatCount = int.Parse(tbInfants.Text);//0;
      sendRequest.Request.Passengers.SeniorCount = int.Parse(tbSeniors.Text);//0;
      sendRequest.Request.MaxPrice = "USD5000.00"; //have to format input to be ISO-4217
      sendRequest.Request.SaleCountry = "US"; //dropdown of country codes? IATA country code representing the point of sale. 
      sendRequest.Request.Refundable = false; //checkbox
      sendRequest.Request.Solutions = 20; //i picked 20, this isn't on UI

      sendRequest.Request.Slice[0].Origin = ddlOrigin.SelectedValue;//"BWI"; //dropdown
      sendRequest.Request.Slice[0].Destination = ddlDestination.SelectedValue; //"LAX"; dropdown
      sendRequest.Request.Slice[0].Date = "2015-05-05"; //maybe have a date selector and convert to this format? idk
      sendRequest.Request.Slice[0].MaxStops = 5; // NOT ON UI
      sendRequest.Request.Slice[0].MaxConnectionDuration = int.Parse(tbMaxPrice.Text);//90;
      sendRequest.Request.Slice[0].PreferredCabin = ddlCabin.SelectedValue;//"COACH";
      sendRequest.Request.Slice[0].PermittedDepartureTime.EarliestTime = tbEarliest.Text;//"08:00"; we need to limit or format these
      sendRequest.Request.Slice[0].PermittedDepartureTime.EarliestTime = tbLatest.Text;//"20:00";
      sendRequest.Request.Slice[0].PermittedCarrier[0] = "UA"; //GRAB FROM PROFILE, LIMIT TO ONLY PREFERRED OR NOT

      string query = JsonConvert.SerializeObject(sendRequest);

      //set up the request properties for google
      var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/qpxExpress/v1/trips/search?key=AIzaSyBVtu_wTvDwSi4Wa8DHp3An3cFnYDJbWmo");
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = "POST";

      //send the request
      using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
      {
        streamWriter.Write(query);
        streamWriter.Flush();
        streamWriter.Close();
      }

      //grab the response and set it to the result
      var result = "";
      var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
      {
        result = streamReader.ReadToEnd();
      }

      //deserialize into an object
      QPXReponses.QPXReponse response = JsonConvert.DeserializeObject<QPXReponses.QPXReponse>(result);

      */
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
      tbDepartureDate.Text = Calendar1.SelectedDate.ToShortDateString();
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
      tbArrivalDate.Text = Calendar2.SelectedDate.ToShortDateString();
      Calendar2.Visible = false;
    }
  }
}