using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace iTrip.WebService
{
    /// <summary>
    /// iWebServiceHotel 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class iWebServiceHotel : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet GetHotelList(string userName, string whereStr)
        {
            return iTrip.Singleton.Single.hotelDataBLL.GetHotelList(userName, whereStr);
        }

        [WebMethod]
        public iTrip.Entity.HOTEL_ORDER GetHotelOrder(int HOTEL_ORDER_ID)
        {
            return iTrip.Singleton.Single.hotelOrderBLL.GetEntity(HOTEL_ORDER_ID);
        }

        [WebMethod]
        public void AddHotelOrder(iTrip.Entity.HOTEL_ORDER Entity)
        {
            iTrip.Singleton.Single.hotelOrderBLL.Add(Entity);
        }

        [WebMethod]
        public void UpdateHotelOrder(iTrip.Entity.HOTEL_ORDER Entity)
        {
            iTrip.Singleton.Single.hotelOrderBLL.Update(Entity);
        }

        [WebMethod]
        public void DeleteHotelOrder(int HOTEL_ORDER_ID)
        {
            iTrip.Singleton.Single.hotelOrderBLL.Delete(HOTEL_ORDER_ID);

        }
        [WebMethod]
        public DataSet GetOrderHotelList(string userName)
        {
            return iTrip.Singleton.Single.hotelOrderBLL.GetOrderHotelList(userName);
        }
    }
}
