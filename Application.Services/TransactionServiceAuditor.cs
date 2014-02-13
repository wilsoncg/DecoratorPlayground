using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using GenesisWrapping;

namespace Application.Services
{
    public class TransactionServiceAuditor : ITransactionService
    {
        public Mapper Mapper { get; set; }
        private readonly ITransactionService _transactionService;
        private readonly ITransactionAuditor _transactionAuditor;

        public TransactionServiceAuditor(ITransactionService transactionService, ITransactionAuditor transactionAuditor)
        {
            _transactionService = transactionService;
            _transactionAuditor = transactionAuditor;
        }

        public int GenerateNewTransactionId()
        {
            var tid = _transactionService.GenerateNewTransactionId();
            _transactionAuditor.RecordTransactionStepStart(tid, ""); //TODO: step name?
            return tid;
        }

        public void UpdateTransactionState(MakePaymentResponse paymentServiceResponse, int transactionStateId)
        {
            _transactionService.UpdateTransactionState(paymentServiceResponse, transactionStateId);
            _transactionAuditor.RecordTransactionStep(paymentServiceResponse.TransactionId, paymentServiceResponse.Code, paymentServiceResponse.Description);
        }

        public void UpdateTransactionState(AuthResponse authResponse, int transactionStateId)
        {
            _transactionService.UpdateTransactionState(authResponse, transactionStateId);
            _transactionAuditor.RecordTransactionStep(authResponse.TransactionId, authResponse.Code, authResponse.Description);
        }
    }

    public class Mapper
    {
        public int MappedEFTFeedbackFromPaymentServiceResponseCode(MakePaymentResponse paymentServiceResponse)
        {
            return 0;
        }
    }
}
