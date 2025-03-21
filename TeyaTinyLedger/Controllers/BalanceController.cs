using Microsoft.AspNetCore.Mvc;
using TeyaTinyLedger.DTOs;
using TeyaTinyLedger.Service.Interfaces;

namespace TeyaTinyLedger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet("{userId}/balance")]
        public ActionResult<BalanceResponseDto> GetBalance(int userId)
        {
            var balanceDto = _balanceService.GetBalance(userId);
            return Ok(balanceDto);
        }

    }


}
