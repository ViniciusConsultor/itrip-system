<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IsPageControl.ascx.cs"
    Inherits="iTrip.Controls.IsPageControl" %>
<div id="tabs11" style="font-size: 12px; line-height: 20px; margin-bottom: 0px;">
    <asp:ImageButton ID="ImageButtonFirst" runat="server" OnClick="ImageButtonFirst_Click"
        ImageUr="~/Resource/img_page/first.gif" Style="border-width: 0px;" 
        align="absmiddle" ImageUrl="~/Resource/img_page/first.gif" />
    <asp:ImageButton ID="ImageButtonPre" runat="server" Style="border-width: 0px;" align="absmiddle"
        OnClick="ImageButtonPre_Click" ImageUrl="~/Resource/img_page/pre.gif" />&nbsp;
        <asp:Label ID="Label1" runat="server" Text="共"></asp:Label>&nbsp;
        <asp:Label ID="LabeltotalCount" runat="server" Text="0"></asp:Label>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="条记录"></asp:Label>&nbsp;
        <asp:Label ID="Label3" runat="server" Text="当前第"></asp:Label>&nbsp;
        <asp:Label ID="LabelcurrentPage" runat="server" Font-Size="12px" Text="0"></asp:Label>&nbsp;
        <asp:Label ID="Label4" runat="server" Text="页"></asp:Label>&nbsp;
    <asp:Label ID="Label5" runat="server" Text="共"></asp:Label>&nbsp;
    <asp:Label ID="LabelTotalPage" runat="server" Text="0"></asp:Label>&nbsp;
    <asp:Label ID="Label6" runat="server" Text="页"></asp:Label>&nbsp;
    <asp:ImageButton ID="ImageButtonNext" runat="server" OnClick="ImageButtonNext_Click"
        ImageUrl="~/Resource/img_page/next.gif" Style="border-width: 0px;" align="absmiddle" />
    <asp:ImageButton ID="ImageButtonLast" runat="server" OnClick="ImageButtonLast_Click"
        ImageUrl="~/Resource/img_page/last.gif" Style="border-width: 0px;" align="absmiddle" />
</div>
