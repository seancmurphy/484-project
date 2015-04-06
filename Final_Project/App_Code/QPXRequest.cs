﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Final_Project
{
  public partial class QPXRequest
  {
    public class Passengers2
    {

      [JsonProperty("kind")]
      public string Kind = "qpxexpress#passengerCounts";

      [JsonProperty("adultCount")]
      public int AdultCount;

      [JsonProperty("childCount")]
      public int ChildCount;

      [JsonProperty("infantInLapCount")]
      public int InfantInLapCount;

      [JsonProperty("infantInSeatCount")]
      public int InfantInSeatCount;

      [JsonProperty("seniorCount")]
      public int SeniorCount;
    }
  }

  public partial class QPXRequest
  {
    public class PermittedDepartureTime2
    {

      [JsonProperty("kind")]
      public string Kind = "qpxexpress#timeOfDayRange";

      [JsonProperty("earliestTime")]
      public string EarliestTime;

      [JsonProperty("latestTime")]
      public string LatestTime;
    }
  }

  public partial class QPXRequest
  {
    public class Slouse
    {

      [JsonProperty("kind")]
      public string Kind = "qpxexpress#sliceInput";

      [JsonProperty("origin")]
      public string Origin;

      [JsonProperty("destination")]
      public string Destination;

      [JsonProperty("date")]
      public string Date;

      [JsonProperty("maxStops")]
      public int MaxStops;

      [JsonProperty("maxConnectionDuration")]
      public int MaxConnectionDuration;

      [JsonProperty("preferredCabin")]
      public string PreferredCabin;

      [JsonProperty("permittedDepartureTime")]
      public PermittedDepartureTime2 PermittedDepartureTime;

      [JsonProperty("permittedCarrier")]
      public string[] PermittedCarrier;
    }
  }

  public partial class QPXRequest
  {
    public class Request2
    {

      [JsonProperty("passengers")]
      public Passengers2 Passengers;

      [JsonProperty("slice")]
      public Slouse[] Slice;

      [JsonProperty("maxPrice")]
      public string MaxPrice;

      [JsonProperty("saleCountry")]
      public string SaleCountry;

      [JsonProperty("refundable")]
      public bool Refundable;

      [JsonProperty("solutions")]
      public int Solutions;
    }
  }

  public partial class QPXRequest
  {

    [JsonProperty("request")]
    public Request2 Request;
  }
}