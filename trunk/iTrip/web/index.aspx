<%@ page language="C#" autoeventwireup="true" inherits="page_index, App_Web_tmsbif71" %>

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
       <table>
       <table width="400" border="0">
       </HeaderTemplate>
       <ItemTemplate>
       <tr>
    <td><table width="400" border="0" style="border-bottom:#CCCCCC 1px dashed">
      <tr>
        <td>
        </td><ASP:hyperlink   id=Hyperlink1   title='<%#DataBinder.Eval(Container.DataItem,"title").ToString()%>' runat="server" Text='<%#FormatString_Size_40(DataBinder.Eval(Container.DataItem,"title").ToString())%>'   NavigateUrl='<%#"~/web/new.aspx?id="+DataBinder.Eval(Container.DataItem,"id").ToString()%>'   NAME="Hyperlink1">   
         </ASP:hyperlink>
      </tr>
    </table></td>
  </tr> 
       </ItemTemplate>
       <FooterTemplate>
       </table>
       </FooterTemplate>
       </asp:Repeater></div>
    </form>
</body>
</html>
