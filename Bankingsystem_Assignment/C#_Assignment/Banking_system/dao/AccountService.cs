using Banking_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal class AccountService : IAccountService 
    {
        
            private readonly Account account;

            public AccountService(Account account)
            {
                this.account = account;
            }

            public void Deposit(double amount)
            {
                account.Deposit(amount);
            }

            public void Withdraw(double amount)
            {
                //try
                //{
                    account.Withdraw(amount);
                }
               // catch (InsufficientBalanceException e)
               // {
                  //  Console.WriteLine(e.Message);
               // }
           // }

            public void CalculateInterest()
            {
                account.CalculateInterest();
            }
        }
    }



