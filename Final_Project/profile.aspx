<%@ Page Title="Edit Your Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="profile.aspx.cs" Inherits="Final_Project.profile" %>

<asp:Content runat="server" ID="editProfileContent" ContentPlaceHolderID="MainContent">
      
      <span class="pageHeading" runat="server" id="notify" style="display:none;"></span>

      <table>
        <tr>
          <th>Basic Information</th>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="tbEmpId" runat="server" CssClass="ugh"  ReadOnly="True" placeholder="Employee ID" /></td>
        </tr>
        <tr>
          <td><asp:TextBox ID="tbFirstName" runat="server" CssClass="ugh" placeholder="First Name" /></td>
          <td><asp:TextBox ID="tbLastName" runat="server" CssClass="ugh" placeholder="Last Name" /></td>
        </tr>
        <tr>
          <td><asp:Textbox ID="tbAddyLineOne" runat="server" CssClass="ugh" placeholder="Address Line One" /></td>
          <td><asp:Textbox ID="tbAddyLineTwo" runat="server" placeholder="Address Line Two" /></td>
        </tr>
        <tr>
          <td><asp:Textbox ID="tbCity" runat="server" CssClass="ugh" placeholder="City" /></td>
          <td><asp:Label ID="Label21" runat="server" Text="State"> <asp:DropDownList ID="DDLState" runat="server" DataSourceID="srcState" DataTextField="Code"></asp:DropDownList></asp:Label></td>
        </tr>
        <tr>
          <td><asp:Textbox ID="tbPostalCode" runat="server" placeholder="Zip Code" /></td>
          <td><asp:Textbox ID="tbPhone" runat="server" placeholder="Phone Number" /></td>
        </tr>
      </table>
      
      <br />
      
    <asp:SqlDataSource ID ="srcState" SelectCommand="select code from state;" ConnectionString="Server=LOCALHOST; Database=KPMG; Trusted_Connection=Yes;" Runat="server">
                    </asp:SqLDataSource>

      <table>
        <tr>
          <th>Credit Card Information</th>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="tbCardNum" runat="server" CssClass="ugh" placeholder="Card Number" /></td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="DDLMonth" runat="server" ></asp:DropDownList>
              &nbsp;<span>/</span>&nbsp;
              <asp:DropDownList ID="DDLYear" runat="server"></asp:DropDownList>
          </td>
          <td><asp:TextBox ID="tbCardSecCode" runat="server" placeholder="Security Code" /></td>
        </tr>
      </table>

      <br />
      <br />

      <table>
        <tr>
          <th>Preferences</th>
        </tr>
        <tr>
          <td>Preferred Airline:</td>
          <td><asp:TextBox ID="tbPrefAirline" runat="server" placeholder="Preferred Airline" /></td>
          <td><asp:TextBox ID="tbAirlineRewards" runat="server" placeholder="Rewards Number" /></td>
        </tr>
        <tr>
          <td>Preferred Hotel Provider:</td>
          <td><asp:TextBox ID="tbPrefHotel" runat="server" placeholder="Preferred Hotel Chain" /></td>
          <td><asp:TextBox ID="tbHotelRewards" runat="server" placeholder="Rewards Number" /></td>
        </tr>
        <tr>
          <td>Preferred Car Service:</td>
          <td><asp:TextBox ID="tbPrefCar" runat="server" placeholder="Preferred Car Service" /></td>
          <td><asp:TextBox ID="tbCarRewards" runat="server" placeholder="Rewards Number" /></td>
        </tr>
      </table>

      <br />

      <table>
        <tr>
          <td><asp:Button runat="server" ID="btnSave" CssClass="button-primary" OnClick="btnSave_Click" Text="Save Changes" /></td>
        </tr>
      </table>

</asp:Content>