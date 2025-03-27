using TeyaTinyLedger.Domain;

namespace TeyaTinyLedger.DTOs
{
    public class LedgerTransactionCreationDto
    {
        public int UserIdFrom { get; set; }

        public int UserIdTo { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
