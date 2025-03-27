namespace TeyaTinyLedger.Domain
{
    public class LedgerTransaction
    {
        public int TransactionId { get; set; }
        public int UserIdFrom { get; set; }
        public int UserIdTo {  get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    
}
