using System;
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
            SqlBuilder.Append(@"SELECT H.HOTEL_ID,H.HOTEL_NAME,H.HOTEL_PHONE,HD.ROOM_ID,HD.ROOM_TYPE,HD.FARE,HD.FARE*(1-HD.DISCOUNT) AS DISCOUNT_FARES,
                    HD.BREAKFAST,HD.BED_TYPE,HD.NET_WORK,HD.QUANTITY FROM HOTEL H,HOTEL_DATA HD
                    WHERE H.HOTEL_ID=HD.HOTEL_ID AND NOT EXISTS
                    (SELECT HO.ROOM_ID FROM HOTEL_ORDER HO WHERE HO.ROOM_ID=HD.ROOM_ID AND HO.USER_NAME='" + Utils.ReplaceBadSQL(userName) + "')");
            if (Utils.IsNotEmpty(whereStr))
            {
                SqlBuilder.Append(SqlBuilder.ToString() + "　" + whereStr);
            }
            return AccessHelper.ExecuteDataSet(SqlBuilder.ToString(), null);
        }
    }
}
