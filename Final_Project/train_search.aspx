<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="train_search.aspx.cs" Inherits="Final_Project.train_search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <table>
    <tr>
      <th>Departure Station</th>
      <th>Arrival Station</th>
    </tr>
    <tr>
      <td><asp:DropDownList ID="ddlTo" DataSourceID="srcFrom" DataTextField="From_Station_City" runat="server" /></td>
      <td><asp:DropDownList ID="ddlFrom" DataSourceID="srcFrom" DataTextField="From_Station_City" runat="server" /></td>
    </tr>
  </table>

  <asp:Label ID="lblError" runat="server" CssClass="pageHeading" ForeColor="#FF3300" Visible="false"></asp:Label>

  <br />

  <table>
    <tr>
      <th>Departure Date</th>
      <th>Return Date</th>
    </tr>
    <tr>
      <td>
        <asp:TextBox ID="tbDepartureDate" runat="server" placeholder="Departure Date DD/MM/YY" /><a runat="server" id="A1" onserverclick="calendar1_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar1" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
      </td>
      <td>
        <asp:TextBox ID="tbReturnDate" runat="server" placeholder="Arrival Date DD/MM/YY" /><a runat="server" id="showCalendar2" onserverclick="calendar2_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar2" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" Visible="false" OnSelectionChanged="calendar2_SelectionChanged"></asp:Calendar>
      </td>
    </tr>
  </table>
  
  <br />
    
  <asp:Label ID="lblCalError" runat="server" CssClass="pageHeading" ForeColor="Red" Visible="false"></asp:Label>
  
  <br />
  
  <div class="pageHeading">
    <asp:Button ID="Button1" runat="server" Text="Go" CssClass="button-primary" OnClick="Button1_Click" />
  </div>
  
  <table id="tableTrainResults" runat="server">
    <tr>
      
    </tr>
  </table>
    
  <asp:Panel ID="Panel2" runat="server" Height="425px">
    <asp:Label ID="Label12" runat="server" Text="Departure Trip: " Visible="False"></asp:Label>
    <asp:Label ID="lblDepart" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label13" runat="server" Text="Return Trip: " Visible="False"></asp:Label>
    <asp:Label ID="lblReturn" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
  </asp:Panel>
    
  <asp:SqlDataSource ID ="srcFrom" SelectCommand="select distinct From_Station_City from dbo.Train_Schedule order by From_Station_City;" ConnectionString="Server=LOCALHOST; Database=KPMG; Trusted_Connection=Yes;" Runat="server">
              </asp:SqLDataSource>

  <asp:SqlDataSource ID ="srcState" SelectCommand="select code from state;" ConnectionString="Server=LOCALHOST; Database=KPMG; Trusted_Connection=Yes;" Runat="server">
              </asp:SqLDataSource>
</asp:Content>
