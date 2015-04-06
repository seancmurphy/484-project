<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hotel_search.aspx.cs" Inherits="Final_Project.hotel_search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="hotelSearchBodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2 class="pageHeading">Select Your Hotel Options</h2>

  <br />

  <table>
    <tr>
      <td>
        <asp:TextBox ID="tbCheckin" runat="server" placeholder="Checkin Date DD/MM/YY" /><a runat="server" id="showCalendar1" onserverclick="calendar1_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar1" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
      </td>
      <td>
        <asp:TextBox ID="tbCheckout" runat="server" placeholder="Checkout Date DD/MM/YY" /><a runat="server" id="showCalendar2" onserverclick="calendar2_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar2" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" Visible="false" OnSelectionChanged="calendar2_SelectionChanged"></asp:Calendar>
      </td>
    </tr>
    <tr>
      <td><asp:TextBox ID="tbCity" runat="server" placeholder="City" /></td>
      <td>
        <label>Room Type </label>
        <select id="slRoomType" name="slRoomType" runat="server">
          <option value="Single">Single</option>
          <option value="Family">Family</option>
          <option value="Suite">Suite</option>
          <option value="Executive Suite">Executive Suite</option>
        </select>
      </td>
    </tr>
    <tr>
      <td>
        <label># of Rooms </label>
        <select id="slRooms" name="slRooms" runat="server">
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
          <option value="5">5</option>
          <option value="6">6</option>
          <option value="7">7</option>
          <option value="8">8</option>
          <option value="9">9</option>
        </select>
      </td>
      <td>
        <label># of Guests </label>
        <select id="slGuests" name="slGuests" runat="server">
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
          <option value="5">5</option>
          <option value="6">6</option>
          <option value="7">7</option>
          <option value="8">8</option>
          <option value="9">9</option>
        </select>
      </td>
    </tr>
    <tr>
      <td><asp:Button ID="btnSubmitSearch" CssClass="button-primary centerButton" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
      <td><asp:CheckBox id="cbPreference" runat="server" Text="Use Preferences " TextAlign="Left" /></td>
    </tr>
    <tr id="warningRow" runat="server" style="display:none;">
      <td><span id="warning" runat="server"></span></td>
    </tr>
  </table>
  
  <br />
  
  <br />

        <div>
          <hr />
            <!--result 1 table-->
            <asp:Table ID="result1" runat="server" HorizontalAlign="Center" Visible="false">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblHotelName1" runat="server" Text="Hotel Place!"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblPrice1" runat="server" Text="$99.99"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRating1" runat="server" Text="Rating: "></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCity1" runat="server" Text="Cityopolis"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblAddress1" runat="server" Text="1234 Road Street"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblFeatures1" runat="server" Text="Features: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnBuy1" runat="server" Text="Buy!" OnClick="btnBuy1_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <!--result 2 table-->
            <asp:Table ID="result2" runat="server" HorizontalAlign="Center" Visible="false">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblHotelName2" runat="server" Text="Hotel Place!"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblPrice2" runat="server" Text="$99.99"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRating2" runat="server" Text="Rating: "></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCity2" runat="server" Text="Cityopolis"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblAddress2" runat="server" Text="1234 Road Street"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblFeatures2" runat="server" Text="Features: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnBuy2" runat="server" Text="Buy!" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <!--result 3 table-->
            <asp:Table ID="result3" runat="server" HorizontalAlign="Center" Visible="false">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblHotelName3" runat="server" Text="Hotel Place!"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblPrice3" runat="server" Text="$99.99"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRating3" runat="server" Text="Rating: "></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCity3" runat="server" Text="Cityopolis"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblAddress3" runat="server" Text="1234 Road Street"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblFeatures3" runat="server" Text="Features: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnBuy3" runat="server" Text="Buy!"  />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
          </div>
</asp:Content>
