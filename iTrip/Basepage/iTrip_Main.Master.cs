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

namespace iTrip.Basepage
{
    public partial class iTrip_Main : BaseMasterPage
    {
        iTrip.iWebServiceReference.USERS User;
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu1.Visible =
                Session[PubConstant.APP_SESSION_USER_OBJECT] != null ? true : false;

            if (!IsPostBack)
            {
                if (Session[PubConstant.APP_SESSION_USER_OBJECT] != null)
                {
                    User = (iTrip.iWebServiceReference.USERS)Session[PubConstant.APP_SESSION_USER_OBJECT];
                    UserLoginPanel.Visible = false;
                    UserLoginPanel.Enabled = false;
                    UserInfoPanel.Visible = true;
                    UserInfoPanel.Enabled = true;

                    lblUserName.Text = User.USER_NAME;
                    lblLastLoginDate.Text =
                        User.LAST_LOG_DATE.HasValue ? User.LAST_LOG_DATE.Value.ToString("yyyy-MM-dd HH:mm") : string.Empty;
                    lblLoginTimes.Text =
                        User.LOG_TIMES.HasValue ? User.LOG_TIMES.Value.ToString() : "1";
                }
                else
                {
                    UserLoginPanel.Visible = true;
                    UserLoginPanel.Enabled = true;
                    UserInfoPanel.Visible = false;
                    UserInfoPanel.Enabled = false;
                } 
            }

            if (Session[PubConstant.CURRENT_NAVIGATE_MENU_ITEM] != null && Menu1.Visible)
            {
                MenuItem sItem = (MenuItem)Session[PubConstant.CURRENT_NAVIGATE_MENU_ITEM];
                foreach (MenuItem item in Menu1.Items)
                {
                    if (item.Value.Equals(sItem.Value))
                    {
                        item.ImageUrl = "~/Resource/current_arrow.gif";
                    }
                    else
                    {
                        item.ImageUrl = "";
                    }
                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Session[PubConstant.CURRENT_NAVIGATE_MENU_ITEM] = e.Item;
            //航班预订
            if (e.Item.Value.Equals("00000"))
            {
                Response.Redirect("~/Flight/Flight.aspx", false);
            }
            //酒店信息
            if (e.Item.Value.Equals("00001"))
            {
                Response.Redirect("~/Flight/Flight.aspx", false);
            }
            //订单信息
            if (e.Item.Value.Equals("00002"))
            {
                Response.Redirect("~/OrderInfo/OrderInfo.aspx", false);
            }
            //注销操作
            if (e.Item.Value.Equals("00005"))
            {
                HttpContext.Current.Session.Abandon();
                Response.Redirect("~/Main/Index.aspx",false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            iTrip.iWebServiceReference.USERS User = iWebService.ValidateUser(txtUserName.Text, txtPassword.Text);
            if (User != null)
            {
                Session[PubConstant.APP_SESSION_USER_OBJECT] = User;
                Response.Redirect("~/Main/Index.aspx", false);
            }
            else
            {
                Response.Write("<script>window.alert('用户名或密码错误！');</script>");
            }
        }
    }
}
