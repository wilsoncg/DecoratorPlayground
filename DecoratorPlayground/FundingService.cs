using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Contracts;
using FundingService.Processor;
using GenesisWrapping;
using GenesisWrapping.Wrapper;
using log4net;

namespace FundingService
{
    public interface IFundingService
    {
        MakePaymentResponse MakePayment(MakePaymentRequest request);
    }

    public class FundingService : IFundingService
    {
        private ILog _log = LogManager.GetLogger(typeof(FundingService));
        public TransactionService TransactionService { get; set; }
        public TransactionAuditor TransactionAuditor { get; set; }
        public PaymentService PaymentService { get; set; }
        public IGenesisWrapper GenesisWrapper { get; set; }
        public AuthorisedTransactionProcessor AuthorisedTransactionProcessor { get; set; }

        public MakePaymentResponse MakePayment(MakePaymentRequest request)
        {
            _log.InfoFormat("Attempting payment for Service provider reference {0}", request.ServiceProviderReference);
            var transactionId = TransactionService.GenerateNewTransactionId();
            var transaction = GenesisWrapper.GetEftCardTransaction(transactionId);

            _log.InfoFormat("Attempting payment for {0}", request.TradingAccountCode);
            TransactionAuditor.StartQueryTransaction(transactionId);

            var paymentServiceResponse = PaymentService.MakePayment(request);
            if (transaction.FundingChannelId == FundingChannel.Web.Id)
            {
                
                if (paymentServiceResponse.Code == EFTFeedback.ThreeDSecureEnrolled.Id)
                {
                    GenesisWrapper.SavePaReq(paymentServiceResponse.TransactionId, paymentServiceResponse.PaymentAuthenticationRequestMessage, paymentServiceResponse.Code, paymentServiceResponse.ServiceProviderReference);
                    TransactionService.UpdateTransactionState(paymentServiceResponse, EFTCardTransactionState.EnrolledIn3DSecureAuthenticationRequired.Id);
                    TransactionAuditor.RecordTransactionStep(transactionId, paymentServiceResponse.Code, paymentServiceResponse.Description);
                }
                else if (paymentServiceResponse.Code == EFTFeedback.NotThreeDSecureEnrolled.Id)
                {
                    TransactionService.UpdateTransactionState(paymentServiceResponse, EFTCardTransactionState.NotEnrolledIn3DSecureCompletePayment.Id);
                    TransactionAuditor.RecordTransactionStep(transactionId, paymentServiceResponse.Code, paymentServiceResponse.Description);
                    var authResponse = PaymentService.AuthorisePayment(paymentServiceResponse.ServiceProviderReference, null, request.TradingAccountCode, transactionId);
                    var authTransactionProcessorResponse = AuthorisedTransactionProcessor.Process(request, authResponse);

                    return new MakePaymentResponse
                    {
                        Code = authTransactionProcessorResponse.Code,
                        Description = authTransactionProcessorResponse.Description,
                        ServiceProviderReference = authTransactionProcessorResponse.ServiceProviderReference,
                        TransactionId = transactionId
                    };
                }
                else
                {
                    TransactionService.UpdateTransactionState(paymentServiceResponse, EFTCardTransactionState.Rejected.Id);
                    TransactionAuditor.RecordFailedTransaction(transactionId, paymentServiceResponse.Code, paymentServiceResponse.Description);
                }
            }
            else
            {
                var response = PaymentService.MakeMotoPayment(request, request.TradingAccountCode, transaction.Id, transaction.FundingChannelId);
                var authTransactionProcessorResponse = AuthorisedTransactionProcessor.Process(request, response);
                return new MakePaymentResponse
                {
                    Code = authTransactionProcessorResponse.Code,
                    Description = authTransactionProcessorResponse.Description,
                    ServiceProviderReference = authTransactionProcessorResponse.ServiceProviderReference,
                    TransactionId = transactionId
                };
            }

            return new MakePaymentResponse();
        }
    }    
}
