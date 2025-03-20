using TeyaTinyLedger.Domain;

namespace TeyaTinyLedger.Repository.Interfaces
{
    public interface IBalanceRepository
    {
        void UpdateBalance(int userId, decimal amount, TransactionType transactionType);
        decimal GetBalance(int accountId);
    }
}
