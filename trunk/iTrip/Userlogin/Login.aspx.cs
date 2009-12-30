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

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click1);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            iWebServiceReference.iWebServiceSoapClient aa = new iWebServiceReference.iWebServiceSoapClient();
            bool result=aa.ValidateUser(UserName.Text, Password.Text);
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
