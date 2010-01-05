using System;
namespace iTrip.Entity
{
    /// <summary>
    /// 实体类FLIGHT_ORDER
    /// </summary>
   [Serializable]
    public class FLIGHT_ORDER
    {
       public FLIGHT_ORDER()
        { }
        #region Entity
       private int _flight_order_id;

       public int FLIGHT_ORDER_ID
       {
           get { return _flight_order_id; }
           set { _flight_order_id = value; }
       }
       private int _flight_id;

       public int FLIGHT_ID
       {
           get { return _flight_id; }
           set { _flight_id = value; }
       }
       private string _user_name;

       public string USER_NAME
       {
           get { return _user_name; }
           set { _user_name = value; }
       }
       private int? _confirm_flag;

       public int? CONFIRM_FLAG
       {
           get { return _confirm_flag; }
           set { _confirm_flag = value; }
       }

       private decimal? _fare;
       public decimal? FARE
       {
           get { return _fare; }
           set { _fare = value; }
       }

       private int? _person_count;
       public int? PERSON_COUNT
       {
           get { return _person_count; }
           set { _person_count = value; }
       }
        #endregion Entity
    }
}

