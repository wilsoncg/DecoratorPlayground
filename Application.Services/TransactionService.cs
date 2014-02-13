using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using GenesisWrapping.Wrapper;

namespace Application.Services
{
    public interface ITransactionService
    {
        int GenerateNewTransactionId();
        void UpdateTransactionState(MakePaymentResponse paymentServiceResponse, int transactionStateId);
        void UpdateTransactionState(AuthResponse authResponse, int transactionStateId);
    }

    public class TransactionService : ITransactionService
    {
        public IGenesisWrapper GenesisWrapper { get; set; }

        public int GenerateNewTransactionId()
        {
            var num = new byte[3];
            RandomNumberGenerator.Create().GetBytes(num);
            return num[0] + num[1] + num[2] + num[3];
        }

        public void UpdateTransactionState(MakePaymentResponse paymentServiceResponse, int transactionStateId)
        {
            var t = GenesisWrapper.GetEftCardTransaction(paymentServiceResponse.TransactionId);
            var updatedTransaction = new EFTCardTransaction(t.CardTransactionId,
                t.CardId,
                t.LedgerId,
                t.DebitAmount,
                t.CreditAmount,
                t.ChargePercent,
                t.UserId,
                transactionStateId,
                t.TimeStarted,
                t.ParentTransactionId,
                t.CardTransactionTypeId,
                t.DebitCurrencyId,
                t.CreditCurrencyId,
                t.FxRate,
                t.SuspenseLedgerTransactionId,
                t.CardMovementLedgerTransactionId,
                t.CardChargeLedgerTransactionID,
                t.FxLedgerTransactionId,
                t.AuthCode,
                t.MerchantLedgerId,
                t.ReferralTelephoneNumber,
                t.PaymentGatewayId,
                t.ServiceProviderReference,
                t.FundingChannelId);
            GenesisWrapper.UpdateEFTCardTransaction(updatedTransaction);
        }

        public void UpdateTransactionState(AuthResponse authResponse, int transactionStateId)
        {
            var t = GenesisWrapper.GetEftCardTransaction(authResponse.TransactionId);
            var updatedTransaction = new EFTCardTransaction(t.CardTransactionId,
                t.CardId,
                t.LedgerId,
                t.DebitAmount,
                t.CreditAmount,
                t.ChargePercent,
                t.UserId,
                transactionStateId,
                t.TimeStarted,
                t.ParentTransactionId,
                t.CardTransactionTypeId,
                t.DebitCurrencyId,
                t.CreditCurrencyId,
                t.FxRate,
                t.SuspenseLedgerTransactionId,
                t.CardMovementLedgerTransactionId,
                t.CardChargeLedgerTransactionID,
                t.FxLedgerTransactionId,
                t.AuthCode,
                t.MerchantLedgerId,
                t.ReferralTelephoneNumber,
                t.PaymentGatewayId,
                t.ServiceProviderReference,
                t.FundingChannelId);
            GenesisWrapper.UpdateEFTCardTransaction(updatedTransaction);
        }
    }
}
