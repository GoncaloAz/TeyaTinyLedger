using TeyaTinyLedger.Domain;

namespace TeyaTinyLedger.DTOs
{
    public class LedgerTransactionResponseDto
    {
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
