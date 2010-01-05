<%@ Page Language="C#" MasterPageFile="~/Basepage/iTrip_Main.Master" AutoEventWireup="true" CodeBehind="Flight.aspx.cs" Inherits="iTrip.Flight.Flight" %>
<%@ Register assembly="YYControls" namespace="YYControls" tagprefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>航班信息查询</title>
    <style> 
        .black_overlay{ 
            display: none; 
            position: absolute; 
            top: 0%; 
            left: 0%; 
            width: 100%; 
            height: 100%; 
            background-color: #FFF5EE; 
            z-index:1001; 
            -moz-opacity: 0.8; 
            opacity:.80; 
            filter: alpha(opacity=88); 
        } 
        .white_content { 
            display: none; 
            position: absolute; 
            top: 25%; 
            left: 25%; 
            width: 55%; 
            height: 55%; 
            padding: 20px; 
            border: 10px solid orange; 
            background-color: white; 
            z-index:1002; 
            overflow: auto; 
        } 
    </style> 
    <script type="text/javascript">
function on_KeyPress_Decimal() {
	var value=event.srcElement.value;
	var kc=event.keyCode;
	if(kc<32 || (kc>47 && kc<58) || (kc==45 && value.indexOf("\-")==-1)) {
		return true;
	}
	return false;
}

function on_KeyUp_Decimal(decimalPlaces) 
{
    if(decimalPlaces==undefined)
    {
        decimalPlaces=0;
    }
        
	var obj=event.srcElement;
	var value=obj.value;
	var re=/(\..{0}).+$/;

	if(value.indexOf("\-")>0) {
		obj.value=value.replace("\-","");
	} else if(re.test(value)) {
		obj.value=value.replace(re,"$1");
	}	
}
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="../Resource/res01_attpic_briefaa.JPG" height="100%" style="width: 220px" alt="咨询信息" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table  style="width:100%; height: 348px;">
    <tr>
        <td colspan="2" valign="top" height="20">
            <table style="width:100%;">
                 <asp:panel id="pnl" Runat="server" Visible="False">
		            <TR>
			            <td height="0" colspan="6" align="left">
			            <div style="padding-left:10px"><fieldset><asp:label id="lblInfoMessage" Runat="server" ForeColor="#ff0000"></asp:label></fieldset></div>
		              </TD>
		            </TR>
	            </asp:panel>
                <tr>
	                <td>
	                <asp:panel id="SearchCondition" Runat="server" GroupingText="机票查询">
	                <table height="20" width="100%">
	                <tr>
	                <td class="td" nowarp>出发城市</td>
	                <td class="td_left"><asp:DropDownList ID="ddlFromCity" runat="server"  CssClass="TextWidth"></asp:DropDownList></td>
	                <td class="td" nowarp>到达城市</td>
	                <td class="td_left"><asp:DropDownList ID="ddlToCity" runat="server"  CssClass="TextWidth"></asp:DropDownList></td>
	                </tr>
	                <tr>
	                <td class="td" nowarp>出发日期</td>
	                <td class="td_left"><asp:TextBox ID="txtDepartDate" runat="server"  CssClass="TextWidth Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox></td>
	                <td class="td" nowarp>送票城市</td>
	                <td class="td_left"><asp:TextBox ID="txtDeliveryCity" runat="server"  CssClass="TextWidth"></asp:TextBox></td>
	                </tr>
	                <tr>
	                <td class="td" nowarp>航空公司</td>
	                <td class="td_left"><asp:DropDownList ID="ddlAirLine" runat="server"  CssClass="TextWidth"></asp:DropDownList></td>
	                <td class="td" nowarp>乘客人数</td>
	                <td class="td_left">
                        <asp:DropDownList ID="ddlPersonCount" runat="server" CssClass="TextWidth">
                        <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        </asp:DropDownList>
                        </td>
	                </tr>
	                <tr><td colspan="4" align="center">
	                <div style="padding-top:10px;padding-bottom:5px">
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Resource/HaoSc32_1324_200525152843734.gif" 
                            onclick="ImageButton1_Click" />
                            </div>
                        </td></tr>
	                </table>
	                </asp:panel>
	                </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left" valign="top">
            <asp:Panel ID="Panel1" runat="server" GroupingText="机票信息"
                HorizontalAlign="Left">
            <yyc:SmartGridView ID="FlightGridView" runat="server" Width="100%" 
                    AllowSorting="True" DataKeyNames="FLIGHT_ID,DISCOUNT_FARES" 
                    AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="FlightGridView_PageIndexChanging" 
                    onselectedindexchanged="FlightGridView_SelectedIndexChanged">
                <PagerSettings Position="Top" FirstPageImageUrl="~/Resource/img_page/first.gif" 
                    LastPageImageUrl="~/Resource/img_page/last.gif" Mode="NextPreviousFirstLast" 
                    NextPageImageUrl="~/Resource/img_page/next.gif" 
                    PreviousPageImageUrl="~/Resource/img_page/pre.gif" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /><Columns>                       
                        <asp:TemplateField HeaderText="预订"  HeaderStyle-Wrap="false">
                        <ItemTemplate>
                        <asp:LinkButton ID="lbtnAirlineName" runat="server" Text="预订" CommandName="Select"  />
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="8%" Height="25px"/>
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" BorderStyle="Double" Wrap="False" Width="8%" />
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
                        <asp:BoundField DataField="ALL_FARES" HeaderText="票价(全)">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DISCOUNT_FARES" HeaderText="折扣价">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        </asp:BoundField>
                         <asp:BoundField DataField="REMARK" HeaderText="备注">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" />
                        </asp:BoundField>
                        </Columns>
                        <FixRowColumn FixColumns="0" FixRows="-1" TableHeight="98px" TableWidth="580px" />
                        <EmptyDataTemplate>
                        <tr class="GridViewHeaderStyle">
                        <th nowarp><asp:Label ID="Label9" runat="server" Text="预订"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label1" runat="server" Text="出发时间"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label2" runat="server" Text="机场"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label3" runat="server" Text="出发城市"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label10" runat="server" Text="抵达城市"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label4" runat="server" Text="航空公司"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label5" runat="server" Text="机型"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label6" runat="server" Text="票价"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label7" runat="server" Text="折扣价"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label8" runat="server" Text="备注"></asp:Label></th>
                        </tr>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" BackColor="White" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        </yyc:SmartGridView>
            </asp:Panel></td>
    </tr>
    </table>
</asp:Content>
