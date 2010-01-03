using System;
using System.Data;
using System.Collections.Generic;

namespace iTrip.BLL
{
    /// <summary>
    /// 业务逻辑类HotelDataBLL 的摘要说明。
    /// </summary>
    public class HotelDataBLL
    {
        private readonly iTrip.DAL.HotelDataDAL dal = new iTrip.DAL.HotelDataDAL();
        public HotelDataBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DataSet GetHotelList(string userName, string whereStr)
        {
            return dal.GetHotelList(userName, whereStr);
        }
        #endregion  成员方法
    }
}

