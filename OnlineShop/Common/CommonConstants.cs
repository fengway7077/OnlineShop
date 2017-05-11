using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    public static class CommonConstants
    {
        //static
        public static string USER_SESSION = "USER_SESSION";
        //phan quyen
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";//headercart

        //xu ly language
        public static string CurrentCulture { set; get; }
    }
}