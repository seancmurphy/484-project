<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="train_search.aspx.cs" Inherits="Final_Project.train_search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <table>
    <tr>
      <th>Departure Station</th>
    </tr>
    <tr>
      <td><asp:DropDownList ID="ddlTo" DataSourceID="srcFrom" DataTextField="From_Station_City" runat="server" /></td>
    </tr>
  </table>

  <table>
    <tr>
      <th>Arrival Station</th>
    </tr>
    <tr>
      <td><asp:DropDownList ID="ddlFrom" DataSourceID="srcFrom" DataTextField="From_Station_City" runat="server" /></td>
    </tr>
  </table>
  
  <br />

  <asp:Label ID="lblError" runat="server" CssClass="pageHeading" ForeColor="#FF3300"></asp:Label>

  <br />

  <table>
    <tr>
      <th>Departure Date</th>
    </tr>
    <tr>
      <td>
        <asp:TextBox ID="tbDepartureDate" runat="server" placeholder="Departure Date DD/MM/YY" /><a runat="server" id="A1" onserverclick="calendar1_Click">  <i class="fa fa-calendar black"></i></a>
        <asp:Calendar ID="Calendar1" runat="server" TitleStyle-VerticalAlign="Middle" TitleStyle-HorizontalAlign="Center" Width="250px" Height="250px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
      </td>
    </tr>
  </table>

  <table>
    <tr>
      <th>Return Date</th>
    </tr>
  </table>

    
    <br />
    <asp:Label ID="Label3" runat="server" Text="Departure Date"></asp:Label>
    <asp:Calendar ID="CalendarTO" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:Label ID="Label11" runat="server" Text="Return Date"></asp:Label>
    <br />
    <asp:Calendar ID="CalReturn" runat="server"></asp:Calendar>
    <asp:Label ID="lblCalError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
    <br />
    <br />
    
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
