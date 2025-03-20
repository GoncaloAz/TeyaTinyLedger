using TeyaTinyLedger.Domain;
using TeyaTinyLedger.Repository.Interfaces;

namespace TeyaTinyLedger.Repository
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly Dictionary<int, decimal> _userBalances = new Dictionary<int, decimal>();

        public void UpdateBalance(int userId, decimal amount, TransactionType transactionType)
        {
            if (!_userBalances.ContainsKey(userId))
            {
                _userBalances[userId] = 0;
            }

            if (transactionType == TransactionType.Deposit)
            {
                _userBalances[userId] += amount;
            }
            else if (transactionType == TransactionType.Withdrawal)
            {
                _userBalances[userId] -= amount;
            }
        }

        public decimal GetBalance(int userId)
        {
            return _userBalances.ContainsKey(userId) ? _userBalances[userId] : 0;
        }
    }
}

