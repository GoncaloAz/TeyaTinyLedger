# Teya Tiny Ledger

This document provides an overview of how to run the application, examples of API calls, and the assumptions made during development.

## How to Run the App

To run the application, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/GoncaloAz/TeyaTinyLedger
   ```

2. **Open Project Folder in Terminal**
   ```bash
   cd TeyaTinyLedger/TeyaTinyLedger
   ```

3. **Run with dotnet**
   ```bash
   dotnet restor
   dotnet run
   ```

4. **Run With Docker**
   ```bash
   docker build -t teya-tiny-ledger .
   docker run -p 5000:5000 teya-tiny-ledger
   ```

## Testing the API

Some test data is already preloaded into the application with users id 1 and 2

**The following endpoints are available:**

**Get User Blanace by User Id:**
GET http://localhost:5000/api/Balance/{userId}/balance -> Obtains the specified user Id balance.

**Response:**
```json
{
    "currentBalance": 250
}
```

**Add Transaction**
POST http://localhost:5000/api/Transaction

**Request Body (Note: transaction type 0 for Deposit 1 for Withdraw**
```json
{
  "userId": 1,
  "amount": 1000,
  "transactionType": 0,
  "timestamp": "2025-03-21T13:04:25.106Z"
}
```
**Response 200 OK**
```json
{
"message": "Transaction recorded successfully"
}
```
**Response 400 Bad Request**
```json
{
"message": "Insufficient balance"
}
```
**Response 404 Not Found**
```json
{
"message": "User does not exist"
}
```

**Get all transactions By User Id**
GET http://localhost:5000/api/Transaction/{userId}/transactions

**Response** 
```json
[
	{
	"amount": 100,
	"transactionType": 0,
	"timestamp": "2025-03-19T13:26:37.3675324Z"
	},
	{
	"amount": 50,
	"transactionType": 1,
	"timestamp": "2025-03-20T13:26:37.367581Z"
	},
	{
	"amount": 200,
	"transactionType": 0,
	"timestamp": "2025-03-21T13:26:37.3675815Z"
	}
]
```



## Assumptions made during development

1. API has some user logic meaning multiple balances and transactions exists depending on the UserId. No authentication made just simple Id to identify users.

2. Transactions are either Deposit or Withdraw and in code are represented by 0 and 1 respectively

3. When creating a trasaction Balance is checked to verify that the balance will not go into the negatives.

4. Due to time constraints not all validations were made to see if user existed.