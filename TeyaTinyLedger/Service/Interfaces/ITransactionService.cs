﻿using TeyaTinyLedger.DTOs;

namespace TeyaTinyLedger.Service.Interfaces
{
    public interface ITransactionService
    {
        public string AddTransaction(LedgerTransactionCreationDto transactionDto);

        public string AddTransferTransaction(LedgerTransactionCreationDto transactionDto);
        public List<LedgerTransactionResponseDto> GetTransactions(int userId);
    }
}
