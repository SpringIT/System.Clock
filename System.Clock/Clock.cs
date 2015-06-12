namespace System
{
        public static class Clock
        {
            private static readonly Func<DateTime> DefaultDateProvider = () => DateTime.UtcNow;

            public static Func<DateTime> DateTimeProvider = DefaultDateProvider;

            public static void Reset()
            {
                DateTimeProvider = DefaultDateProvider;
            }

            public static DateTime Now
            {
                get { return DateTimeProvider.Invoke(); }
            }

            public static DateTime Today
            {
                get { return Now.Date; }
            }

            public static DateTime Yesterday
            {
                get { return Today.AddDays(-1); }
            }

            public static DateTime Tomorrow
            {
                get { return Today.AddDays(1); }
            }

            public static long Ticks
            {
                get { return Now.Ticks; }
            }
        }
}
