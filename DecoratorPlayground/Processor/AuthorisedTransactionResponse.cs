using Contracts;

namespace FundingService.Processor
{
    public class AuthorisedTransactionResponse : Response
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string ServiceProviderReference { get; set; }
    }
}