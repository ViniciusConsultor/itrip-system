using System;
namespace iTrip.Entity
{
    /// <summary>
    /// 实体类USERS
    /// </summary>
    public class USERS
    {
        public USERS()
        { }
        #region Entity
        private string _user_name;
        private string _password;
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

