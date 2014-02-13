using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Application.Services
{
    public class PaymentService
    {
        public MakePaymentResponse MakePayment(MakePaymentRequest request)
        {
            return new MakePaymentResponse();
        }

        public AuthResponse AuthorisePayment(string serviceProviderReference, string pares, string tradingAccountCode, int transactionId)
        {
            return new AuthResponse();
        }

        public AuthResponse MakeMotoPayment(MakePaymentRequest request, string tradingAccountCode, int transactionId, int fundingChannelId)
        {
            return new AuthResponse();
        }
    }
}
