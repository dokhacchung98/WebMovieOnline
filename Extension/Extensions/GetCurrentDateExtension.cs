using System;
using System.Globalization;

namespace Extension.Extensions
{
    public static class GetCurrentDateExtension
    {
        public static DateTime GetCurrentTime()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime dt =
                DateTime.ParseExact(currentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return dt;
        }
    }
}