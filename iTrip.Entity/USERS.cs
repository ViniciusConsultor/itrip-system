using System;
namespace iTrip.Entity
{
    /// <summary>
    /// 实体类USERS
    /// </summary>
   [Serializable]
    public class USERS
    {
        public USERS()
        { }
        #region Entity
        private string _user_name;
        private string _password;
        private DateTime? _last_log_date;

        public DateTime? LAST_LOG_DATE
        {
            get { return _last_log_date; }
            set { _last_log_date = value; }
        }
        private int? _log_times;

        public int? LOG_TIMES
        {
            get { return _log_times; }
            set { _log_times = value; }
        }

        /// <summary>
        /// USER_NAME
        /// </summary>
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// PASSWORD
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Entity
    }
}

