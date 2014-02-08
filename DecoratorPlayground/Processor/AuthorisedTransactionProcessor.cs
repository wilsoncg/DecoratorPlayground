using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Contracts;

namespace FundingService.Processor
{
    public class AuthorisedTransactionProcessor
    {
        public AuthorisedTransactionResponse Process(MakePaymentRequest request, Response authResponse)
        {
            return new AuthorisedTransactionResponse();
        }
    }
}
