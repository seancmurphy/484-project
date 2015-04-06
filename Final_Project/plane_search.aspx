<%@ Page Title="Search for Plane" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="plane_search.aspx.cs" Inherits="Final_Project.search" %>

<asp:Content ID="searchBodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
  <h2 class="pageHeading">Select Your Flight Options</h2>

  <br />

  <table>
    <tr>
      <td>
        <asp:TextBox ID="tbDepartureDate" runat="server" placeholder="Departure Date DD/MM/YY" /><a runat="server" id="A1" onserverclick="calendar1_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar1" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
      </td>
      <td>
        <asp:TextBox ID="tbArrivalDate" runat="server" placeholder="Arrival Date DD/MM/YY" /><a runat="server" id="showCalendar2" onserverclick="calendar2_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar2" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" Visible="false" OnSelectionChanged="calendar2_SelectionChanged"></asp:Calendar>
      </td>
    </tr>
    <tr>
      <td><asp:TextBox ID="tbFromCity" runat="server" placeholder="Departure City" /></td>
      <td><asp:TextBox ID="tbToCity" runat="server" placeholder="Arrival City" /></td>
    </tr>
    <tr>
      <td><asp:Button ID="btnSubmitSearch" CssClass="button-primary centerButton" runat="server" Text="Search" /></td>
      <td><asp:CheckBox id="cbPreference" runat="server" Text="Use Preferences " TextAlign="Left" <!--OnCheckedChange="prefCheck_CheckedChange"--> /></td>
    </tr>
  </table> 

</asp:Content>
