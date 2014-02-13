using System;

namespace GenesisWrapping.Wrapper
{
    public class EFTCardTransactionAudit
    {
        public int AuditId { get; set; }
        public int TransactionId { get; set; }
        public string Action { get; set; }
        public string ReturnCode { get; set; }
        public string Description { get; set; }
        public DateTime WhenDone { get; set; }
        public int ModifiedBy { get; set; }

        public EFTCardTransactionAudit(int auditId, int transactionId, string action, string returnCode, string description, DateTime whenDone, int modifiedBy)
        {
            AuditId = auditId;
            TransactionId = transactionId;
            Action = action;
            ReturnCode = returnCode;
            Description = description;
            WhenDone = whenDone;
            ModifiedBy = modifiedBy;
        }
    }
}
