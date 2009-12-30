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

namespace iTrip.UserLogin
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
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
            iWebServiceReference.iWebServiceSoapClient aa = new iWebServiceReference.iWebServiceSoapClient();
            bool result=aa.ValidateUser(UserName.Text, Password.Text);
            if (result)
            {
                Response.Write("<script>alert('��¼�ɹ���');</script>");
            }
            else
            {
                Response.Write("<script>alert('��¼ʧ�ܣ�');</script>");
                
            }
        }
	}
}
