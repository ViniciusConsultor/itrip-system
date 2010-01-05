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
	            <tr><td>注：<br />
                                        点击机票预定购物车（暂存）和宾馆预订购物车（暂存）可查看当前用户所预订的数据，暂存于用户Session中，但未入库。点击列表中的确认可以将当前数据保存至数据库中，然后在机票预定信息（已存）和宾馆预订信息（已存）列表中就可以看到刚才在暂存列表中已确认的数据。<br />
                            <br />
                            机票预定信息（已存）和宾馆预订信息（已存）可以查看已经预订的数据，点击列表中的<font color="ActiveCaption" 
                        style="font-weight: bold">付款</font>信息可进行付款操作；<font color="red" 
                        style="font-weight: bold">删除</font>可进行删除操作，已付款预订信息无法删除。</td></tr>
                        <tr><td><hr /></td></tr>
	            <tr><td>
                    <asp:Menu ID="Menu2" runat="server" Height="30px" 
                        MaximumDynamicDisplayLevels="0" Orientation="Horizontal" Width="100%" 
                        onmenuitemclick="Menu2_MenuItemClick" BorderStyle="None" Font-Bold="True" 
                        Font-Names="Arial Black" Font-Overline="False" Font-Size="X-Small" 
                        Font-Underline="True" PathSeparator="|">
                        <Items>                        
                        <asp:MenuItem Text="机票预定购物车(暂存)" Value="0" SeparatorImageUrl="~/Resource/NextStep.gif" ImageUrl="~/Resource/class_ar.gif" Selected="True"></asp:MenuItem>
                        <asp:MenuItem Text="机票预定信息(已存)" Value="1" SeparatorImageUrl="~/Resource/slipt_04.gif" ></asp:MenuItem>
                        
                        <asp:MenuItem Text="宾馆预定购物车(暂存)" Value="2" SeparatorImageUrl="~/Resource/NextStep.gif"></asp:MenuItem>
                        <asp:MenuItem Text="宾馆预定信息(已存)" Value="3"></asp:MenuItem>

                        </Items>
                    </asp:Menu>
                    </td></tr>
                <tr>
	                <td>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View3" runat="server" OnActivate="View3_OnActivate">
                                <asp:Panel ID="Panel3" runat="server" GroupingText="机票预定购物车(暂存)" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="FlightGridTSView" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="FLIGHT_ID,DISCOUNT_FARES,PERSON_COUNT" 
                                        Width="100%" 
                                        onrowcommand="FlightGridTSView_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="确 认">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblConfirmOrder" runat="server" ForeColor="ActiveCaption" CommandName="CONFIRM_TS" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="确 认"/>
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete0" runat="server" CommandName="DELETE_TS" ForeColor="Red" Text="删 除" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick ="return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DEPART_DATE" HeaderText="出发时间" DataFormatString ="{0:yyyy-MM-dd HH:mm}">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%"/>
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="AIR_PORT" HeaderText="机场">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="FROM" HeaderText="出发城市">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TO" HeaderText="抵达城市">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="AIRLINE_NAME" HeaderText="航空公司">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FLIGHT_TYPE" HeaderText="机型">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DISCOUNT_FARES" HeaderText="单价">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>    
                                            <asp:BoundField DataField="PERSON_COUNT" HeaderText="数量">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="总价(RMB)">
                                                <ItemTemplate>
                                                    <asp:Literal ID="IdLabel" runat="server" Text='<%# decimal.Parse(DataBinder.Eval(Container.DataItem,"DISCOUNT_FARES").ToString())*decimal.Parse(DataBinder.Eval(Container.DataItem,"PERSON_COUNT").ToString()) %>'></asp:Literal>       
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0,1" FixRows="-1" TableHeight="65px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp><asp:Label ID="Label23" runat="server" Text="确 认"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label24" runat="server" Text="删 除"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label1" runat="server" Text="出发时间"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label2" runat="server" Text="机场"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label3" runat="server" Text="出发城市"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label10" runat="server" Text="抵达城市"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label4" runat="server" Text="航空公司"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label5" runat="server" Text="机型"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label7" runat="server" Text="单价"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label8" runat="server" Text="数量"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label6" runat="server" Text="总价(RMB)"></asp:Label></th>
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
                            <asp:View ID="View1" runat="server" onactivate="View1_Activate">
                                <asp:Panel ID="Panel1" runat="server" GroupingText="机票预定信息(已存)" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="FlightGridView" runat="server" AllowSorting="True" 
                                        AutoGenerateColumns="False" DataKeyNames="FLIGHT_ORDER_ID,CONFIRM_FLAG" 
                                        onrowcommand="FlightGridView_RowCommand" 
                                        onrowdatabound="FlightGridView_RowDataBound" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" 
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                        CommandName="PAYMENT_ORDER" ForeColor="ActiveCaption" 
                                                        OnClientClick="return window.confirm('确定要付款吗？');" Text="付 款" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" ForeColor="GrayText" Text="已付款" 
                                                        Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" 
                                                    Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" 
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                        CommandName="DELETE_ORDER" ForeColor="Red" 
                                                        OnClientClick="return window.confirm('确定要删除信息？');" Text="删 除" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" 
                                                    Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FLIGHT_ORDER_ID" HeaderText="订单号">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEPART_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" 
                                                HeaderText="出发时间">
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
                                            <asp:BoundField DataField="PERSON_COUNT" HeaderText="预订数量">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FARE" HeaderText="总费用(RMB)">
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
                                                    <asp:Label ID="Label21" runat="server" Text="预订数量"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label18" runat="server" Text="总费用(RMB)"></asp:Label>
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
                            <asp:View ID="View4" runat="server" onactivate="View4_Activate">
                                <asp:Panel ID="Panel4" runat="server" GroupingText="宾馆预定购物车(暂存)" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="HotelGridTSView" runat="server" 
                                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ROOM_ID,DISCOUNT_FARES,CHECK_IN,CHECK_OUT,PRE_QUANTITY" 
                                        Width="100%" onrowcommand="HotelGridTSView_RowCommand">
                                        <Columns>
                                           <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="确 认">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblConfirmOrder" runat="server" ForeColor="ActiveCaption" CommandName="CONFIRM_TS" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="确 认"/>
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete1" runat="server" CommandName="DELETE_TS" 
                                                        ForeColor="Red" Text="删 除" 
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                        OnClientClick ="return window.confirm('确定要删除信息？');" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HOTEL_NAME" HeaderText="酒店名称">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_IN" DataFormatString="{0:yyyy-MM-dd}" 
                                                HeaderText="入住时间">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_OUT" DataFormatString="{0:yyyy-MM-dd}" 
                                                HeaderText="离店日期">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ROOM_TYPE" HeaderText="房型">
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
                                           
                                            <asp:BoundField DataField="DISCOUNT_FARES" HeaderText="单价">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PRE_QUANTITY" HeaderText="数量">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="总费用(RMB)">
                                                <ItemTemplate> 
                                                    <asp:Literal  ID="IdLabel" runat="server" Text='<%# decimal.Parse(DataBinder.Eval(Container.DataItem,"DISCOUNT_FARES").ToString())*decimal.Parse(DataBinder.Eval(Container.DataItem,"PRE_QUANTITY").ToString()) %>'></asp:Literal>       
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" HorizontalAlign="Center" Font-Bold="true" Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0,1" FixRows="-1" TableHeight="65px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp=""><asp:Label ID="Label32" runat="server" Text="确 认"></asp:Label></th>
                                                <th nowarp=""><asp:Label ID="Label33" runat="server" Text="删 除"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label3" runat="server" Text="酒店名称"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label8" runat="server" Text="入住时间"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label19" runat="server" Text="离店日期"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label10" runat="server" Text="房型"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label6" runat="server" Text="早餐"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label7" runat="server" Text="床型"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label20" runat="server" Text="宽带"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label26" runat="server" Text="单价"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label27" runat="server" Text="数量"></asp:Label></th>
                                                <th nowarp><asp:Label ID="Label25" runat="server" Text="总费用(RMB)"></asp:Label></th>
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
                            <asp:View ID="View2" runat="server" onactivate="View2_Activate">
                                <asp:Panel ID="Panel2" runat="server" GroupingText="宾馆预定信息(已存)" 
                                    HorizontalAlign="Left">
                                    <yyc:SmartGridView ID="HotelGridView" runat="server" AllowSorting="True" 
                                        AutoGenerateColumns="False" DataKeyNames="HOTEL_ORDER_ID,CONFIRM_FLAG" 
                                        onrowcommand="HotelGridView_RowCommand" 
                                        onrowdatabound="HotelGridView_RowDataBound" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="付款模拟">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtPaymentStatus" runat="server" 
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                        CommandName="PAYMENT_ORDER" ForeColor="ActiveCaption" 
                                                        OnClientClick="return window.confirm('确定要付款吗？');" Text="付 款" />
                                                    <asp:Label ID="lblPaymentStatus" runat="server" ForeColor="GrayText" Text="已付款" 
                                                        Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" 
                                                    Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="删 除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" 
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                        CommandName="DELETE_ORDER" ForeColor="Red" 
                                                        OnClientClick="return window.confirm('确定要删除信息？');" Text="删 除" />
                                                </ItemTemplate>
                                                <HeaderStyle Height="25px" HorizontalAlign="Center" Width="8%" Wrap="False" />
                                                <ItemStyle BorderStyle="Double" Font-Bold="true" HorizontalAlign="Center" 
                                                    Width="8%" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HOTEL_ORDER_ID" HeaderText="订单号">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HOTEL_NAME" HeaderText="酒店名称">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_IN" DataFormatString="{0:yyyy-MM-dd}" 
                                                HeaderText="入住时间">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHECK_OUT" DataFormatString="{0:yyyy-MM-dd}" 
                                                HeaderText="离店日期">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ROOM_TYPE" HeaderText="房型">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BREAKFAST" HeaderText="早餐">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BED_TYPE" HeaderText="床型">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NET_WORK" HeaderText="宽带">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                               <asp:BoundField DataField="PRE_QUANTITY" HeaderText="预订数量">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FARE" HeaderText="总费用(RMB)">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FixRowColumn FixColumns="0,1" FixRows="-1" TableHeight="65px" 
                                            TableWidth="580px" />
                                        <EmptyDataTemplate>
                                            <tr class="GridViewHeaderStyle">
                                                <th nowarp="">
                                                    <asp:Label ID="Label9" runat="server" Text="付款模拟"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label17" runat="server" Text="删 除"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label1" runat="server" Text="订单号"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label3" runat="server" Text="酒店名称"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label2" runat="server" Text="入住时间"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label4" runat="server" Text="离店日期"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label10" runat="server" Text="房型"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label6" runat="server" Text="早餐"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label7" runat="server" Text="床型"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label8" runat="server" Text="宽带"></asp:Label>
                                                </th>
                                                 <th nowarp="">
                                                    <asp:Label ID="Label28" runat="server" Text="预订数量"></asp:Label>
                                                </th>
                                                <th nowarp="">
                                                    <asp:Label ID="Label29" runat="server" Text="总费用(RMB)"></asp:Label>
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
