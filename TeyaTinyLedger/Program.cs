using System.Transactions;
using TeyaTinyLedger.Domain;
using TeyaTinyLedger.Repository;
using TeyaTinyLedger.Repository.Interfaces;
using TeyaTinyLedger.Service;
using TeyaTinyLedger.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBalanceRepository, BalanceRepository>();
builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IBalanceService,BalanceService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();

var transactionRepository = app.Services.GetRequiredService<ITransactionRepository>();
var balanceRepository = app.Services.GetRequiredService<IBalanceRepository>();

var testTransactions = new List<LedgerTransaction>
{
    new LedgerTransaction { TransactionId = 1, UserId = 1, Amount = 100, TransactionType = TransactionType.Deposit, Timestamp = DateTime.UtcNow.AddDays(-2) },
    new LedgerTransaction { TransactionId = 2, UserId = 1, Amount = 50, TransactionType = TransactionType.Withdrawal, Timestamp = DateTime.UtcNow.AddDays(-1) },
    new LedgerTransaction { TransactionId = 3, UserId = 1, Amount = 200, TransactionType = TransactionType.Deposit, Timestamp = DateTime.UtcNow },
    new LedgerTransaction { TransactionId = 4, UserId = 2, Amount = 200, TransactionType = TransactionType.Deposit, Timestamp = DateTime.UtcNow.AddDays(-1) },
    new LedgerTransaction { TransactionId = 5, UserId = 2, Amount = 200, TransactionType = TransactionType.Withdrawal, Timestamp = DateTime.UtcNow }
};


foreach (var transaction in testTransactions)
{
    transactionRepository.AddTransaction(transaction);
    balanceRepository.UpdateBalance(transaction.UserId, transaction.Amount, transaction.TransactionType);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
