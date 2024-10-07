using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.Model
{
    internal class Account
    {
        private long AccountNumber { get; set; }
        private string? AccountType { get; set; }
        internal double AccountBalance { get; set; }
        private static long LastAccNo = 1000;

        
        public Account() { }
        
        public Account(long number, string type, double balance)
        {
            AccountNumber = number;
            AccountType = type;
            AccountBalance = balance;
        }

        // Withdraw method for double
        public virtual void Deposit(double amount)
        {
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($"Deposited {amount}. Current Balance: {AccountBalance}");
        }

        
        public virtual void Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Withdrawn {amount}. Current Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
        //  method for int
        public void Deposit(int amount)
        {
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($"Deposited {amount} as int. Current Balance: {AccountBalance}");
        }
        public void Withdraw(int amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Withdrew {amount} as int. Current Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance for int amount.");
            }
        }
        public void Deposit(float amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited {amount} as float. Current Balance: {AccountBalance}");
        }

        // method for float
        public void Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance- amount;
                Console.WriteLine($"Withdrew {amount} as float. Current Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance for float amount.");
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Current Balance: {AccountBalance}");
        }


        public virtual double CalculateInterest()
        {
            return AccountBalance * 0.045;
        }

       
        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {AccountBalance}");
        }
    }
}
     
            
    



