using System;
using System.Web.Security;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iTrip;

namespace iTrip.UserLogin
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : BasePage
	{
		protected System.Web.UI.WebControls.TextBox UserName;
		protected System.Web.UI.WebControls.TextBox Password;
		protected System.Web.UI.WebControls.Button btnSubmit;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            bool result = iWebService.ValidateUser(UserName.Text, Password.Text);
            if (result)
            {
                Response.Write("<script>alert('µÇÂ¼³É¹¦£¡');</script>");
            }
            else
            {
                Response.Write("<script>alert('µÇÂ¼Ê§°Ü£¡');</script>");
                
            }
        }
	}
}
