using Contracts;

namespace Application.Services
{
    public class AuthResponse : Response
    {
        public int Code { get; set; }
        public int TransactionId { get; set; }
        public int Recommendation { get; set; }
        public string Description { get; set; }
        public string ServiceProviderReference { get; set; }
    }
}