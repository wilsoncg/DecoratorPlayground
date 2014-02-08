using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Wrapper
{
    public class EFTCardTransactionState
    {
        public static State EnrolledIn3DSecureAuthenticationRequired { get { return new State(1); } }
        public static State NotEnrolledIn3DSecureCompletePayment { get { return new State(2);} }
        public static State Rejected { get { return new State(3); }
        }
    }
}
