using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTrip.Utility;

namespace iTrip
{
    /// <summary>
    /// iTrip 系统页面基类.
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        #region <<共用属性定义>>
        protected static string DEFAULT_TABLE_HEIGHT="18px";
        protected static string VIEW_STATE_TABLE_HEIGHT_OBJECT = "VIEW_STATE_TABLE_HEIGHT_OBJECT";
       
        //调用WebService对象
		private static iWebServiceReference.iWebServiceSoapClient _WebService;
        protected static iWebServiceReference.iWebServiceSoapClient iWebService
        {
            get { return BasePage._WebService; }
            set { BasePage._WebService = value; }
        }

        private static iWebServiceReferenceFlight.iWebServiceFlightSoapClient _WebServiceFlight;
        protected static iWebServiceReferenceFlight.iWebServiceFlightSoapClient iWebServiceFlight
        {
            get { return BasePage._WebServiceFlight; }
            set { BasePage._WebServiceFlight = value; }
        }

        private static iWebServiceReferenceHotel.iWebServiceHotelSoapClient _WebServiceHotel;
        protected static iWebServiceReferenceHotel.iWebServiceHotelSoapClient iWebServiceHotel
        {
            get { return BasePage._WebServiceHotel; }
            set { BasePage._WebServiceHotel = value; }
        }

        private iWebServiceReference.USERS _user;
        protected iWebServiceReference.USERS SESSION_USER
        {
            get 
            {
                if (_user == null && Session[PubConstant.APP_SESSION_USER_OBJECT] != null)
                    _user = (iTrip.iWebServiceReference.USERS)HttpContext.Current.Session[PubConstant.APP_SESSION_USER_OBJECT];

                return _user;
            }
        }
	    #endregion

        #region <<构造函数定义>>
        public BasePage()
        {
            //普通WEB服务
            if (_WebService == null)
                _WebService = new iWebServiceReference.iWebServiceSoapClient();

            //机票预定WEB服务
            if (_WebServiceFlight == null)
                _WebServiceFlight = new iWebServiceReferenceFlight.iWebServiceFlightSoapClient();

            //宾馆预定WEB服务
            if (_WebServiceHotel == null)
                _WebServiceHotel = new iWebServiceReferenceHotel.iWebServiceHotelSoapClient();
        }

        protected void CheckLoginUser()
        {
            if (SESSION_USER == null)
                Response.Redirect(ConfigurationSettings.AppSettings["Login.Page"].ToString(),true);
        }
        #endregion

    }
}
