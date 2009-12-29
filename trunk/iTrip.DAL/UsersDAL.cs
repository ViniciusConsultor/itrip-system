using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTrip.DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 校验登录
        /// </summary>
        public bool ValidateUser(string USER_NAME, string PASSWORD)
        {
            if (USER_NAME.Equals("helocean") && PASSWORD.Equals("password"))
                return true;
            return false;
        }
    }


}
