using Banking_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal interface ICustomerServiceProvider
    {
        void get_account_balance( long accountnumber);
        void deposit(long accountnumber, float amount);
        void withdraw(long accountnumber, float amount);
        void transfer(long from_account_number, int to_account_number, float amount); 
        void getAccountDetails(long accountnumber);   
    }
}
