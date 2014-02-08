namespace Contracts
{
    public class MakePaymentResponse : Response
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string ServiceProviderReference { get; set; }
        public int TransactionId { get; set; }
    }
}
