using System;
using System.Data;
using System.Collections.Generic;

namespace iTrip.BLL
{
    /// <summary>
    /// 业务逻辑类FlightOrderBLL 的摘要说明。
    /// </summary>
    public class FlightOrderBLL
    {
        private readonly iTrip.DAL.FlightOrderDAL dal = new iTrip.DAL.FlightOrderDAL();
        public FlightOrderBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 获取实例
        /// </summary>
        public iTrip.Entity.FLIGHT_ORDER GetEntity(int FLIGHT_ORDER_ID)
        {
            return dal.GetEntity(FLIGHT_ORDER_ID);
        }

        /// <summary>
        /// 新增
        /// </summary>
        public void Add(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            dal.Add(Entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            dal.Update(Entity);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FLIGHT_ORDER_ID)
        {
            dal.Delete(FLIGHT_ORDER_ID);
        }

        /// <summary>
        /// 获取机票订单列表
        /// </summary>
        public DataSet GetOrderFlightList(string userName)
        {
            return dal.GetOrderFlightList(userName);
        }
        #endregion  成员方法
    }
}

