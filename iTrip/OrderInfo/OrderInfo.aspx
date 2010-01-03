<%@ Page Language="C#" MasterPageFile="~/Basepage/iTrip_Main.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="iTrip.OrderInfo.OrderInfo" %>
<%@ Register assembly="YYControls" namespace="YYControls" tagprefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>预订信息管理</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="../Resource/20099517235411.jpg" height="100%" style="width: 220px" 
        alt="咨询信息" />
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
	            <tr><td>注：点击机票预定信息和宾馆预订信息可以查看已经预订的数据，点击列表中的<font color="ActiveCaption" 
                        style="font-weight: bold">付款</font>信息可进行付款操作；<font color="red" 
                        style="font-weight: bold">删除</font>可进行删除操作，已付款预订信息无法删除。</td></tr>
                        <tr><td><hr /></td></tr>
	            <tr><td>
                    <asp:Menu ID="Menu2" runat="server" Height="30px" 
                        MaximumDynamicDisplayLevels="0" Orientation="Horizontal" Width="60%" 
                        onmenuitemclick="Menu2_MenuItemClick" BorderStyle="None" Font-Bold="True" 
                        Font-Names="Arial Black" Font-Overline="False" Font-Size="X-Small" 
                        Font-Underline="True" PathSeparator="|">
                        <Items>
                        <asp:MenuItem Text="机票预定信息" Value="0" ImageUrl="~/Resource/class_ar.gif" 
                                Selected="True"></asp:MenuItem>
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
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" ForeColor="ActiveCaption" CommandName="PAYMENT_ORDER" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="付 款" OnClientClick ="return window.confirm('确定要付款吗？');" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" ForeColor="GrayText" Text="已付款" Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DELETE_ORDER" ForeColor="Red" Text="删 除" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
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
                                            <asp:BoundField DataField="FARE" HeaderText="票价(RMB)">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0,1" FixRows="-1" TableHeight="65px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp="">
                                                    <asp:Label ID="Label11" runat="server" Text="付款模拟"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label22" runat="server" Text="删 除"></asp:Label>
                                                </th>
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
                                                    <asp:Label ID="Label18" runat="server" Text="票价(RMB)"></asp:Label>
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
                                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="HOTEL_ORDER_ID,CONFIRM_FLAG" 
                                        Width="100%" 
                                        onrowcommand="HotelGridView_RowCommand" 
                                        onrowdatabound="HotelGridView_RowDataBound">
                                        <Columns>
                                           <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" ForeColor="ActiveCaption" CommandName="PAYMENT_ORDER" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="付 款" OnClientClick ="return window.confirm('确定要付款吗？');" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" ForeColor="GrayText" Text="已付款" Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DELETE_ORDER" ForeColor="Red" Text="删 除" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HOTEL_ORDER_ID" HeaderText="订单号">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HOTEL_NAME" HeaderText="酒店名称">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_IN" HeaderText="入住时间" DataFormatString="{0:yyyy-MM-dd}">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_OUT" HeaderText="离店日期" DataFormatString="{0:yyyy-MM-dd}">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="ROOM_TYPE" HeaderText="房型">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="FARE" HeaderText="价格(RMB)">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BREAKFAST" HeaderText="早餐">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BED_TYPE" HeaderText="床型">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NET_WORK" HeaderText="宽带">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0,1" FixRows="-1" TableHeight="65px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp=""><asp:Label ID="Label9" runat="server" Text="付款模拟"></asp:Label></th>
                                                <th nowarp=""><asp:Label ID="Label17" runat="server" Text="删 除"></asp:Label></th>
                                                <th nowarp=""><asp:Label ID="Label1" runat="server" Text="订单号"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label3" runat="server" Text="酒店名称"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label2" runat="server" Text="入住时间"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label4" runat="server" Text="离店日期"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label10" runat="server" Text="房型"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label5" runat="server" Text="价格(RMB)"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label6" runat="server" Text="早餐"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label7" runat="server" Text="床型"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label8" runat="server" Text="宽带"></asp:Label></th>
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
