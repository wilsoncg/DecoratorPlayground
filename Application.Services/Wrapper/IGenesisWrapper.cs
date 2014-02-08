namespace Application.Services.Wrapper
{
    public interface IGenesisWrapper
    {
        void AddTransactionAudit(EFTCardTransactionAudit auditEntry);
        EFTCardTransaction GetEftCardTransaction(int transactionId);
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
    }

    public class EFTCardTransaction
    {
        public int FundingChannelId { get; set; }
        public int Id { get; set; }
    }
}
