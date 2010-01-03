<%@ Page Language="C#" MasterPageFile="~/Basepage/iTrip_Main.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="iTrip.User.UserManage" %>
<%@ Register assembly="YYControls" namespace="YYControls" tagprefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户信息管理</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="../Resource/services.jpg" height="100%" style="width: 220px" alt="咨询信息" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table  style="width:100%;">
    <tr>
        <td valign="top" height="20">
            <table style="width:100%;">		            
                 <tr>
			     <td height="0" colspan="6" align="left">
                 <asp:panel id="pnl" Runat="server" Visible="False" Width="100%">
			     <div style="padding-left:10px"><fieldset style="width: 100%"><asp:label id="lblInfoMessage" Runat="server" ForeColor="#ff0000"></asp:label></fieldset></div>
	            </asp:panel>   
	            </td>
		        </tr>
	            <tr><td>
                    <asp:Menu ID="Menu2" runat="server" Height="30px" 
                        MaximumDynamicDisplayLevels="0" Orientation="Horizontal" Width="64%" 
                        onmenuitemclick="Menu2_MenuItemClick" BorderStyle="None" Font-Bold="True" 
                        Font-Names="Arial Black" Font-Overline="False" Font-Size="X-Small" 
                        Font-Underline="True" PathSeparator="|">
                        <Items>
                        <asp:MenuItem Text="修改密码" Value="0" ImageUrl="~/Resource/user_123.jpg" Selected="True"></asp:MenuItem>
                        <asp:MenuItem Text="其他信息" Value="1"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                    </td></tr>
                <tr>
	                <td>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View1" runat="server">
                                <asp:Panel ID="Panel1" runat="server" GroupingText="修改密码" 
                                    HorizontalAlign="Left">
                                    <table style="width:100%;">
                                        <tr>
                                            <td height="0" colspan="2" align="left" valign="top">
                                            <asp:panel id="Panel3" Runat="server" Visible="False" Width="100%">
                                            <div style="padding-left:10px"><fieldset><asp:label id="Label1" Runat="server" ForeColor="#ff0000"></asp:label></fieldset></div>
                                            </asp:panel></td>
                                        </tr>
                                        <tr><td colspan="2"><hr /></td></tr>
                                        <tr>
                                            <td>用户名</td>
                                            <td><asp:TextBox ID="txtUserName" runat="server" CssClass="TextWidth" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>原始密码</td>
                                            <td><asp:TextBox ID="txtOriginPassword" runat="server" CssClass="TextWidth" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>新密码</td>
                                            <td><asp:TextBox ID="txtNewPassword" runat="server" CssClass="TextWidth" TextMode="Password" MaxLength="15"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>确认新密码</td>
                                            <td><asp:TextBox ID="txtReconfirmPassword" runat="server" CssClass="TextWidth" TextMode="Password" MaxLength="15"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2"><asp:Button ID="btnConfirm" CssClass="Button" runat="server" Text="确 认" onclick="btnConfirm_Click" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:Panel ID="Panel2" runat="server" GroupingText="其他信息" 
                                    HorizontalAlign="Left" Height="150px" Width="100%">
                                    <div style="color:Red;font-size: xx-large; font-weight: bold; font-family: 'Bodoni MT Poster Compressed'">Under construction...</div>
                                </asp:Panel>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    </table>
</asp:Content>
