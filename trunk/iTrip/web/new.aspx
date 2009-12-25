<%@ page language="C#" autoeventwireup="true" inherits="web_new, App_Web_tmsbif71" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
<table width="490" border="0" align="center" cellpadding="0" cellspacing="0">
        </HeaderTemplate>
        <ItemTemplate>     
  <!--DWLayoutTable-->
  <tr>
    <td width="490" height="25" valign="top"><%# DataBinder.Eval(Container.DataItem, "title")%></td>
  </tr>
  <tr>
    <td height="22" valign="top"><%# DataBinder.Eval(Container.DataItem, "dtt")%></td>
  </tr>
  <tr>
    <td height="190" valign="top"><%# DataBinder.Eval(Container.DataItem, "content")%></td>
  </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
