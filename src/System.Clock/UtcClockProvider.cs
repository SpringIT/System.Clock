namespace System
{
    public class UtcClockProvider : IClock
    {
        public DateTime Now => DateTime.UtcNow;
    }
}