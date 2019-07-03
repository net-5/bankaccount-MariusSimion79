using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {

        static void Main(string[] args)
        {
            var account = new Account("Simion Marius");
            account.MakeDeposit(1000M, DateTime.Now, "Deposit creation"); 
            account.Withdrawal(200M, DateTime.Now, "Rent payment");
            account.MakeDeposit(1500M, DateTime.Now, "Salary");
            account.Withdrawal(2000M, DateTime.Now, "Products bought");     // should give an Insuficient funds error.
            account.AccountStatement();

            account.CloseAccount();

            account.MakeDeposit(1500M, DateTime.Now, "Closing test");       // should give an Account closed error.
            account.AccountStatement();




            var account1 = new Account("Simion Elena");
            account1.AccountStatement();




        }



    }
}

