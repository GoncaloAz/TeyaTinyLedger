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
            if (!_userTransactions.ContainsKey(transaction.UserIdFrom))
            {
                _userTransactions[transaction.UserIdFrom] = new List<LedgerTransaction>();
            }

            _userTransactions[transaction.UserIdFrom].Add(transaction);
        }

        public void AddTransactionTransfer(LedgerTransaction transactionWithdraw, LedgerTransaction transactionDeposit)
        {
            if (!_userTransactions.ContainsKey(transactionWithdraw.UserIdFrom))
            {
                _userTransactions[transactionWithdraw.UserIdFrom] = new List<LedgerTransaction>();
            }

            if (!_userTransactions.ContainsKey(transactionDeposit.UserIdTo))
            {
                _userTransactions[transactionDeposit.UserIdTo] = new List<LedgerTransaction>();
            }

            _userTransactions[transactionWithdraw.UserIdFrom].Add(transactionWithdraw);
            _userTransactions[transactionDeposit.UserIdTo].Add(transactionDeposit);
        }

        public List<LedgerTransaction> GetTransactions(int userId)
        {
            return _userTransactions.ContainsKey(userId) ? _userTransactions[userId] : new List<LedgerTransaction>();
        }
    }
}
