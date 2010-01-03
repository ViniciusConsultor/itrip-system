using System;
using System.Data;
using System.Collections.Generic;

namespace iTrip.BLL
{
    /// <summary>
    /// 业务逻辑类USER_ACCOUNT 的摘要说明。
    /// </summary>
    public class UsersBLL
    {
        private readonly iTrip.DAL.UsersDAL dal = new iTrip.DAL.UsersDAL();
        public UsersBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(iTrip.Entity.USERS Entity)
        {
            dal.Add(Entity);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(iTrip.Entity.USERS Entity)
        {
            dal.Update(Entity);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public Entity.USERS ValidateUser(string USER_NAME, string PASSWORD)
        {
            return dal.ValidateUser(USER_NAME, PASSWORD);
        }
        #endregion  成员方法
    }
}

