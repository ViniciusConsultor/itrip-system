using System;
using System.Data;
using System.Collections.Generic;

namespace iTrip.BLL
{
    /// <summary>
    /// 业务逻辑类FlightDataBLL 的摘要说明。
    /// </summary>
    public class FlightDataBLL
    {
        private readonly iTrip.DAL.FlightDataDAL dal = new iTrip.DAL.FlightDataDAL();
        public FlightDataBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DataSet GetFlightList(string userName, string whereStr)
        {
            return dal.GetFlightList(userName,whereStr);
        }
        #endregion  成员方法
    }
}

