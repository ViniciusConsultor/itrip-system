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
        /// 是否存在该记录
        /// </summary>
        public bool ValidateUser(string USER_NAME, string PASSWORD)
        {
            return dal.ValidateUser(USER_NAME, PASSWORD);
        }
        #endregion  成员方法
    }
}

