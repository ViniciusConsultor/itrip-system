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
    /// iWebServiceFlight 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class iWebServiceFlight : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet GetFlightList(string userName, string whereStr)
        {
            return iTrip.Singleton.Single.flightDataBLL.GetFlightList(userName, whereStr);
        }

        [WebMethod]
        public iTrip.Entity.FLIGHT_ORDER GetFlightOrder(int FLIGHT_ORDER_ID)
        {
            return iTrip.Singleton.Single.flightOrderBLL.GetEntity(FLIGHT_ORDER_ID);
        }

        [WebMethod]
        public void AddFlightOrder(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            iTrip.Singleton.Single.flightOrderBLL.Add(Entity);
        }

        [WebMethod]
        public void UpdateFlightOrder(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            iTrip.Singleton.Single.flightOrderBLL.Update(Entity);
        }

        [WebMethod]
        public void DeleteFlightOrder(int FLIGHT_ORDER_ID)
        {
            iTrip.Singleton.Single.flightOrderBLL.Delete(FLIGHT_ORDER_ID);

        }
        [WebMethod]
        public DataSet GetOrderFlightList(string userName)
        {
            return iTrip.Singleton.Single.flightOrderBLL.GetOrderFlightList(userName);
        }

        [WebMethod]
        public DataSet GetFlightCorporationList()
        {
            return iTrip.Singleton.Single.flightDataBLL.GetFlightCorporationList();
        }

        [WebMethod]
        public DataSet GetFlightFromList(int fromOrTo)
        {
            return iTrip.Singleton.Single.flightDataBLL.GetFlightFromList(fromOrTo);

        }
        [WebMethod]
        public DataSet GetAirPortList()
        {
            return iTrip.Singleton.Single.flightDataBLL.GetAirPortList();
        }
    }
}
