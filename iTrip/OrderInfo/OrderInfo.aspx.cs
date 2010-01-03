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
    public partial class OrderInfo : BasePage
    {
        private string TableHeight = BasePage.DEFAULT_TABLE_HEIGHT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //机票预定信息
                FlightGridView.DataSource = null;
                FlightGridView.DataBind();

                //宾馆预定信息
                HotelGridView.DataSource = null;
                HotelGridView.DataBind();

                //保存当前值
                TableHeight = FlightGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT] = TableHeight;

                //保存当前值
                TableHeight = FlightGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] = TableHeight;

                TableHeight = HotelGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] = TableHeight;

                //默认显示机票预定信息
                BindDataToGridView(0);
            }
            else
            {
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"] != null)
                    FlightGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_0"]);

                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] != null)
                    HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"]);
            }
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 10, 15);
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 10, 15);
        }

        //菜单
        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            //机票预定信息
            if (e.Item.Value.Equals("0"))
            {
                MultiView1.ActiveViewIndex = 0;
                BindDataToGridView(0);
            }
            //宾馆预定信息
            else if (e.Item.Value.Equals("1"))
            {
                MultiView1.ActiveViewIndex = 1;
                BindDataToGridView(1);
            }
        }

        //机票预定信息
        protected void BindOrderFlightGridView()
        {
            BindDataToGridView(null);
        }

        //宾馆预定信息
        protected void BindOrderHotelGridView()
        {
            DataSet ds = null;
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            finally
            {

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
                        //DataSet ds = iWebServiceFlight.GetOrderFlightList(SESSION_USER.USER_NAME);
                        //dt_1 =
                        //    ds != null ? ds.Tables[0] : null;
                        break;
                    default:
                        ds = iWebServiceFlight.GetOrderFlightList(SESSION_USER.USER_NAME);
                        dt_0 =
                            ds != null ? ds.Tables[0] : null;

                        //ds = iWebServiceFlight.GetOrderFlightList(SESSION_USER.USER_NAME);
                        //dt_1 =
                        //    ds != null ? ds.Tables[0] : null;
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

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 10, 15);
                        break;
                    case 1:
                        this.HotelGridView.DataSource = dt_1;
                        this.HotelGridView.DataBind();

                        if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"] != null)
                            HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT + "_1"]);

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 10, 15);
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

                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(FlightGridView, 10, 15);
                        iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 10, 15);
                        break;
                }
            }
        }

        protected void FlightGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataKey keys = FlightGridView.DataKeys[index];
            int FLIGHT_ORDER_ID = int.Parse(keys["FLIGHT_ORDER_ID"].ToString());

            iTrip.iWebServiceReferenceFlight.FLIGHT_ORDER  FLIGHT_ORDER = iWebServiceFlight.GetFlightOrder(FLIGHT_ORDER_ID);
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
    }
}
