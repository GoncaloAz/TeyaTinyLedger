using TeyaTinyLedger.DTOs;
using TeyaTinyLedger.Repository;
using TeyaTinyLedger.Repository.Interfaces;
using TeyaTinyLedger.Service.Interfaces;

namespace TeyaTinyLedger.Service
{
    public class BalanceService : IBalanceService
    {

        private readonly IBalanceRepository _balanceRepository;

        public BalanceService(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public BalanceResponseDto GetBalance(int userId)
        {
            var balance = _balanceRepository.GetBalance(userId);
            return new BalanceResponseDto { CurrentBalance = balance };
        }
    }
}
