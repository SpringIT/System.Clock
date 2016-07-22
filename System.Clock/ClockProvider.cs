namespace System
{
    public class ClockProvider : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}