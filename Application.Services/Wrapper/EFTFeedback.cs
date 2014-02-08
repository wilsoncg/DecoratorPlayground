using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Wrapper
{
    public class EFTFeedback
    {
        public static State ThreeDSecureEnrolled { get { return new State(1); } }
        public static State NotThreeDSecureEnrolled { get { return new State(2); } }
    }
}
