namespace System
{
    public static class ClockExtensions
    {

        public static DateTime Today(this IClock clock)
        {
            return clock.Now.Date;
        }

        public static DateTime Yesterday(this IClock clock)
        {
             return clock.Now.AddDays(-1); 
        }

        public static DateTime Tomorrow(this IClock clock)
        {
            return clock.Now.AddDays(1); 
        }

        public static long Ticks(this IClock clock)
        {
             return clock.Now.Ticks; 
        }

        public static DateTime Min(this DateTime left, DateTime right)
        {
            return left < right ? left : right;
        }

        public static DateTime Max(this DateTime left, DateTime right)
        {
            return left > right ? left : right;
        }

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

            return new DateTime(dateTime.Year, dateTime.Month, daysInMonth).EndOfDay();

        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).StartOfDay();
        }
    }
}