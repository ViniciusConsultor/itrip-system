using System;
using System.Collections.Generic;
using System.Text;

namespace iTrip.Singleton
{
    public class Single
    {
        private static iTrip.BLL.UsersBLL _usersBLL;
        public static iTrip.BLL.UsersBLL usersBLL
        {
            get
            {
                if (_usersBLL == null)
                {
                    _usersBLL = new iTrip.BLL.UsersBLL();
                }
                return _usersBLL;
            }
        }

        private static iTrip.BLL.FlightDataBLL _flightDataBLL;
        public static iTrip.BLL.FlightDataBLL flightDataBLL
        {
            get
            {
                if (_flightDataBLL == null)
                {
                    _flightDataBLL = new iTrip.BLL.FlightDataBLL();
                }
                return _flightDataBLL;
            }
        }

        private static iTrip.BLL.FlightOrderBLL _flightOrderBLL;
        public static iTrip.BLL.FlightOrderBLL flightOrderBLL
        {
            get
            {
                if (_flightOrderBLL == null)
                {
                    _flightOrderBLL = new iTrip.BLL.FlightOrderBLL();
                }
                return _flightOrderBLL;
            }
        }

        private static iTrip.BLL.HotelDataBLL _hotelDataBLL;
        public static iTrip.BLL.HotelDataBLL hotelDataBLL
        {
            get
            {
                if (_hotelDataBLL == null)
                {
                    _hotelDataBLL = new iTrip.BLL.HotelDataBLL();
                }
                return _hotelDataBLL;
            }
        }

        private static iTrip.BLL.HotelOrderBLL _hotelOrderBLL;
        public static iTrip.BLL.HotelOrderBLL hotelOrderBLL
        {
            get
            {
                if (_hotelOrderBLL == null)
                {
                    _hotelOrderBLL = new iTrip.BLL.HotelOrderBLL();
                }
                return _hotelOrderBLL;
            }
        }
    }
}
