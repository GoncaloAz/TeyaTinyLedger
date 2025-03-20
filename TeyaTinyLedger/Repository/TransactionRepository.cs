using System.Transactions;
using TeyaTinyLedger.Domain;
using TeyaTinyLedger.Repository.Interfaces;

namespace TeyaTinyLedger.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Dictionary<int, List<LedgerTransaction>> _userTransactions = new Dictionary<int, List<LedgerTransaction>>();

        public void AddTransaction(LedgerTransaction transaction)
        {
            if (!_userTransactions.ContainsKey(transaction.UserId))
            {
                _userTransactions[transaction.UserId] = new List<LedgerTransaction>();
            }

            _userTransactions[transaction.UserId].Add(transaction);
        }

        public List<LedgerTransaction> GetTransactions(int userId)
        {
            return _userTransactions.ContainsKey(userId) ? _userTransactions[userId] : new List<LedgerTransaction>();
        }
    }
}
