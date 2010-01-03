using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTrip.Utility;
using System.Data.OleDb;
using System.Data;

namespace iTrip.DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 校验登录
        /// </summary>
        public Entity.USERS ValidateUser(string USER_NAME, string PASSWORD)
        {
            Entity.USERS User=null;

            if (Utils.IsNotEmpty(USER_NAME) && Utils.IsNotEmpty(PASSWORD))
            {
               StringBuilder SqlBuilder=new StringBuilder();
               SqlBuilder.Append("SELECT U.USER_NAME,U.PASSWORD,U.LAST_LOG_DATE,U.LOG_TIMES FROM USERS U WHERE U.USER_NAME=@USER_NAME AND U.PASSWORD=@PASSWORD");
               OleDbParameter[] parameters =
               {
                  AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, USER_NAME),
                  AccessHelper.MakeInParam("@PASSWORD",OleDbType.VarWChar,0, PASSWORD)
               };
               
               //数据库操作
               using (DataSet ds = AccessHelper.ExecuteDataSet(SqlBuilder.ToString(), parameters))
               {
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       //返回用户信息
                       User = new iTrip.Entity.USERS();
                       User.USER_NAME = Convert.ToString(ds.Tables[0].Rows[0]["USER_NAME"]);
                       User.PASSWORD = Convert.ToString(ds.Tables[0].Rows[0]["PASSWORD"]);
                       if (ds.Tables[0].Rows[0]["LAST_LOG_DATE"] != DBNull.Value)
                       {
                           User.LAST_LOG_DATE = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_LOG_DATE"]);
                       }
                       else
                       {
                           User.LAST_LOG_DATE = DateTime.Now;
                       }
                       if (ds.Tables[0].Rows[0]["LOG_TIMES"] != DBNull.Value)
                       {
                           User.LOG_TIMES = Convert.ToInt32(ds.Tables[0].Rows[0]["LOG_TIMES"])+1;//登录次数加一
                       }
                       else
                       {
                           User.LOG_TIMES = 1;
                       }

                       //更新数据库
                       Entity.USERS updateUser = new iTrip.Entity.USERS();
                       updateUser.USER_NAME = User.USER_NAME;
                       updateUser.PASSWORD = User.PASSWORD;
                       updateUser.LAST_LOG_DATE = DateTime.Now;
                       updateUser.LOG_TIMES = User.LOG_TIMES;
                       Update(updateUser);
                   }
               }
            }
            return User;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(iTrip.Entity.USERS Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO USERS(");
            strSql.Append("USER_NAME,PASSWORD,LAST_LOG_DATE,LOG_TIMES)");
            strSql.Append(" VALUES (");
            strSql.Append("@USER_NAME,@PASSWORD,@LAST_LOG_DATE,@LOG_TIMES)");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME),
              AccessHelper.MakeInParam("@PASSWORD",OleDbType.VarWChar,0, Entity.PASSWORD),
              AccessHelper.MakeInParam("@LAST_LOG_DATE",OleDbType.Date,0, Entity.LAST_LOG_DATE),
              AccessHelper.MakeInParam("@LOG_TIMES",OleDbType.Integer,0, Entity.LOG_TIMES)
            };

            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(iTrip.Entity.USERS Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE USERS U SET ");
            strSql.Append("U.PASSWORD=@PASSWORD,");
            strSql.Append("U.LAST_LOG_DATE=@LAST_LOG_DATE,");
            strSql.Append("U.LOG_TIMES=@LOG_TIMES ");
            strSql.Append(" WHERE U.USER_NAME=@USER_NAME");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@PASSWORD",OleDbType.VarWChar,0, Entity.PASSWORD),
              AccessHelper.MakeInParam("@LAST_LOG_DATE",OleDbType.Date,0, Entity.LAST_LOG_DATE),
              AccessHelper.MakeInParam("@LOG_TIMES",OleDbType.Integer,0, Entity.LOG_TIMES),
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME)
            };
            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
    }
}
