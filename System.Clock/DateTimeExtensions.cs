using System.Data;
using System.Runtime.InteropServices;

namespace System
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return dateTime.Date
                .AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59);
        }

        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new DateTime(dateTime.Year,dateTime.Month,daysInMonth).EndOfDay();

        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).StartOfDay();
        }
      
    }
}