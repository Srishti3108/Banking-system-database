using Banking_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.Model
{
    public abstract class BankAccount
    {
        private int AccountNumber { get; set; }
        private string CustomerName { get; set; }
        internal decimal Balance { get;  set; }
        public BankAccount(int accountNumber, string customerName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = initialBalance;
        }
        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void CalculateInterest();
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Customer Name: {CustomerName}, Balance: {Balance:C}");
        }

        public static implicit operator BankAccount(CurrentAccount v)
        {
            throw new NotImplementedException();
        }
    }

}
// Inheriting savings_account from bankaccount ** TASK 9** 
public class SavingsAccount : BankAccount
{
    private const decimal InterestRate = 0.03m;
    public SavingsAccount(int accountNumber, string customerName, decimal initialBalance)
        : base(accountNumber, customerName, initialBalance)
    {
    }

    
    public override void Deposit(float amount)
    {
        Balance = Balance + (decimal)amount;
        Console.WriteLine($"Deposited {amount:C} into Savings Account. New Balance: {Balance:C}");
    }
    public override void Withdraw(float amount)
    {
        if (Balance >= (decimal)amount)
        {
            Balance = Balance - (decimal)amount;
            Console.WriteLine($"Withdrew {amount:C} from Savings Account. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds in Savings Account.");
        }
    }
    public override void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance = Balance + interest;
        Console.WriteLine($"Interest added to Savings Account. New Balance: {Balance:C}");
    }

// Inheriting current_account from bankaccount 
    public class CurrentAccount : BankAccount
    {
        private const decimal OverdraftLimit = 500m; 

        public CurrentAccount(int accountNumber, string customerName, decimal initialBalance)
            : base(accountNumber, customerName, initialBalance)
        {
        }
        public override void Deposit(float amount)
        {
            Balance = Balance + (decimal)amount;
            Console.WriteLine($"Deposited {amount:C} into Current Account. New Balance: {Balance:C}");
        }
        public override void Withdraw(float amount)
        {
            if (Balance - (decimal)amount >= -OverdraftLimit)
            {
                Balance = Balance - (decimal)amount;
                Console.WriteLine($"Withdrew {amount:C} from Current Account. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit in Current Account.");
            }
        }
        public override void CalculateInterest()
        {
            Console.WriteLine("No interest calculation for Current Account.");
        }
    }

}


