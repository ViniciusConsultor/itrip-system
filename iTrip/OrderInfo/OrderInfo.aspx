<%@ Page Language="C#" MasterPageFile="~/Basepage/iTrip_Main.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="iTrip.OrderInfo.OrderInfo" %>
<%@ Register assembly="YYControls" namespace="YYControls" tagprefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="../Resource/res01_attpic_briefaa.JPG" height="100%" style="width: 98%" alt="咨询信息" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table  style="width:100%;">
    <tr>
        <td valign="top" height="20">
            <table style="width:100%;">
                 <asp:panel id="pnl" Runat="server" Visible="False">
		            <TR>
			            <td height="0" colspan="6" align="left">
			            <div style="padding-left:10px"><fieldset><asp:label id="lblInfoMessage" Runat="server" ForeColor="#ff0000"></asp:label></fieldset></div>
		              </TD>
		            </TR>
	            </asp:panel>
	            <tr><td>
                    <asp:Menu ID="Menu2" runat="server" Height="30px" 
                        MaximumDynamicDisplayLevels="0" Orientation="Horizontal" Width="60%" 
                        onmenuitemclick="Menu2_MenuItemClick" BorderStyle="None" Font-Bold="True" 
                        Font-Names="Arial Black" Font-Overline="False" Font-Size="X-Small" 
                        Font-Underline="True" PathSeparator="|">
                        <Items>
                        <asp:MenuItem Text="机票预定信息" Value="0"></asp:MenuItem>
                        <asp:MenuItem Text="宾馆预定信息" Value="1"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                    </td></tr>
                <tr>
	                <td>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View1" runat="server">
                                <asp:Panel ID="Panel1" runat="server" GroupingText="机票预定信息" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="FlightGridView" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="FLIGHT_ORDER_ID,CONFIRM_FLAG" 
                                        Width="100%" 
                                        onrowcommand="FlightGridView_RowCommand" 
                                        onrowdatabound="FlightGridView_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="FLIGHT_ORDER_ID" HeaderText="订单号">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEPART_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="出发时间">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AIR_PORT" HeaderText="机场">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FROM" HeaderText="出发城市">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TO" HeaderText="抵达城市">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AIRLINE_NAME" HeaderText="航空公司">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FARE" HeaderText="票价">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款信息模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" ForeColor="ActiveCaption" CommandName="PAYMENT_ORDER" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="付 款" OnClientClick ="return window.confirm('确定要付款吗？');" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" ForeColor="GrayText" Text="已付款" Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删除操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DELETE_ORDER" ForeColor="Red" Text="删 除" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0" FixRows="-1" TableHeight="98px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp="">
                                                    <asp:Label ID="Label1" runat="server" Text="订单号"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label12" runat="server" Text="出发时间"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label13" runat="server" Text="机场"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label14" runat="server" Text="出发城市"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label15" runat="server" Text="抵达城市"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label16" runat="server" Text="航空公司"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label18" runat="server" Text="票价"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label11" runat="server" Text="付款信息"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label22" runat="server" Text="删除操作"></asp:Label>
                                                </th>
                                            </tr>
                                        </EmptyDataTemplate>
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <PagerStyle BackColor="White" CssClass="GridViewPagerStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    </yyc:SmartGridView>
                                </asp:Panel>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:Panel ID="Panel2" runat="server" GroupingText="宾馆预定信息" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="HotelGridView" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%">
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="FLIGHT_ORDER_ID" HeaderText="订单号">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEPART_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="出发时间">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AIR_PORT" HeaderText="机场">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FROM" HeaderText="出发城市">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TO" HeaderText="抵达城市">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AIRLINE_NAME" HeaderText="航空公司">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DISCOUNT_FARES" HeaderText="票价">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款信息模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" CommandName="Select" CommandArgument="0" Text="付 款" OnClientClick ="return return window.confirm('确定要付款吗？');" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" Text="已付款" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删除操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" CommandName="Select" Text="删 除" CommandArgument="1"  OnClientClick ="return return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0" FixRows="-1" TableHeight="98px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp="">
                                                    <asp:Label ID="Label1" runat="server" Text="订单号"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label12" runat="server" Text="出发时间"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label13" runat="server" Text="机场"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label14" runat="server" Text="出发城市"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label15" runat="server" Text="抵达城市"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label16" runat="server" Text="航空公司"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label18" runat="server" Text="票价"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label11" runat="server" Text="付款信息"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label22" runat="server" Text="删除操作"></asp:Label>
                                                </th>
                                            </tr>
                                        </EmptyDataTemplate>
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <PagerStyle BackColor="White" CssClass="GridViewPagerStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    </yyc:SmartGridView>
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
