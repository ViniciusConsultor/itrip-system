using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTrip.Utility;
using System.Data.OleDb;
using System.Data;

namespace iTrip.DAL
{
    public class FlightOrderDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public iTrip.Entity.FLIGHT_ORDER GetEntity(int FLIGHT_ORDER_ID)
        {
            iTrip.Entity.FLIGHT_ORDER Entity=null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT FLIGHT_ORDER_ID,FLIGHT_ID,USER_NAME,FARE,CONFIRM_FLAG,PERSON_COUNT FROM FLIGHT_ORDER WHERE FLIGHT_ORDER_ID=@FLIGHT_ORDER_ID");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@FLIGHT_ORDER_ID",OleDbType.Integer,0, FLIGHT_ORDER_ID)
            };

            DataSet ds = AccessHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count>0)
            {
                Entity = new iTrip.Entity.FLIGHT_ORDER();
                Entity.FLIGHT_ORDER_ID = int.Parse(ds.Tables[0].Rows[0]["FLIGHT_ORDER_ID"].ToString());
                if (ds.Tables[0].Rows[0]["FLIGHT_ID"] != DBNull.Value)
                    Entity.FLIGHT_ID = int.Parse(ds.Tables[0].Rows[0]["FLIGHT_ID"].ToString());
                Entity.USER_NAME = Convert.ToString(ds.Tables[0].Rows[0]["USER_NAME"].ToString());
                if (ds.Tables[0].Rows[0]["FARE"] != DBNull.Value)
                    Entity.FARE = decimal.Parse(ds.Tables[0].Rows[0]["FARE"].ToString());
                if (ds.Tables[0].Rows[0]["CONFIRM_FLAG"] != DBNull.Value)
                    Entity.CONFIRM_FLAG = int.Parse(ds.Tables[0].Rows[0]["CONFIRM_FLAG"].ToString());
                if (ds.Tables[0].Rows[0]["PERSON_COUNT"] != DBNull.Value)
                    Entity.PERSON_COUNT = int.Parse(ds.Tables[0].Rows[0]["PERSON_COUNT"].ToString());
            }

            return Entity;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO FLIGHT_ORDER(");
            strSql.Append("FLIGHT_ID,USER_NAME,FARE,CONFIRM_FLAG,PERSON_COUNT)");
            strSql.Append(" VALUES (");
            strSql.Append("@FLIGHT_ID,@USER_NAME,@FARE,@CONFIRM_FLAG,@PERSON_COUNT)");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@FLIGHT_ID",OleDbType.VarWChar,0, Entity.FLIGHT_ID),
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME),
              AccessHelper.MakeInParam("@FARE",OleDbType.Decimal,0, Entity.FARE),
              AccessHelper.MakeInParam("@CONFIRM_FLAG",OleDbType.Integer,0, Entity.CONFIRM_FLAG),
              AccessHelper.MakeInParam("@PERSON_COUNT",OleDbType.Integer,0, Entity.PERSON_COUNT)
            };

            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(iTrip.Entity.FLIGHT_ORDER Entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE FLIGHT_ORDER U SET ");
            strSql.Append("U.FLIGHT_ID = @FLIGHT_ID,");
            strSql.Append("U.USER_NAME = @USER_NAME,");
            strSql.Append("U.FARE = @FARE,");
            strSql.Append("U.CONFIRM_FLAG = @CONFIRM_FLAG, ");
            strSql.Append("U.PERSON_COUNT = @PERSON_COUNT ");
            strSql.Append(" WHERE U.FLIGHT_ORDER_ID = @FLIGHT_ORDER_ID");
            OleDbParameter[] parameters =
            {
              AccessHelper.MakeInParam("@FLIGHT_ID",OleDbType.Integer,0, Entity.FLIGHT_ID),
              AccessHelper.MakeInParam("@USER_NAME",OleDbType.VarWChar,0, Entity.USER_NAME),
              AccessHelper.MakeInParam("@FARE",OleDbType.Decimal,0, Entity.FARE),
              AccessHelper.MakeInParam("@CONFIRM_FLAG",OleDbType.Integer,0, Entity.CONFIRM_FLAG),
              AccessHelper.MakeInParam("@PERSON_COUNT",OleDbType.Integer,0, Entity.PERSON_COUNT),
              AccessHelper.MakeInParam("@FLIGHT_ORDER_ID",OleDbType.Integer,0, Entity.FLIGHT_ORDER_ID)
            };
            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FLIGHT_ORDER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FLIGHT_ORDER ");
            strSql.Append(" where FLIGHT_ORDER_ID=@FLIGHT_ORDER_ID ");
            OleDbParameter[] parameters = 
            {
				AccessHelper.MakeInParam("@FLIGHT_ORDER_ID",OleDbType.Integer,0, FLIGHT_ORDER_ID)
            };

            AccessHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获取机票订单列表
        /// </summary>
        public DataSet GetOrderFlightList(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT AIRLINE.AIRLINE_NAME, FLIGHT_ORDER.FLIGHT_ORDER_ID, FLIGHT_DATA.DEPART_DATE, FLIGHT_DATA.AIR_PORT, FLIGHT_DATA.FROM, FLIGHT_DATA.TO,FLIGHT_ORDER.FARE,
            FLIGHT_ORDER.CONFIRM_FLAG,PERSON_COUNT
            FROM (AIRLINE INNER JOIN FLIGHT_DATA ON AIRLINE.AIRLINE_ID = FLIGHT_DATA.AIRLINE_ID) 
            INNER JOIN FLIGHT_ORDER ON FLIGHT_DATA.FLIGHT_ID = FLIGHT_ORDER.FLIGHT_ID WHERE FLIGHT_ORDER.USER_NAME='" + Utils.ReplaceBadSQL(userName) + "'");
            return AccessHelper.ExecuteDataSet(strSql.ToString());
        }
    }
}
