using System;

namespace GenesisWrapping.Wrapper
{
    public interface IGenesisWrapper
    {
        void AddTransactionAudit(EFTCardTransactionAudit auditEntry);
        EFTCardTransaction GetEftCardTransaction(int transactionId);
        void UpdateEFTCardTransaction(EFTCardTransaction updatedTransaction);
        void SavePaReq(int transactionId, string paymentAuthenticationRequestMessage, int code, string serviceProviderReference);
    }

    public class GenesisWrapper : IGenesisWrapper
    {
        public void AddTransactionAudit(EFTCardTransactionAudit auditEntry)
        {
        }

        public EFTCardTransaction GetEftCardTransaction(int transactionId)
        {
            return new EFTCardTransaction();
        }

        public void UpdateEFTCardTransaction(EFTCardTransaction updatedTransaction)
        {
        }

        public void SavePaReq(int transactionId, string paymentAuthenticationRequestMessage, int code, string serviceProviderReference)
        {
        }
    }

    public class EFTCardTransaction
    {
        public EFTCardTransaction(int cardTransactionId, int cardId, int ledgerId, decimal debitAmount, decimal creditAmount, decimal chargePercent, int userId, int transactionStateId, DateTime timeStarted, int parentTransactionId, int cardTransactionTypeId, int debitCurrencyId, int creditCurrencyId, decimal fxRate, int suspenseLedgerTransactionId, int cardMovementLedgerTransactionId, int cardChargeLedgerTransactionId, int fxLedgerTransactionId, string authCode, int merchantLedgerId, string referralTelephoneNumber, int paymentGatewayId, string serviceProviderReference, int fundingChannelId) : base()
        {
        }

        public EFTCardTransaction()
        {
        }

        public int FundingChannelId { get; set; }
        public int Id { get; set; }
        public int CardTransactionId { get; set; }
        public int CardId { get; set; }
        public int LedgerId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal ChargePercent { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStarted { get; set; }
        public int ParentTransactionId { get; set; }
        public int CardTransactionTypeId { get; set; }
        public int DebitCurrencyId { get; set; }
        public int CreditCurrencyId { get; set; }
        public decimal FxRate { get; set; }
        public int SuspenseLedgerTransactionId { get; set; }
        public int CardMovementLedgerTransactionId { get; set; }
        public int CardChargeLedgerTransactionID { get; set; }
        public int FxLedgerTransactionId { get; set; }
        public string AuthCode { get; set; }
        public int MerchantLedgerId { get; set; }
        public string ReferralTelephoneNumber { get; set; }
        public int PaymentGatewayId { get; set; }
        public string ServiceProviderReference { get; set; }
    }
}
