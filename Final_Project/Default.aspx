<%@ Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Final_Project._Default" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Please Log In</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>  
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,500,700&subset=latin,vietnamese' rel='stylesheet' type='text/css'>
    <link href="Content/normalize.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/skeleton.css">
    <link href="Content/main.css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=272931&clcid=0x409 --%>
            <%--Framework Scripts--%>
            
            <asp:ScriptReference Name="MsAjaxBundle" />
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Name="jquery.ui.combined" />
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site Scripts--%>

        </Scripts>
    </asp:ScriptManager>

    <div id="container">
        <img src="Images/banner.png" id="loginBanner"/>
        <div class="loginVertSpace">

          <h1 id="welcome" class="login" runat="server">Welcome to KPMG Travel Booking</h1>

          <h3 id="inst" class="login spacer" runat="server">Please log in:</h3>

          <div class="center">
            <asp:CheckBox ID="CheckBox1" TextAlign="right" runat="server" AutoPostBack="true" OnCheckedChanged="languageChange_CheckedChange" Text=" Tiếng Việt" />
          </div>

          <div class="center" id="warning" runat="server" style="display:none;">
            <span id="warningText" runat="server"></span>
          </div>

          <br />

          <div class="center">
            <input id="usernameInput" type="text" name="Username" placeholder="Username" runat="server" />
            <br />
            <input id="passwordInput" type="password" name="Password" placeholder="Password" runat="server" />
            <br /><br />
            <asp:Button ID="btnSubmit" CssClass="button-primary" runat="server" Text="Log In" OnClick="demoLoginButton_Click" />
          </div>
          <br />
          <div class="center">

            <a id="forgotPassword" href="forgotPassword.aspx" runat="server">Forget your password?</a>

          </div>
        </div>
        
        <div class="footer">

          <span>For assistance, please call 1-800-KPMG-HELP</span>
          
        </div>
        
      </div>
    </form>
</body>
</html>
