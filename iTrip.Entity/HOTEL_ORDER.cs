using System;
namespace iTrip.Entity
{
    /// <summary>
    /// 实体类HOTEL_ORDER
    /// </summary>
   [Serializable]
    public class HOTEL_ORDER
    {
       public HOTEL_ORDER()
        { }
        #region Entity
       private int _hotel_order_id;
       public int HOTEL_ORDER_ID
       {
           get { return _hotel_order_id; }
           set { _hotel_order_id = value; }
       }
       private int _room_id;
       public int ROOM_ID
       {
           get { return _room_id; }
           set { _room_id = value; }
       }
       private string _user_name;
       public string USER_NAME
       {
           get { return _user_name; }
           set { _user_name = value; }
       }
       private DateTime? _check_in;
       public DateTime? CHECK_IN
       {
           get { return _check_in; }
           set { _check_in = value; }
       }
       private DateTime? _check_out;
       public DateTime? CHECK_OUT
       {
           get { return _check_out; }
           set { _check_out = value; }
       }
       private decimal? _fare;
       public decimal? FARE
       {
           get { return _fare; }
           set { _fare = value; }
       }

       private int? _confirm_flag;
       public int? CONFIRM_FLAG
       {
           get { return _confirm_flag; }
           set { _confirm_flag = value; }
       }
        #endregion Entity
    }
}

