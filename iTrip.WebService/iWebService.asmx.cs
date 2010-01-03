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
    /// iWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class iWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public Entity.USERS ValidateUser(string USER_NAME, string PASSWORD)
        {
            return iTrip.Singleton.Single.usersBLL.ValidateUser(USER_NAME, PASSWORD);
        }

        [WebMethod]
        public void AddUser(iTrip.Entity.USERS Entity)
        {
            iTrip.Singleton.Single.usersBLL.Add(Entity);
        }

        [WebMethod]
        public void UpdateUser(iTrip.Entity.USERS Entity)
        {
            iTrip.Singleton.Single.usersBLL.Update(Entity);
        }
    }
}
