﻿<%@ Page Language="C#" MasterPageFile="~/Basepage/iTrip_Main.Master" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="iTrip.Hotel.Hotel" %>
<%@ Register assembly="YYControls" namespace="YYControls" tagprefix="yyc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>酒店信息查询</title>
<script type="text/javascript">
function on_KeyPress_Decimal() {
	var value=event.srcElement.value;
	var kc=event.keyCode;
	if(kc<32 || (kc>47 && kc<58) || (kc==45 && value.indexOf("\-")==-1)|| (kc==46 && value.indexOf("\.")==-1)) {
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
	var re=/(\..{2}).+$/;

	if(value.indexOf("\-")>0) {
		obj.value=value.replace("\-","");
	} else if(re.test(value)) {
		obj.value=value.replace(re,"$1");
	}	
}
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="../Resource/jd_033.jpg" height="100%" alt="咨询信息" width="220px" />
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
	                <asp:panel id="SearchCondition" Runat="server" GroupingText="宾馆查询">
	                <table height="20" width="100%">
	                <tr>
	                <td class="td" nowarp>入住日期</td>
	                <td class="td_left"><asp:TextBox ID="txtCheckIn" runat="server"  CssClass="TextWidth Wdate" onfocus="WdatePicker({lang:'auto',dateFmt:'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'ctl00$ContentPlaceHolder2$txtCheckIn\')}',onpicked:function(){ctl00$ContentPlaceHolder2$txtCheckOut.focus();}})" ></asp:TextBox></td>
	                <td class="td" nowarp>离店日期</td>
	                <td class="td_left"><asp:TextBox ID="txtCheckOut" runat="server"  CssClass="TextWidth Wdate" onfocus="WdatePicker({lang:'auto',dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'ctl00$ContentPlaceHolder2$txtCheckOut\');}'})"></asp:TextBox></td>
	                </tr>
	                <tr>
	                <td class="td" nowarp>宾馆名称</td>
	                <td class="td_left"><asp:TextBox ID="txtHotel" runat="server"  CssClass="TextWidth"></asp:TextBox></td>
	                <td class="td" nowarp>预订数量</td>
	                <td class="td_left">
                        <asp:DropDownList ID="ddlRoomCount" runat="server" CssClass="TextWidth">
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
	                  <tr>
	                <td class="td" nowarp>价格范围 从</td>
	                <td class="td_left" colspan="3" valign="bottom"><asp:TextBox ID="txtFareFrom" runat="server"  CssClass="TextWidth" onKeyUp="on_KeyUp_Decimal(0)" onKeyPress="return on_KeyPress_Decimal()"></asp:TextBox>
	                &nbsp;至 <asp:TextBox ID="txtFareTo" runat="server"  CssClass="TextWidth" onKeyUp="on_KeyUp_Decimal(0)" onKeyPress="return on_KeyPress_Decimal()"></asp:TextBox></td>
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
            <asp:Panel ID="Panel1" runat="server" GroupingText="宾馆信息"
                HorizontalAlign="Left">
            <yyc:SmartGridView ID="HotelGridView" runat="server" Width="100%" 
                    AllowSorting="True" DataKeyNames="ROOM_ID,DISCOUNT_FARES" 
                    AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="HotelGridView_PageIndexChanging" 
                    onselectedindexchanged="HotelGridView_SelectedIndexChanged">
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
                        
                        <asp:BoundField DataField="HOTEL_NAME" HeaderText="宾馆名称">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ROOM_TYPE" HeaderText="房型">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FARE" HeaderText="门市价(RMB)">
                        <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="DISCOUNT_FARES" HeaderText="折扣价(RMB)">
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
                        <FixRowColumn FixColumns="0" FixRows="-1" TableHeight="98px" TableWidth="580px" />
                        <EmptyDataTemplate>
                        <tr class="GridViewHeaderStyle">
                        <th nowarp><asp:Label ID="Label9" runat="server" Text="预订"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label3" runat="server" Text="宾馆名称"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label10" runat="server" Text="房型"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label4" runat="server" Text="门市价(RMB)"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label5" runat="server" Text="折扣价(RMB)"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label6" runat="server" Text="早餐"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label7" runat="server" Text="床型"></asp:Label></th>
                        <th nowarp><asp:Label ID="Label8" runat="server" Text="宽带"></asp:Label></th>
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
    <asp:HiddenField ID="hidCheckIn" runat="server" />
    <asp:HiddenField ID="hidCheckOut" runat="server" />
</asp:Content>
