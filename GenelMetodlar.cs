using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeForApp.Core.Helpers
{
    public static class GenelMetodlar
    {
        public static string ToSlug(this string str)
        {
            var strTitle = str;

            #region Generate SEO Friendly URL based on Title
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,^&"".".ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }

            //--- şekilndekileri değiştir
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Replace("ü", "u");
            strTitle = strTitle.Replace("ğ", "g");
            strTitle = strTitle.Replace("ö", "o");
            strTitle = strTitle.Replace("ş", "s");
            strTitle = strTitle.Replace("ç", "c");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Replace(".", "");
            strTitle = strTitle.Replace("’", "-");
            strTitle = strTitle.Replace("'", "-");
            strTitle = strTitle.Replace("…", "");
            strTitle = strTitle.Replace("“", "");
            strTitle = strTitle.Replace("”", "");
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("/", "-");

            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            #endregion
            return strTitle;
        }


        public static string Left(this string str, int lenght)
        {
            return str.Substring(0, Math.Min(str.Length, lenght)) + "...";
        }

        public static string GetTimeText(this DateTime eventTime)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - eventTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            if (delta <= 0)
            {
                return "henüz";
            }
            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "bir saniye önce" : ts.Seconds + " saniye önce";
            }
            if (delta < 2 * MINUTE)
            {
                return "bir dakika önce";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " dakika önce";
            }
            if (delta < 90 * MINUTE)
            {
                return "bir saat önce";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " saat önce";
            }
            if (delta < 48 * HOUR)
            {
                return "dün ";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " gün önce ";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "bir ay önce" : months + " ay önce";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "bir yıl önce" : years + " yıl önce";
            }
        }

    }
}
