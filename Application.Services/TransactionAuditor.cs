using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Wrapper;

namespace Application.Services
{
    public class TransactionAuditor
    {
        public IGenesisWrapper GenesisWrapper { get; set; }

        public DateTimeFactory DateTimeFactory { get; set; }

        public void RecordTransactionStepStart(int transactionId, string transactionStepName)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", string.Format("Start {0}", transactionStepName), DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartSetupTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start Setup transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartQueryTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start Query transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartPaymentFromHpsTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start PaymentFromHps transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartPaymentWithCardTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start PaymentWithCard transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void Start3DAuthTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start 3DAuth by client", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartAuth3DAuthTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start checking 3DAuth result", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartFulfillTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start Fulfill transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void StartCancelTransaction(int transactionId)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "START", "0", "Start Cancel transaction", DateTimeFactory.DateTimeNow(), 5002));
        }

        public void RecordFailedTransaction(int transactionId, int responseCode, string responseDescription)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "FAILED", responseCode.ToString(), responseDescription, DateTimeFactory.DateTimeNow(), 5002));
        }

        public void RecordTransactionStepResult(int transactionId, int responseCode, string responseDescription)
        {
            GenesisWrapper.AddTransactionAudit(new EFTCardTransactionAudit(0, transactionId, "END", responseCode.ToString(), responseDescription, DateTimeFactory.DateTimeNow(), 5002));
        }
    }
}
