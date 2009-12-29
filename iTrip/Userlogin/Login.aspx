<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="iTrip.UserLogin.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Login</title>
    <!-- #include file="../BasePage/style.html" -->
  </head>
  <body>
	
    <form id="Form1" method="post" runat="server">

        <div align="center">
        <table style="padding-top:60%">
        <tr><td>Username: <asp:TextBox Runat="server" ID="UserName" CssClass="TextWidth"></asp:TextBox></td></tr>
        <tr><td>Password: <asp:TextBox Runat="server" ID="Password" TextMode="Password" CssClass="TextWidth"></asp:TextBox></td></tr>
        <tr><td><asp:Button Runat="server" ID="btnSubmit" Text="Logon" CssClass="Button" 
                onclick="btnSubmit_Click1"></asp:Button></td></tr>
        </table>
        </div>
     </form>
	
  </body>
</html>
