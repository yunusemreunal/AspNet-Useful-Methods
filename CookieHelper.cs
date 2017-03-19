using System;
using System.Web;

namespace CodeForApp.Core.Helpers
{
    public static class CookieHelper
    {
        public static void SetCookie(string name, string value)
        {
            var myCookie = new HttpCookie(name)
                           {
                               Value = HttpContext.Current.Server.UrlEncode(value),
                               Expires = DateTime.Now.AddMonths(1)
                           };
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        public static string GetCookie(string name)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[name];
            return httpCookie != null ? HttpContext.Current.Server.UrlDecode(httpCookie.Value) : "0";
        }

        public static void DeleteCookie(string name)
        {
            var currentUserCookie = HttpContext.Current.Request.Cookies[name];
            HttpContext.Current.Response.Cookies.Remove(name);

            if (currentUserCookie == null) return;

            currentUserCookie.Expires = DateTime.Now.AddDays(-10);
            currentUserCookie.Value = null;
            HttpContext.Current.Response.SetCookie(currentUserCookie);
        }
    }
}
