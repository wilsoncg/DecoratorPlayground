using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Contracts;
using GenesisWrapping;
using GenesisWrapping.Wrapper;

namespace FundingService.Processor
{
    public class AuthorisedTransactionProcessor
    {
        public TransactionService TransactionService { get; set; }
        public TransactionAuditor TransactionAuditor { get; set; }
        public FulfillTransactionProcessor FulfillTransactionProcessor { get; set; }
        public CancelTransactionProcessor CancelTransactionProcessor { get; set; }
        public SmtpService SmtpService { get; set; }

        public AuthResponse Process(MakePaymentRequest request, AuthResponse authResponse)
        {
            if (authResponse.Code == EFTFeedback.Success.Id)
            {
                TransactionService.UpdateTransactionState(authResponse, EFTCardTransactionState.Authorised.Id);

                if (authResponse.Recommendation == 0)
                {
                    TransactionService.UpdateTransactionState(authResponse, EFTCardTransactionState.PassedFraudCheckAttemptingFulfill.Id);
                    TransactionAuditor.RecordTransactionStep(authResponse.TransactionId, authResponse.Code, authResponse.Description);
                    return FulfillTransactionProcessor.FulfillTransaction(authResponse.TransactionId, authResponse, request, request.RequestSource, request.TradingAccountCode);
                }

                TransactionService.UpdateTransactionState(authResponse, EFTCardTransactionState.FailedFraudCheckAttemptingCancellation.Id);
                TransactionAuditor.RecordFailedTransaction(authResponse.TransactionId, authResponse.Recommendation, "Fraud check failed");
                SmtpService.Send("fraudulent activity", string.Format("The payment failed due to 3rdManFraud score. Please investigate transaction {0}", authResponse.TransactionId));
                return CancelTransactionProcessor.CancelTransaction(authResponse.TransactionId, authResponse, request, request.RequestSource, request.TradingAccountCode);
            }

            TransactionService.UpdateTransactionState(authResponse, EFTCardTransactionState.Denied.Id);
            TransactionAuditor.RecordFailedTransaction(authResponse.TransactionId, authResponse.Code, authResponse.Description);

            return authResponse;
        }
    }

    public class SmtpService
    {
        public void Send(string fraudulentActivity, string format)
        {
        }
    }

    public class CancelTransactionProcessor
    {
        public AuthResponse CancelTransaction(int transactionId, AuthResponse authResponse, MakePaymentRequest request, int requestSource, string tradingAccountCode)
        {
            return new AuthResponse();
        }
    }

    public class FulfillTransactionProcessor
    {
        public AuthResponse FulfillTransaction(int transactionId, AuthResponse authResponse, MakePaymentRequest request, int requestSource, string tradingAccountCode)
        {
            return new AuthResponse();
        }
    }
}
