using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_system.dao;


namespace Banking_system.Model
{
    internal class Bank
    {
            private AccountService accountService;

            
            public Bank(long accountNumber, string accountType, double initialBalance)
            {
                Account account = new Account(accountNumber, accountType, initialBalance);
                accountService = new AccountService(account);
            }
            public void Deposit(double amount)
            {
                accountService.Deposit(amount);
            }
            public void Withdraw(double amount)
            {
                accountService.Withdraw(amount);
            }
            public void CalculateInterest()
            {
                accountService.CalculateInterest();
            }
        }
    }


