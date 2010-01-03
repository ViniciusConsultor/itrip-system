using System;
using System.Data;
using System.Collections.Generic;

namespace iTrip.BLL
{
    /// <summary>
    /// 业务逻辑类HotelOrderBLL 的摘要说明。
    /// </summary>
    public class HotelOrderBLL
    {
        private readonly iTrip.DAL.HotelOrderDAL dal = new iTrip.DAL.HotelOrderDAL();
        public HotelOrderBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 获取实例
        /// </summary>
        public iTrip.Entity.HOTEL_ORDER GetEntity(int HOTEL_ORDER_ID)
        {
            return dal.GetEntity(HOTEL_ORDER_ID);
        }

        /// <summary>
        /// 新增
        /// </summary>
        public void Add(iTrip.Entity.HOTEL_ORDER Entity)
        {
            dal.Add(Entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update(iTrip.Entity.HOTEL_ORDER Entity)
        {
            dal.Update(Entity);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int HOTEL_ORDER_ID)
        {
            dal.Delete(HOTEL_ORDER_ID);
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        public DataSet GetOrderHotelList(string userName)
        {
            return dal.GetOrderHotelList(userName);
        }
        #endregion  成员方法
    }
}

