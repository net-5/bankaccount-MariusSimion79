using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankAccount
{
    public enum Status
    {
        Open,
        Closed
    }
    public class Account
    {
        public string AccNumber { get; }
        public string Owner { get; }
        public Status Status { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in transactions)
                {
                    balance += transaction.Amount;

                }
                return balance;
            }

        }
        private static long accNo = 1234567890123456;
        string Currency { get; }
        string OpeningDate { get; }

        public void MakeDeposit(decimal amount, DateTime date, string observation)
        {
            decimal balance = Balance;
            if (Status == Status.Open)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Please enter an positive amount to deposit");
                }
                else
                {
                    balance = +amount;
                }
                var deposit = new Transaction(amount, Currency, date, observation);
                transactions.Add(deposit);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("=======================================================================================");
                Console.WriteLine($"Account {AccNumber} is closed and is not supporting further deposits.");
                Console.WriteLine("=======================================================================================");
            }

        }

        public void Withdrawal(decimal amount, DateTime date, string observation)
        {
            if (Status == Status.Open)
            {
                decimal balance = Balance;
                if (amount <= 0)
                {
                    Console.WriteLine("Please enter an positive amount to withdraw");
                }
                else if (balance - amount < 0)
                {
                    Console.WriteLine("Insufficient funds. Please withdraw a smaller amount.");
                }
                else
                {
                    amount = -amount;
                }
                var withdrawal = new Transaction(amount, Currency, date, observation);
                transactions.Add(withdrawal);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("=======================================================================================");
                Console.WriteLine($"Account {AccNumber} is closed and is not supporting further withdrawals.");
                Console.WriteLine("=======================================================================================");
            }


        }

        public Account(string name)
        {
            string country = "RO";
            int shortOpeningDate = DateTime.Now.Year % 100;
            this.OpeningDate = DateTime.Now.ToShortDateString();
            string shortBankName = "BRMA";
            this.Currency = "RON";
            this.Owner = name;

            this.AccNumber = $"{country}{shortOpeningDate}{shortBankName}{accNo.ToString()}";
            accNo++;
        }

        private readonly List<Transaction> transactions = new List<Transaction>();


        public void AccountStatement()
        {
            Console.WriteLine();
            Console.WriteLine("***************************************************************************************************");
            Console.WriteLine();
            if (Status == Status.Open)
            {
                Console.WriteLine($"Detailed statement for the account no: {AccNumber}\n" +
                          $"Account owned by: {Owner};\n" +
                          $"Account currency: {Currency}\n" +
                          $"Account opening date: {OpeningDate}\n" +
                          $"Available amount: {Balance}{Currency}");

                Console.WriteLine();
                Console.WriteLine("List of transactions to/from this account: ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                int counter = 1;
                foreach (var transaction in transactions)
                {
                    string transactionType;

                    if (transaction.Amount > 0)
                    {
                        transactionType = " Deposit  ";
                    }
                    else
                    {
                        transactionType = "Withdrawal";
                    }


                    Console.WriteLine($" Transaction {counter}: {transaction.Date.ToShortDateString()} / {transactionType} / {transaction.Amount} {transaction.Currency} / {transaction.Observations}.");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------");
                    counter++;

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("=======================================================================================");
                Console.WriteLine($"Account {AccNumber} is closed and is not supporting showing account statements.");
                Console.WriteLine("=======================================================================================");
            }


        }
        public void CloseAccount()
        {
            Status = Status.Closed;
        }
    }
}







