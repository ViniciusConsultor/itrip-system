using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTrip.Utility;
using System.Data.OleDb;
using System.Data;

namespace iTrip.DAL
{
    public class HotelOrderDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public iTrip.Entity.HOTEL_ORDER GetEntity(int HOTEL_ORDER_ID)
        {
            iTrip.Entity.HOTEL_ORDER Entity = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT HOTEL_ORDER_ID,ROOM_ID,USER_NAME,CHECK_IN,CHECK_OUT,FARE,CONFIRM_FLAG FROM HOTEL_ORDER WHERE HOTEL_ORDER_ID=@HOTEL_ORDER_ID");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@HOTEL_ORDER_ID",OleDbType.Integer,0, HOTEL_ORDER_ID)
            };

            DataSet ds = AccessHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count>0)
            {
                Entity = new iTrip.Entity.HOTEL_ORDER();
                Entity.HOTEL_ORDER_ID = int.Parse(ds.Tables[0].Rows[0]["HOTEL_ORDER_ID"].ToString());
                if (ds.Tables[0].Rows[0]["ROOM_ID"] != DBNull.Value)
                    Entity.ROOM_ID = int.Parse(ds.Tables[0].Rows[0]["ROOM_ID"].ToString());
                Entity.USER_NAME = Convert.ToString(ds.Tables[0].Rows[0]["USER_NAME"].ToString());

                if (ds.Tables[0].Rows[0]["CHECK_IN"] != DBNull.Value)
                    Entity.CHECK_IN = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHECK_IN"].ToString());
                if (ds.Tables[0].Rows[0]["CHECK_OUT"] != DBNull.Value)
                    Entity.CHECK_OUT = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHECK_OUT"].ToString());

                if (ds.Tables[0].Rows[0]["FARE"] != DBNull.Value)
                    Entity.FARE = decimal.Parse(ds.Tables[0].Rows[0]["FARE"].ToString());
                if (ds.Tables[0].Rows[0]["CONFIRM_FLAG"] != DBNull.Value)
                    Entity.CONFIRM_FLAG = int.Parse(ds.Tables[0].Rows[0]["CONFIRM_FLAG"].ToString());
            }

            return Entity;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(iTrip.Entity.HOTEL_ORDER Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO HOTEL_ORDER(");
            strSql.Append("ROOM_ID,USER_NAME,CHECK_IN,CHECK_OUT,FARE,CONFIRM_FLAG)");
            strSql.Append(" VALUES (");
            strSql.Append("@ROOM_ID,@USER_NAME,@CHECK_IN,@CHECK_OUT,@FARE,@CONFIRM_FLAG)");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@ROOM_ID",OleDbType.Integer,0, Entity.ROOM_ID),
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME),
              AccessHelper.MakeInParam("@CHECK_IN",OleDbType.Date,0, Entity.CHECK_IN),
              AccessHelper.MakeInParam("@CHECK_OUT",OleDbType.Date,0, Entity.CHECK_OUT),

              AccessHelper.MakeInParam("@FARE",OleDbType.Decimal,0, Entity.FARE),
              AccessHelper.MakeInParam("@CONFIRM_FLAG",OleDbType.Integer,0, Entity.CONFIRM_FLAG)
            };

            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(iTrip.Entity.HOTEL_ORDER Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE HOTEL_ORDER U SET ");
            strSql.Append("U.ROOM_ID = @ROOM_ID,");
            strSql.Append("U.USER_NAME = @USER_NAME,");
            strSql.Append("U.CHECK_IN = @CHECK_IN,");
            strSql.Append("U.CHECK_OUT = @CHECK_OUT, ");
            strSql.Append("U.FARE = @FARE, ");
            strSql.Append("U.CONFIRM_FLAG = @CONFIRM_FLAG ");

            strSql.Append(" WHERE U.HOTEL_ORDER_ID = @HOTEL_ORDER_ID");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@ROOM_ID",OleDbType.Integer,0, Entity.ROOM_ID),
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME),
              AccessHelper.MakeInParam("@CHECK_IN",OleDbType.Date,0, Entity.CHECK_IN),
              AccessHelper.MakeInParam("@CHECK_OUT",OleDbType.Date,0, Entity.CHECK_OUT),

              AccessHelper.MakeInParam("@FARE",OleDbType.Decimal,0, Entity.FARE),
              AccessHelper.MakeInParam("@CONFIRM_FLAG",OleDbType.Integer,0, Entity.CONFIRM_FLAG),

              AccessHelper.MakeInParam("@HOTEL_ORDER_ID",OleDbType.Integer,0, Entity.HOTEL_ORDER_ID)
            };
            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int HOTEL_ORDER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HOTEL_ORDER ");
            strSql.Append(" where HOTEL_ORDER_ID=@HOTEL_ORDER_ID ");
            OleDbParameter[] parameters = 
            {
				AccessHelper.MakeInParam("@HOTEL_ORDER_ID",OleDbType.Integer,0, HOTEL_ORDER_ID)
            };

            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获取酒店订单列表
        /// </summary>
        public DataSet GetOrderHotelList(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT H.HOTEL_NAME,HO.HOTEL_ORDER_ID,HO.ROOM_ID,HO.CHECK_IN,HO.CHECK_OUT,HO.FARE,HO.CONFIRM_FLAG
                    FROM HOTEL H,HOTEL_DATA HD,HOTEL_ORDER HO
                    WHERE H.HOTEL_ID=HD.HOTEL_ID AND HD.ROOM_ID=HO.ROOM_ID AND HO.USER_NAME='" + Utils.ReplaceBadSQL(userName) + "'");
            return AccessHelper.ExecuteDataSet(strSql.ToString());
        }
    }
}
