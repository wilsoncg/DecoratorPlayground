namespace GenesisWrapping.Wrapper
{
    public class EFTCardTransactionState
    {
        public static State EnrolledIn3DSecureAuthenticationRequired { get { return new State(162); } }
        public static State NotEnrolledIn3DSecureCompletePayment { get { return new State(163);} }
        public static State Authorised { get { return new State(1);} }
        public static State Rejected { get { return new State(2); } }
        public static State Denied { get { return new State(3); } }
        public static State PassedFraudCheckAttemptingFulfill { get { return new State(397); } }
        public static State FailedFraudCheckAttemptingCancellation { get { return new State(398); } }
    }
}
