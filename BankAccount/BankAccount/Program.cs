using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {

        static void Main(string[] args)
        {
            var account = new Account("Simion Marius");
            account.MakeDeposit(1000M, "Deposit creation"); 
            account.Withdrawal(200M,"Rent payment");
            account.MakeDeposit(1500M, "Salary");
            account.Withdrawal(2000M,"Products bought");     // should give an Insuficient funds error.
            account.AccountStatement();

            account.CloseAccount();

            account.MakeDeposit(1500M, "Closing test");       // should give an Account closed error.
            account.AccountStatement();




            var account1 = new Account("Simion Elena");
            account1.AccountStatement();




        }



    }
}

