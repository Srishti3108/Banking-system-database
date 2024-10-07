using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.Model
{
    internal class CurrentAccount : Account
    {
        public double OverdraftLimit { get; set; } = 500;
        public CurrentAccount(int accountNumber, string customerName, decimal initialBalance) { }
        public CurrentAccount(double balance) : base(123, "Current", balance){ }
        public override void Withdraw(double amount)
        {
            if (AccountBalance + OverdraftLimit >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Withdrawn {amount}. Current Balance: {AccountBalance}");
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded.");
            }
        }
        public override double CalculateInterest()
        {
            return 0;
        }
    }
}

