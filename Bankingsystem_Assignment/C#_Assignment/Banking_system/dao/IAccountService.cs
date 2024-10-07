using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal interface IAccountService
    {
            void Deposit(double amount);
            void Withdraw(double amount);
            void CalculateInterest();
        }
    }


