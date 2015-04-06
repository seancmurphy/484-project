<%@ Page Title="Start Your Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="Final_Project.booking" %>

<asp:Content ID="startBodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
  <h2 class="pageHeading">What would you like to book today?</h2>
  <br />
  <br />
  <h3 id="inst" class="login">Select all that apply:</h3>
  <br />
  <asp:DropDownList runat="server" ID="ddlWho" CssClass="login" DataSourceID="ddlWhoDataSource" Visible="false" />
  <asp:SqlDataSource ID="ddlWhoDataSource"
    runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
    SelectCommand="" />
  <br />
  <br />
  <div class="center">
    <table class="searchtable">
      <tr id="selectRow" runat="server">
        <td><asp:CheckBox ID="FlightCheckBox" runat="server" Text=" Flight" /></td>
        <td><asp:CheckBox ID="TrainCheckBox" runat="server" Text=" Train" /></td>
        <td><asp:CheckBox id="HotelCheckBox" runat="server" Text=" Hotel" /></td>
        <td><asp:CheckBox ID="CarCheckBox" runat="server" Text=" Car" /></td>
      </tr>
    </table>

    <br /><br />

    <div class="center" runat="server" id="searchWarning"></div>
      <asp:Button ID="btnSelect" CssClass="button button-primary" runat="server" Text="Next" OnClick="btnSelect_Click" />
    </div>

</asp:Content>
