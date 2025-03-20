using TeyaTinyLedger.DTOs;

namespace TeyaTinyLedger.Service.Interfaces
{
    public interface IBalanceService
    {
        BalanceResponseDto GetBalance(int accountId);
    }
}
