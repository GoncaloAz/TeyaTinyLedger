using TeyaTinyLedger.Domain;

namespace TeyaTinyLedger.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public void AddTransaction(LedgerTransaction transaction);
        public List<LedgerTransaction> GetTransactions(int userId);
    }
}
