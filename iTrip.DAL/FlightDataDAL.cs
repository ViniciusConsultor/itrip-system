using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iTrip.Utility;

namespace iTrip.DAL
{
    public class FlightDataDAL
    {
        public DataSet GetFlightList(string userName,string whereStr)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            StringBuilder TMPSqlBuilder = new StringBuilder();
            SqlBuilder.Append(@"SELECT AIRLINE.AIRLINE_ID, AIRLINE.AIRLINE_NAME, FLIGHT_DATA.FLIGHT_ID, 
                FLIGHT_DATA.AIR_PORT, FLIGHT_DATA.FLIGHT_TYPE, FLIGHT_DATA.FROM, FLIGHT_DATA.TO, FLIGHT_DATA.DEPART_DATE, 
                FLIGHT_DATA.DELIVERY_TICKET_CITY, FLIGHT_DATA.ALL_FARES, FLIGHT_DATA.ALL_FARES*(1-FLIGHT_DATA.DISCOUNT) AS DISCOUNT_FARES,FLIGHT_DATA.REMARK
                FROM AIRLINE INNER JOIN FLIGHT_DATA ON AIRLINE.AIRLINE_ID = FLIGHT_DATA.AIRLINE_ID
                WHERE NOT EXISTS
                (SELECT FLIGHT_ORDER.FLIGHT_ID FROM FLIGHT_ORDER WHERE FLIGHT_ORDER.FLIGHT_ID=FLIGHT_DATA.FLIGHT_ID AND FLIGHT_ORDER.USER_NAME='"+ Utils.ReplaceBadSQL(userName) +"')");
            if (Utils.IsNotEmpty(whereStr))
            {
                TMPSqlBuilder.Append(SqlBuilder.ToString() +" "+ whereStr);
            }
            else
            {
                TMPSqlBuilder.Append(SqlBuilder.ToString());
            }
            return AccessHelper.ExecuteDataSet(TMPSqlBuilder.ToString(), null);
        }

        public DataSet GetFlightCorporationList()
        {
            StringBuilder SqlBuilder = new StringBuilder();
            SqlBuilder.Append(@"SELECT DISTINCT(A.AIRLINE_NAME) AS AIRLINE_NAME FROM AIRLINE A");
            return AccessHelper.ExecuteDataSet(SqlBuilder.ToString(), null);
        }

        public DataSet GetFlightFromList(int fromOrTo)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (fromOrTo == 0)
            {
                SqlBuilder.Append(@"SELECT DISTINCT(FD.FROM) AS FLIGHT_FROM FROM FLIGHT_DATA FD");
            }
            else
            {
                SqlBuilder.Append(@"SELECT DISTINCT(FD.TO) AS FLIGHT_TO FROM FLIGHT_DATA FD");
            }
            return AccessHelper.ExecuteDataSet(SqlBuilder.ToString(), null);
        }

        public DataSet GetAirPortList()
        {
            StringBuilder SqlBuilder = new StringBuilder();
            SqlBuilder.Append(@"SELECT DISTINCT(FD.AIR_PORT) AS AIR_PORT FROM FLIGHT_DATA FD");
            return AccessHelper.ExecuteDataSet(SqlBuilder.ToString(), null);
        }
    }
}
