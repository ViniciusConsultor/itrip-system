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
    }
}
