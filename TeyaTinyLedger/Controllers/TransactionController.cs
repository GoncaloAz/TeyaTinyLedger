using Microsoft.AspNetCore.Mvc;
using TeyaTinyLedger.DTOs;
using TeyaTinyLedger.Service;
using TeyaTinyLedger.Service.Interfaces;

namespace TeyaTinyLedger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult RecordTransaction([FromBody] LedgerTransactionCreationDto transactionDto)
        {
            if (transactionDto.Timestamp == default)
            {
                transactionDto.Timestamp = DateTime.UtcNow;
            }

            var result = _transactionService.AddTransaction(transactionDto);

            if (result == "User does not exist")
            {
                return NotFound(new { message = result });
            }
            else if (result == "Insufficient balance")
            {
                return BadRequest(new { message = result });
            }

            return Ok(new { message = result });
        }

        [HttpGet("{userId}/transactions")]
        public IActionResult GetTransactions(int userId)
        {
            var transactions = _transactionService.GetTransactions(userId);
            return Ok(transactions);
        }
    }
}
