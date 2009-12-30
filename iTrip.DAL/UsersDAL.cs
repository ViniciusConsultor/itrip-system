using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTrip.Utility;
using System.Data.OleDb;

namespace iTrip.DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 校验登录
        /// </summary>
        public bool ValidateUser(string USER_NAME, string PASSWORD)
        {
            if (Utils.IsNotEmpty(USER_NAME) && Utils.IsNotEmpty(PASSWORD))
            {
               StringBuilder SqlBuilder=new StringBuilder();
               SqlBuilder.Append("SELECT COUNT(1) FROM USERS U WHERE U.USER_NAME=@USER_NAME AND U.PASSWORD=@PASSWORD");
               OleDbParameter[] parameter =new OleDbParameter[]
               {
                  new OleDbParameter("@USER_NAME",Utils.ReplaceBadSQL(USER_NAME)),
                  new OleDbParameter("@PASSWORD",Utils.ReplaceBadSQL(PASSWORD))
               };
               
               //数据库操作
               if (AccessHelper.Exists(SqlBuilder.ToString(), parameter))
               {
                   return true;
               }
               else
               {
                   return false;
               }
            }
            return false;
        }
    }


}
