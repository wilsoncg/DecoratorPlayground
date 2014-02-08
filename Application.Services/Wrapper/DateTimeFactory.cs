using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class DateTimeFactory
    {
        public DateTime DateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}
