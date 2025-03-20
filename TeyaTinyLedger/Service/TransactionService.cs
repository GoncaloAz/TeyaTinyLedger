using System.Transactions;
using TeyaTinyLedger.Domain;
using TeyaTinyLedger.DTOs;
using TeyaTinyLedger.Repository;
using TeyaTinyLedger.Repository.Interfaces;
using TeyaTinyLedger.Service.Interfaces;

namespace TeyaTinyLedger.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBalanceRepository _balanceRepository;

        public TransactionService(ITransactionRepository transactionRepository, IBalanceRepository balanceRepository)
        {
            _transactionRepository = transactionRepository;
            _balanceRepository = balanceRepository;
        }

        public string AddTransaction(LedgerTransactionCreationDto transactionDto)
        {
            if (!_transactionRepository.GetTransactions(transactionDto.UserId).Any())
            {
                return "User does not exist";
            }

            var currentBalance = _balanceRepository.GetBalance(transactionDto.UserId);
            if (transactionDto.TransactionType == TransactionType.Withdrawal)
            {
                var newBalance = currentBalance - transactionDto.Amount;
                if (newBalance < 0)
                {
                    return "Insufficient balance";
                }
            }

            Random rnd = new Random();
            int num = rnd.Next(1, 10000);
            var transaction = new LedgerTransaction
            {
                TransactionId = num,
                UserId = transactionDto.UserId,
                Amount = transactionDto.Amount,
                TransactionType = transactionDto.TransactionType,
                Timestamp = transactionDto.Timestamp
            };

            _transactionRepository.AddTransaction(transaction);
            _balanceRepository.UpdateBalance(transaction.UserId, transaction.Amount, transaction.TransactionType);
            return "Transaction recorded successfully";
        }

        public List<LedgerTransactionResponseDto> GetTransactions(int userId)
        {
            var transactions = _transactionRepository.GetTransactions(userId);
            return transactions.Select(t => new LedgerTransactionResponseDto
            {
                Amount = t.Amount,
                TransactionType = t.TransactionType,
                Timestamp = t.Timestamp
            }).ToList();
        }
    }
}
