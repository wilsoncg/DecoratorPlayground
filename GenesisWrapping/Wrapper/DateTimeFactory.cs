using System;

namespace GenesisWrapping.Wrapper
{
    public class DateTimeFactory
    {
        public DateTime DateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}
