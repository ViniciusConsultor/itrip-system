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
using System.Text;

namespace iTrip.Hotel
{
    public partial class Hotel : BasePage
    {
        private string TableHeight = BasePage.DEFAULT_TABLE_HEIGHT;
        public static string USER_VIEW_STATE_ALL_HOTEL_OBJECT = "USER_VIEW_STATE_ALL_HOTEL_OBJECT";
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查用户是否登录
            CheckLoginUser();

            if (!IsPostBack)
            {
                this.HotelGridView.DataSource = null;
                this.HotelGridView.DataBind();

                //保存当前值
                TableHeight = HotelGridView.FixRowColumn.TableHeight;
                ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT] = TableHeight;
            }
            else
            {
                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]!=null)
                    HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]);
            }
            iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView,10,15);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = null;
            try
            {
                if (!IsValid())
                    return;

                StringBuilder whereBuilder = new StringBuilder();
                if (Utils.IsNotEmpty(this.txtFareFrom.Text) && Utils.isDecimal(this.txtFareFrom.Text))
                {
                    whereBuilder.Append(" AND HD.FARE*(1-HD.DISCOUNT) >= '" + decimal.Parse(txtFareFrom.Text) + "' ");
                }
                if (Utils.IsNotEmpty(this.txtFareTo.Text) && Utils.isDecimal(this.txtFareTo.Text))
                {
                    whereBuilder.Append(" AND HD.FARE*(1-HD.DISCOUNT) <= '" + decimal.Parse(txtFareTo.Text) + "' ");
                }
                if (Utils.IsNotEmpty(this.txtHotel.Text))
                {
                    whereBuilder.Append(" AND H.HOTEL_NAME LIKE '%" + txtHotel.Text + "%' ");
                }
                DataSet ds = iWebServiceHotel.GetHotelList(SESSION_USER.USER_NAME, whereBuilder.ToString());
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    hidCheckIn.Value = txtCheckIn.Text;
                    hidCheckOut.Value = txtCheckOut.Text;

                    //添加一列到数据表中
                    DataColumn columnIn = new DataColumn("CHECK_IN");
                    columnIn.DefaultValue = txtCheckIn.Text;
                    dt.Columns.Add(columnIn);
                    DataColumn columnOut = new DataColumn("CHECK_OUT");
                    columnOut.DefaultValue = txtCheckIn.Text;
                    dt.Columns.Add(columnOut);

                    DataColumn column = new DataColumn("PRE_QUANTITY");
                    column.DefaultValue = ddlRoomCount.SelectedItem.Value;
                    dt.Columns.Add(column);

                    //保存当前数据
                    ViewState[USER_VIEW_STATE_ALL_HOTEL_OBJECT] = dt;
                    //克隆当前数据结构到Session中
                    if (Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT] == null)
                        Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT] = dt.Clone();
                }
                else
                {
                    hidCheckIn.Value = string.Empty;
                    hidCheckOut.Value = string.Empty;
                }
            }
            catch (Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
            }
            finally
            {
                this.HotelGridView.DataSource = dt;
                this.HotelGridView.DataBind();

                if (ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT] != null)
                    HotelGridView.FixRowColumn.TableHeight = Convert.ToString(ViewState[VIEW_STATE_TABLE_HEIGHT_OBJECT]);
                iTrip.Helper.BindHelper.BindDataGridViewFixHeightD(HotelGridView, 10, 15);
            }
        }

        protected void HotelGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey keys = HotelGridView.DataKeys[HotelGridView.SelectedIndex];
            int room_id = int.Parse(keys["ROOM_ID"].ToString());
            if (Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT] != null)
            {
                //获取当前Session中数据源结构
                DataTable SessionHotelTable = (DataTable)Session[PubConstant.USER_SESSION_HOTEL_ORDER_OBJECT];
                DataTable ViewStateHotelTable = (DataTable)ViewState[USER_VIEW_STATE_ALL_HOTEL_OBJECT];
                if (ViewStateHotelTable != null)
                {
                    DataRow[] rows = ViewStateHotelTable.Select(" ROOM_ID =" + room_id);
                    if (rows.Length > 0)
                    {
                        //将当前选中的数据添加到Session数据表中
                        SessionHotelTable.ImportRow(rows[0]);
                        Response.Write(@"<script>if(window.confirm('已成功将该宾馆添加到宾馆购物车中，是否现在查看？'))
                                       {
                                            location.href='../OrderInfo/OrderInfo.aspx?view=2';
                                       };</script>");
                    }
                }
            }

            ImageButton1_Click(null, null);

        }

        protected void HotelGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            HotelGridView.PageIndex = e.NewPageIndex;
            ImageButton1_Click(null, null);
        }

        private bool IsValid()
        {
            bool infoValid = true;
            string strErr = "";
            string checkIn = txtCheckIn.Text;
            string checkOut = txtCheckOut.Text;
            if (!Utils.IsNotEmpty(checkIn) || !Utils.isDate(checkIn))
            {
                strErr += "请选择入住日期！<br>";
            }

            if (!Utils.IsNotEmpty(checkOut) || !Utils.isDate(checkOut))
            {
                strErr += "请选择离店日期！<br>";
            }

            if (strErr != "")
            {
                //校验失败
                infoValid = false;
                pnl.Visible = true;
                lblInfoMessage.Text = strErr;
            }
            else
            {
                pnl.Visible = false;
            }
            return infoValid;
        }
    }
}
