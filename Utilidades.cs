using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2
{
    public class Utilidades
    {
        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("Login.aspx");
        }
    }
}