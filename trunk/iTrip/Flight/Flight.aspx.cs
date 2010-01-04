﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTrip.Utility;
using System.Text;

namespace iTrip.Flight
{
    public partial class Flight : BasePage
    {
        private string TableHeight = BasePage.DEFAULT_TABLE_HEIGHT;
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查用户是否登录
            CheckLoginUser();

            if (!IsPostBack)
            {
                this.FlightGridView.DataSource = null;
                this.FlightGridView.DataBind();

                //保存当前值
                TableHeight = FlightGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT] = TableHeight;

                BindDropDownList();
            }
            else
            {
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]!=null)
                    FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]);
            }
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView,10,15);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = null;
            try
            {
                StringBuilder whereBuilder = new StringBuilder();
                if (Utils.IsNotEmpty(this.txtDeliveryCity.Text))
                {
                    whereBuilder.Append(" AND FLIGHT_DATA.DELIVERY_TICKET_CITY LIKE '%" + Utils.ReplaceBadSQL(txtDeliveryCity.Text) + "%' ");
                }
                if (Utils.IsNotEmpty(this.txtDepartDate.Text) && Utils.isDate(this.txtDepartDate.Text))
                {
                    whereBuilder.Append(" AND FORMAT(FLIGHT_DATA.DEPART_DATE,'yyyy-MM-dd') = '" + Utils.ReplaceBadSQL(txtDepartDate.Text) + "' ");
                }
                if (Utils.IsNotEmpty(ddlAirLine.SelectedItem.Value))
                {
                    whereBuilder.Append(" AND AIRLINE.AIRLINE_NAME='" + Utils.ReplaceBadSQL(ddlAirLine.SelectedItem.Value) + "' ");
                }
                if (Utils.IsNotEmpty(this.ddlFromCity.SelectedItem.Value))
                {
                    whereBuilder.Append(" AND FLIGHT_DATA.FROM='" + Utils.ReplaceBadSQL(ddlFromCity.SelectedItem.Value) + "' ");
                }
                if (Utils.IsNotEmpty(this.ddlToCity.SelectedItem.Value))
                {
                    whereBuilder.Append(" AND FLIGHT_DATA.TO='" + Utils.ReplaceBadSQL(ddlToCity.SelectedItem.Value) + "' ");
                }

                DataSet ds = iWebServiceFlight.GetFlightList(SESSION_USER.USER_NAME, whereBuilder.ToString());
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
            }
            finally
            {
                this.FlightGridView.DataSource = dt;
                this.FlightGridView.DataBind();

                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT] != null)
                    FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]);
                iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 10, 15);
            }
        }

        protected void FlightGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey keys = FlightGridView.DataKeys[FlightGridView.SelectedIndex];
            int flight_id = int.Parse(keys["FLIGHT_ID"].ToString());
            decimal fare = decimal.Parse(keys["DISCOUNT_FARES"].ToString());
            iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER FLIGHT_ORDER = new iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER();
            FLIGHT_ORDER.FLIGHT_ID = flight_id;
            FLIGHT_ORDER.USER_NAME = SESSION_USER.USER_NAME;
            FLIGHT_ORDER.FARE = fare;
            FLIGHT_ORDER.CONFIRM_FLAG = 0;

            //添加
            iWebServiceFlight.AddFlightOrder(FLIGHT_ORDER);

            ImageButton1_Click(null, null);

        }

        protected void FlightGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FlightGridView.PageIndex = e.NewPageIndex;
            ImageButton1_Click(null, null);
        }

        private void BindDropDownList()
        {
            DataSet ds = null;
            try
            {
                //航空公司
                ds = iWebServiceFlight.GetFlightCorporationList();
                iTrip.Helper.BindHelper.BindDropDownList(ddlAirLine, ds.Tables[0], "AIRLINE_NAME", "AIRLINE_NAME",true);

                //出发城市
                ds = iWebServiceFlight.GetFlightFromList(0);
                iTrip.Helper.BindHelper.BindDropDownList(ddlFromCity, ds.Tables[0], "FLIGHT_FROM", "FLIGHT_FROM", true);

                //到达城市
                ds = iWebServiceFlight.GetFlightFromList(1);
                iTrip.Helper.BindHelper.BindDropDownList(ddlToCity, ds.Tables[0], "FLIGHT_TO", "FLIGHT_TO", true);

                //消息框
                lblInfoMessage.Text = string.Empty;
                pnl.Visible = false;
            }
            catch(Exception ex)
            {
                lblInfoMessage.Text = ex.Message;
                pnl.Visible = true;
            }
        }
    }
}
