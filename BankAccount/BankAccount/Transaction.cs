using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Transaction
    {
       
        public decimal Amount { get; }
        public string Currency { get; }
        public DateTime Date { get; }
        public string Observations { get; }

        public Transaction(decimal amount, string currency, DateTime date, string observations)
        {
           
            this.Amount = amount;
            this.Date = date;
            this.Observations = observations;
        }



    }
}
