﻿using System;
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

namespace iTrip
{
    /// <summary>
    /// iTrip 系统页面基类.
    /// </summary>
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        #region <<共用属性定义>>

        //调用WebService对象
		private static iWebServiceReference.iWebServiceSoapClient _WebService;
        protected static iWebServiceReference.iWebServiceSoapClient iWebService
        {
            get { return BaseMasterPage._WebService; }
            set { BaseMasterPage._WebService = value; }
        }
	    #endregion

        #region <<构造函数定义>>

        public BaseMasterPage()
        {
            if (_WebService == null)
                _WebService = new iWebServiceReference.iWebServiceSoapClient();
        }
        #endregion

    }
}
