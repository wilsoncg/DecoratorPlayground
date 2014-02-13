namespace Contracts
{
    public class MakePaymentRequest : Request
    {
        public int AccountId { get; set; }
        public string TradingAccountCode { get; set; }
        public string ServiceProviderReference { get; set; }
    }
}
