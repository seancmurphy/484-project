<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Final_Project.CreateUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="center">
    <input id="usernameInput" type="text" name="Username" placeholder="Username" runat="server" />
    <br /><br />
    <input id="passwordInput" type="password" name="Password" placeholder="Password" runat="server" />
    <br /><br /><br />
    <asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="Create" OnClick="btnSubmit_Click" />
    <asp:Button ID="Button1" CssClass="btnSubmit" runat="server" Text="check" OnClick="btnCheck_Click" />
  </div>

  <span runat="server" id="crap"> </span>

  <!-- user_id, user_password_hash, user_password_salt, user_modified_date -->
</asp:Content>
