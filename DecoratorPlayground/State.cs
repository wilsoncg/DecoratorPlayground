using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundingService
{
    public class State
    {
        private int _id;
        public State(int id)
        {
            _id = id;
        }

        public int Id()
        {
            return _id;
        }
    }
}
