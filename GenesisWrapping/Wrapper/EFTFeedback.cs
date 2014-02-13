namespace GenesisWrapping.Wrapper
{
    public class EFTFeedback
    {
        public static State ThreeDSecureEnrolled { get { return new State(1); } }
        public static State NotThreeDSecureEnrolled { get { return new State(2); } }
        public static State Success { get {  return new State(3);} }
    }
}
