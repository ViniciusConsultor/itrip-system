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

namespace iTrip.User
{
    public partial class UserManage : BasePage
    {
        private iTrip.iWebServiceReference.USERS User = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查用户是否登录
            CheckLoginUser();
            if (!IsPostBack)
            {
                initPage();
            }
        }

        //菜单
        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            //机票预定信息
            if (e.Item.Value.Equals("0"))
            {
                MultiView1.ActiveViewIndex = 0;
            }
            //宾馆预定信息
            else if (e.Item.Value.Equals("1"))
            {
                MultiView1.ActiveViewIndex = 1;
            }

            foreach (MenuItem item in Menu2.Items)
            {
                if (item.Value.Equals(e.Item.Value))
                {
                    e.Item.ImageUrl = "~/Resource/user_123.jpg";
                }
                else
                {
                    item.ImageUrl = "";
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidation())
                    return;

                if (User != null)
                {
                    User.PASSWORD = txtNewPassword.Text.Trim();
                    iWebService.UpdateUser(User);

                    this.lblInfoMessage.Text = "<li>密码更新成功!</li>";
                    this.pnl.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
                this.pnl.Visible = true;
            }
        }

        #region <<辅助函数>>
        private void initPage()
        {
            try
            {
                this.txtUserName.Text = Convert.ToString(SESSION_USER.USER_NAME);
            }
            catch (System.Exception ex)
            {
                this.lblInfoMessage.Text = ex.Message;
                this.pnl.Visible = true;
            }
        }

        private bool IsValidation()
        {
            bool infoValid = true;

            string strErr = "";
            string userName = Convert.ToString(this.txtUserName.Text.Trim());
            string oldPassword = Convert.ToString(this.txtOriginPassword.Text.Trim());
            string password = Convert.ToString(this.txtNewPassword.Text.Trim());
            string repassword = Convert.ToString(this.txtReconfirmPassword.Text.Trim());
            /*****************旧密码和新密码和确认密码*********************/
            if (!Utils.IsNotEmpty(oldPassword))
            {
                //旧密码不能为空！
                strErr += "请输入原始密码！" + "<br>";
            }

            if (!Utils.IsNotEmpty(password))
            {
                //新密码不能为空！
                strErr += "新密码不能为空！" + "<br>";
            }
            if (!Utils.IsNotEmpty(repassword))
            {
                //确认新密码不能为空！
                strErr += "确认新密码不能为空！" + "<br>";
            }

            if (Utils.IsNotEmpty(password) && Utils.IsNotEmpty(repassword) && !password.Equals(repassword))
            {
                //新密码和确认新密码不匹配！
                strErr += "新密码和确认新密码不匹配！" + "<br>";
            }

            if (!Utils.IsNotEmpty(strErr))
            {
                //开始校验原始密码是否正确
                User = iWebService.ValidateUser(userName, oldPassword);
                if (User == null)
                {
                    //原始密码错误！,
                    strErr += "原始密码错误，请重新输入！<br>";
                }
            }

            if (Utils.IsNotEmpty(strErr))
            {
                strErr += "";

                //校验失败
                infoValid = false;
                this.lblInfoMessage.Text = strErr;
                this.pnl.Visible = true;
            }
            return infoValid;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/SelectSite.aspx");
        }
        #endregion
    }
}
