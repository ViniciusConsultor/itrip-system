﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iTrip.Utility;

namespace iTrip.DAL
{
    public class HotelDataDAL
    {
        public DataSet GetHotelList(string userName,string whereStr)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            StringBuilder TMPSqlBuilder = new StringBuilder();
            SqlBuilder.Append(@"SELECT H.HOTEL_ID,H.HOTEL_NAME,H.HOTEL_PHONE,HD.ROOM_ID,HD.ROOM_TYPE,HD.FARE,HD.FARE*(1-HD.DISCOUNT) AS DISCOUNT_FARES,
                    HD.BREAKFAST,HD.BED_TYPE,HD.NET_WORK,HD.QUANTITY FROM HOTEL H,HOTEL_DATA HD
                    WHERE H.HOTEL_ID=HD.HOTEL_ID ");
            if (Utils.IsNotEmpty(whereStr))
            {
                TMPSqlBuilder.Append(SqlBuilder.ToString() + " " + whereStr);
            }
            else
            {
                TMPSqlBuilder.Append(SqlBuilder.ToString());
            }
            return AccessHelper.ExecuteDataSet(TMPSqlBuilder.ToString(), null);
        }
    }
}
