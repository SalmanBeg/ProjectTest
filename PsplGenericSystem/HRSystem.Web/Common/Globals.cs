using System;
using System.Web;

namespace HRSystem.Web.Common
{
    public class Globals
    {

        public static Boolean gIslogin
        {
            get
            {
                if (HttpContext.Current.Session["gIslogin"] == null) return false;
                else return Convert.ToBoolean(HttpContext.Current.Session["gIslogin"]);
            }
            set
            {
                HttpContext.Current.Session["gIslogin"] = value;
            }
        }
        public static String gUserName
        {
            get
            {
                return HttpContext.Current.Session["gUserName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["gUserName"] = value;
            }
        }

        public static String gRoleName
        {
            get
            {
                return HttpContext.Current.Session["gRoleName"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["gRoleName"] = value;
            }
        }

        public static string gUserId
        {
            get
            {
                return HttpContext.Current.Session["gUserId"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["gUserId"] = value;
            }
        }

        public static string connectionString
        {
            get
            {
                return HttpContext.Current.Session["gconnectionString"] as string ?? string.Empty;
            }
            set
            {
                HttpContext.Current.Session["gconnectionString"] = value;
            }
        }
    }
}