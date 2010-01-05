using System;
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

namespace iTrip.OrderInfo
{
    enum VIEW_TYPE
    {
        FLIGHT_TS_GRID_VIEW,
        FLIGHT_GRID_VIEW,
        HOTEL_TS_GRID_VIEW,
        HOTEL_GRID_VIEW
    }

    public partial class OrderInfo : BasePage
    {
        private string TableHeight = BasePage.DEFAULT_TABLE_HEIGHT;
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查用户是否登录
            CheckLoginUser();

            if (!IsPostBack)
            {
                //保存当前值
                TableHeight = FlightGridTSView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"] = TableHeight;
                TableHeight = FlightGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] = TableHeight;

                TableHeight = HotelGridTSView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"] = TableHeight;
                TableHeight = HotelGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] = TableHeight;

                //默认显示机票预定信息
                string view = Convert.ToString(Request.QueryString["view"]);
                if (Utils.IsNotEmpty(view) && Utils.isInt(view) && int.Parse(view) >= 0 && MultiView1.Views.Count > int.Parse(view))
                {
                    MultiView1.ActiveViewIndex = int.Parse(view);
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                }
            }
            else
            {
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"] != null)
                    FlightGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"]);
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] != null)
                    FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"]);

                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"] != null)
                    HotelGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"]);
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] != null)
                    HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"]);
            }

            //高度设置
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridTSView, 25, 15);
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 25, 15);
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridTSView, 25, 15);
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 25, 15);
        }

        //菜单
        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            //机票预定购物车(暂存)
            if (e.Item.Value.Equals("0"))
            {
                MultiView1.ActiveViewIndex = 0;
                BindSessionDataToGridView(0);
            }
            //宾馆预定购物车(暂存)
            else if (e.Item.Value.Equals("2"))
            {
                MultiView1.ActiveViewIndex = 2;
                BindSessionDataToGridView(1);
            }
            //机票预定信息(已存)
            else if (e.Item.Value.Equals("1"))
            {
                MultiView1.ActiveViewIndex = 1;
                BindDataToGridView(0);
            }
            //宾馆预定信息(已存)
            else if (e.Item.Value.Equals("3"))
            {
                MultiView1.ActiveViewIndex = 3;
                BindDataToGridView(1);
            }

            foreach (MenuItem item in Menu2.Items)
            {
                if (item.Value.Equals(e.Item.Value))
                {
                   e.Item.ImageUrl = "~/Resource/class_ar.gif";
                }
                else
                {
                    item.ImageUrl = "";
                }
            }
        }

        private void BindDataToGridView(int? flag)
        {
            DataTable dt_0 = null;
            DataTable dt_1 = null;
            try
            {
                DataSet ds = null;
                switch (flag)
                { 
                    case 0:
                        ds = iWebServiceFlight.GetOrderFlightList(SESSION_USER.USER_NAME);
                        dt_0 =
                            ds != null ? ds.Tables[0] : null;
                        break;
                    case 1:
                        ds = iWebServiceHotel.GetOrderHotelList(SESSION_USER.USER_NAME);
                        dt_1 =
                            ds != null ? ds.Tables[0] : null;
                        break;
                    default:
                        ds = iWebServiceFlight.GetOrderFlightList(SESSION_USER.USER_NAME);
                        dt_0 =
                            ds != null ? ds.Tables[0] : null;

                        ds = iWebServiceHotel.GetOrderHotelList(SESSION_USER.USER_NAME);
                        dt_1 =
                            ds != null ? ds.Tables[0] : null;
                        break;
                }
            }
            catch (Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
            }
            finally
            {
                switch (flag)
                {
                    case 0:
                        this.FlightGridView.DataSource = dt_0;
                        this.FlightGridView.DataBind();

                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] != null)
                            FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"]);

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 25, 15);
                        break;
                    case 1:
                        this.HotelGridView.DataSource = dt_1;
                        this.HotelGridView.DataBind();

                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] != null)
                            HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"]);

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 25, 15);
                        break;
                    default:
                        this.FlightGridView.DataSource = dt_0;
                        this.FlightGridView.DataBind();

                        this.HotelGridView.DataSource = dt_1;
                        this.HotelGridView.DataBind();

                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] != null)
                            FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"]);
                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] != null)
                            HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"]);

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 25, 15);
                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 25, 15);
                        break;
                }
            }
        }

        //Session中暂存信息
        private void BindSessionDataToGridView(int? flag)
        {
            DataTable SessionFlightDataTable = null;
            DataTable SessionHotelDataTable = null;
            try
            {
                switch (flag)
                {
                    case 0:
                        SessionFlightDataTable = (DataTable)Session[PubConstant.USER_SESSION_FLIGHT_ORDER_OBJECT];
                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"] != null)
                            FlightGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"]);
                        break;
                    case 1:
                        SessionHotelDataTable = (DataTable)Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT];
                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"] != null)
                            HotelGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"]);
                        break;
                    default:
                        SessionFlightDataTable = (DataTable)Session[PubConstant.USER_SESSION_FLIGHT_ORDER_OBJECT];
                        SessionHotelDataTable =  (DataTable)Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT];

                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"] != null)
                            FlightGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_0"]);
                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"] != null)
                            HotelGridTSView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_TS_1"]);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
            }
            finally
            {
                this.FlightGridTSView.DataSource = SessionFlightDataTable;
                this.FlightGridTSView.DataBind();

                this.HotelGridTSView.DataSource = SessionHotelDataTable;
                this.HotelGridTSView.DataBind();

                iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridTSView, 25, 15);
                iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridTSView, 25, 15);
            }
        }

        protected void FlightGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataKey keys = FlightGridView.DataKeys[index];
            int FLIGHT_ORDER_ID = int.Parse(keys["FLIGHT_ORDER_ID"].ToString());

            iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER FLIGHT_ORDER = iWebServiceFlight.GetFlightOrder(FLIGHT_ORDER_ID);
            if (FLIGHT_ORDER != null)
            { 
               if ("PAYMENT_ORDER".Equals(e.CommandName))
               {
                   FLIGHT_ORDER.CONFIRM_FLAG = 1;
                   iWebServiceFlight.UpdateFlightOrder(FLIGHT_ORDER);
               }
               else if ("DELETE_ORDER".Equals(e.CommandName))
               {
                   iWebServiceFlight.DeleteFlightOrder(FLIGHT_ORDER.FLIGHT_ORDER_ID);
               }
            }
            //重新加载
            this.BindDataToGridView(0);
        }

        //
        //控制页面链接可见性
        //
        protected void FlightGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool canEdit = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey keys = FlightGridView.DataKeys[e.Row.RowIndex];
                int confirm_flag = int.Parse(keys["CONFIRM_FLAG"].ToString());

                LinkButton payLinkBtn = (LinkButton)e.Row.FindControl("lbtPaymentStatus");
                Label payStatusLabel = (Label)e.Row.FindControl("lblPaymentStatus");
                LinkButton delteLinkBtn = (LinkButton)e.Row.FindControl("btnDelete");

                canEdit =
                    confirm_flag == 0 ? true : false;
                //是否可以编辑
                if (canEdit)
                {
                    payLinkBtn.Visible = true;
                    payStatusLabel.Visible = false;
                    delteLinkBtn.Enabled = true;
                }
                else
                {
                    payLinkBtn.Visible = false;
                    payStatusLabel.Visible = true;
                    delteLinkBtn.Visible = false;
                }
            }
        }

        protected void HotelGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool canEdit = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey keys = HotelGridView.DataKeys[e.Row.RowIndex];
                int confirm_flag = int.Parse(keys["CONFIRM_FLAG"].ToString());

                LinkButton payLinkBtn = (LinkButton)e.Row.FindControl("lbtPaymentStatus");
                Label payStatusLabel = (Label)e.Row.FindControl("lblPaymentStatus");
                LinkButton delteLinkBtn = (LinkButton)e.Row.FindControl("btnDelete");

                canEdit =
                    confirm_flag == 0 ? true : false;
                //是否可以编辑
                if (canEdit)
                {
                    payLinkBtn.Visible = true;
                    payStatusLabel.Visible = false;
                    delteLinkBtn.Enabled = true;
                }
                else
                {
                    payLinkBtn.Visible = false;
                    payStatusLabel.Visible = true;
                    delteLinkBtn.Visible = false;
                }
            }
        }

        protected void HotelGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataKey keys = HotelGridView.DataKeys[index];
            int HOTEL_ORDER_ID = int.Parse(keys["HOTEL_ORDER_ID"].ToString());

            iTrip.iWebServiceReferenceHotel.HOTEL_ORDER HOTEL_ORDER = iWebServiceHotel.GetHotelOrder(HOTEL_ORDER_ID);
            if (HOTEL_ORDER != null)
            {
                if ("PAYMENT_ORDER".Equals(e.CommandName))
                {
                    HOTEL_ORDER.CONFIRM_FLAG = 1;
                    iWebServiceHotel.UpdateHotelOrder(HOTEL_ORDER);
                }
                else if ("DELETE_ORDER".Equals(e.CommandName))
                {
                    iWebServiceHotel.DeleteHotelOrder(HOTEL_ORDER.HOTEL_ORDER_ID);
                }
            }
            //重新加载
            this.BindDataToGridView(1);
        }

        //机票预定（暂存）
        protected void FlightGridTSView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataKey keys = FlightGridTSView.DataKeys[index];
            int flight_id = int.Parse(keys["FLIGHT_ID"].ToString());
            decimal fare = decimal.Parse(keys["DISCOUNT_FARES"].ToString());
            int person_count = int.Parse(keys["PERSON_COUNT"].ToString());
            decimal totalFare = fare * (decimal)person_count;
            if ("CONFIRM_TS".Equals(e.CommandName))
            {
                iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER FLIGHT_ORDER = new iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER();
                FLIGHT_ORDER.FLIGHT_ID = flight_id;
                FLIGHT_ORDER.USER_NAME = SESSION_USER.USER_NAME;
                FLIGHT_ORDER.FARE = totalFare;
                FLIGHT_ORDER.PERSON_COUNT = person_count;
                FLIGHT_ORDER.CONFIRM_FLAG = 0;
                //添加订单表中
                iWebServiceFlight.AddFlightOrder(FLIGHT_ORDER);

                //从Session中讲该记录移除
                DataTable TS_DataTable = (DataTable)Session[PubConstant.USER_SESSION_FLIGHT_ORDER_OBJECT];
                if (TS_DataTable != null)
                {
                    DataRow[] rows = TS_DataTable.Select(" FLIGHT_ID =" + flight_id);
                    if (rows.Length > 0)
                        TS_DataTable.Rows.Remove(rows[0]);
                }
            }
            else if ("DELETE_TS".Equals(e.CommandName))
            {
                //从Session中讲该记录移除
                DataTable TS_DataTable = (DataTable)Session[PubConstant.USER_SESSION_FLIGHT_ORDER_OBJECT];
                if (TS_DataTable != null)
                {
                    DataRow[] rows = TS_DataTable.Select(" FLIGHT_ID =" + flight_id);
                    if (rows.Length > 0)
                        TS_DataTable.Rows.Remove(rows[0]);
                }
            }

            //重新加载
            this.BindSessionDataToGridView(0);
        }

        //酒店预定（暂存）
        protected void HotelGridTSView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataKey keys = HotelGridTSView.DataKeys[index];
            int room_id = int.Parse(keys["ROOM_ID"].ToString());
            decimal fare = decimal.Parse(keys["DISCOUNT_FARES"].ToString());
            DateTime check_in = Convert.ToDateTime(keys["CHECK_IN"].ToString());
            DateTime check_out = Convert.ToDateTime(keys["CHECK_OUT"].ToString());
            int pre_quantity = int.Parse(keys["PRE_QUANTITY"].ToString());
            decimal totalFare = fare * (decimal)pre_quantity;
            if ("CONFIRM_TS".Equals(e.CommandName))
            {
                iTrip.iWebServiceReferenceHotel.HOTEL_ORDER HOTEL_ORDER = new iTrip.iWebServiceReferenceHotel.HOTEL_ORDER();
                HOTEL_ORDER.ROOM_ID = room_id;
                HOTEL_ORDER.USER_NAME = SESSION_USER.USER_NAME;
                HOTEL_ORDER.FARE = totalFare;
                HOTEL_ORDER.CHECK_IN = check_in;
                HOTEL_ORDER.CHECK_OUT = check_out;
                HOTEL_ORDER.PRE_QUANTITY = pre_quantity;
                HOTEL_ORDER.CONFIRM_FLAG = 0;
                
                //添加
                iWebServiceHotel.AddHotelOrder(HOTEL_ORDER);

                //从Session中讲该记录移除
                DataTable TS_DataTable = (DataTable)Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT];
                if (TS_DataTable != null)
                {
                    DataRow[] rows = TS_DataTable.Select(" ROOM_ID =" + room_id);
                    if (rows.Length > 0)
                        TS_DataTable.Rows.Remove(rows[0]);
                }
            }
            else if ("DELETE_TS".Equals(e.CommandName))
            {
                //从Session中讲该记录移除
                DataTable TS_DataTable = (DataTable)Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT];
                if (TS_DataTable != null)
                {
                    DataRow[] rows = TS_DataTable.Select(" ROOM_ID =" + room_id);
                    if (rows.Length > 0)
                        TS_DataTable.Rows.Remove(rows[0]);
                }
            }

            //重新加载
            this.BindSessionDataToGridView(1);
        }

        //机票预定（暂存）
        protected void View3_OnActivate(object sender, EventArgs e)
        {
            this.BindSessionDataToGridView(0);
        }
        //机票预定（已存）
        protected void View1_Activate(object sender, EventArgs e)
        {
            this.BindDataToGridView(0);
        }

        //酒店预定（暂存）
        protected void View4_Activate(object sender, EventArgs e)
        {
            this.BindSessionDataToGridView(1);
        }
        //酒店预定（已存）
        protected void View2_Activate(object sender, EventArgs e)
        {
            this.BindDataToGridView(1);
        }
    }
}
