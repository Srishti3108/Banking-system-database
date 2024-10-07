using Banking_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banking_system.Main
{
    internal class MainModule
    {
        public class Bank
        {
            public BankAccount? account;
            //=======TASK9=======
            // Method to display the menu and perform operations
            public void StartBanking()
            {
                Console.WriteLine("Welcome to the Bank!");
                Console.WriteLine("Choose account type to create:");
                Console.WriteLine("1. Savings Account");
                Console.WriteLine("2. Current Account");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter Account Number: ");
                int accountNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Enter Initial Balance: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        account = new SavingsAccount(accountNumber, customerName, initialBalance);
                        break;
                    case 2:
                        account = new CurrentAccount(accountNumber, customerName, initialBalance);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        return;
                }
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nChoose an operation:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Calculate Interest");
                    Console.WriteLine("4. Display Account Information");
                    Console.WriteLine("5. Exit");
                    int operation = int.Parse(Console.ReadLine());

                    switch (operation)
                    {
                        case 1:
                            Console.Write("Enter amount to deposit: ");
                            float depositAmount = float.Parse(Console.ReadLine());
                            account.Deposit(depositAmount);
                            break;
                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            float withdrawAmount = float.Parse(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            break;
                        case 3:
                            account.CalculateInterest();
                            break;
                        case 4:
                            account.DisplayAccountInfo();
                            break;
                        case 5:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            #region  Task 1
            /*  Console.WriteLine("Write your customer credit score:");
              int credit_score=int.Parse(Console.ReadLine());
              Console.WriteLine("Write your annual income:");
              long annual_income=int.Parse(Console.ReadLine());
              if(credit_score>700 && annual_income <= 50000)
              {
                  Console.WriteLine("You are eligible to take loan");
              }
              else if (credit_score<=700 && annual_income>50000 )
              {
                  Console.WriteLine("You are not eligible to take loan due to low credit score and more income");
              }
              else if (credit_score <= 700)
              {
                  Console.WriteLine("you are not eligible due to low credit score");
              }
               else
              {
                  Console.WriteLine("You are not eligible due to more income ");
              }
          }*/
            #endregion
            #region Task 2
            /*Console.WriteLine("Enter the current balance:");
            double current_balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("/n ATM menu");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("Choose an option(1,2 or 3)");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine($"Your current balance is ::{current_balance}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the amount to withdrawal:");
                double withdrawal_amount = Convert.ToDouble(Console.ReadLine());
                if (withdrawal_amount % 100 == 0 || withdrawal_amount % 500 == 0)
                {
                    if (withdrawal_amount <= current_balance)
                    {
                        current_balance = current_balance - withdrawal_amount;
                        Console.WriteLine($"The current balance you have::{current_balance}");
                    }
                    else
                    {
                        Console.WriteLine("You have insufficient current balance");
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be multiple of 100 or 500 ");
                }
            }
            else if (choice == 3) {
                Console.WriteLine("Enter the amount to deposit:");
                double deposit_amount = Convert.ToDouble(Console.ReadLine());
                current_balance = current_balance + deposit_amount;
                Console.WriteLine($"Your current balance is ::{current_balance}");

            }
            else
            {
                Console.WriteLine("Invalid option!Please choose a valid transaction");
            }*/
            #endregion
            #region Task 3
            /*Console.WriteLine("Enter the number of customer:");
            int customer=int.Parse(Console.ReadLine());
            for (int i = 0; i < customer; i++)
            {
                Console.WriteLine($"customer{i}:");
                Console.WriteLine("Enter the balance:");
                double initial_balance=Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the annual interest rate:");
                double annual_interestrate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the number of years:");
                int years=int.Parse(Console.ReadLine());
                double future_balance = initial_balance * Math.Pow(1 + annual_interestrate / 100,years);
                Console.WriteLine($"The future balance of customer is :{future_balance}");
            }*/
            #endregion
            #region Task 4
            /*Console.WriteLine("Enter the number of account:");
            int numberof_account=int.Parse(Console.ReadLine());
            int[] account_number = new int[numberof_account];
            double[] account_balance = new double[numberof_account];
            for (int i = 0; i < numberof_account; i++)
            {
                Console.WriteLine($"Enter the account number for customer{i + 1}");
                account_number[i] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Enter the balance for account{account_number[i]}");
                account_balance[i] = double.Parse(Console.ReadLine());
            }
            bool valid_account = false;
            while (!valid_account)
            {
                Console.WriteLine("Enter account number to check balance");
                int entered_accountnumber;
                if (int.TryParse(Console.ReadLine(), out entered_accountnumber))
                {
                    for (int i = 0; i < numberof_account; i++)
                    {
                        if (account_number[i] == entered_accountnumber)
                        {
                            valid_account = true;
                            Console.WriteLine($"Account number{entered_accountnumber} has a balance of :{account_balance[i]:c}");
                            break;
                        }
                    }
                    if (!valid_account)
                    {
                        Console.WriteLine("Invalid account number--please try again");

                    }
                }
                else
                {
                    Console.WriteLine("please enter valid account number. ");
                }
            }*/
            #endregion
            #region Task 5
            /*Console.WriteLine("Enter the password for your account:");
            string password = Console.ReadLine();
            if (password.Length < 8) {
                Console.WriteLine("Password must be at least 8 characters");
                return;
            }
            bool contains_upperclass = false;
            bool contains_digit = false;
            foreach(char c in password)
            {
                if (char.IsUpper(c))
                {
                    contains_upperclass = true;
                }
                if (char.IsDigit(c))
                {
                    contains_digit = true;
                }
            }
            if (!contains_upperclass)
            {
                Console.WriteLine("Password must contains at least one upper class");
                return;
            }
            Console.WriteLine("Password is valid!");*/
            #endregion
            #region Task 6
            /* List<string> transactions = new List<string>();
             bool continuous = true;
             while (continuous)
             {
                 Console.WriteLine("------Bank Transactions-----");
                 Console.WriteLine("1. Deposit");
                 Console.WriteLine("2. Withdrawal");
                 Console.WriteLine("3. Exit and display transaction history");
                 Console.WriteLine("choose your option from (1/2/3)");
                 string choice = (Console.ReadLine());
                 switch (choice)
                 {
                     case "1":
                         Console.WriteLine("Enter the deposit amount:");
                         decimal deposit_amount = decimal.Parse(Console.ReadLine());
                         if (deposit_amount > 0)
                         {
                             transactions.Add($"Deposit: {deposit_amount}");
                             Console.WriteLine($"you have deposited: {deposit_amount}");
                         }
                         else
                         {
                             Console.WriteLine("Invalid amount.Enter valid input");
                         }
                         break;
                     case "2":
                         Console.WriteLine("Enter the withdrawal amount:");
                         decimal withdrawal_amount = decimal.Parse(Console.ReadLine());
                         if (withdrawal_amount > 0)
                         {
                             transactions.Add($"withdraw: {withdrawal_amount}");
                             Console.WriteLine($"withdrew amount: {withdrawal_amount}");
                         }
                         else
                         {
                             Console.WriteLine("Invalid amount.Please enter valid amount");
                         }
                         break;
                     case "3":
                         continuous = false;
                         Console.WriteLine("Transaction history");
                         if (transactions.Count == 0)
                         {
                             Console.WriteLine("No transaction made.");
                         }
                         else
                         {
                             for (int i = 0; i < transactions.Count; i++)
                             {
                                 Console.WriteLine($"{i + 1}.{transactions[i]}");
                             }
                         }
                         break;

                     default:
                         Console.WriteLine("Invalid choice.Please made correct choice");
                         break;
                 }
             }*/
            #endregion

            #region TASK 7 & TASK 8
            /* Bank bank = new Bank(1234567890, "Savings", 1000.0);
             Console.WriteLine("\n ---Performing deposit of 500...");
             bank.Deposit(500);  
             Console.WriteLine("\n ----Performing withdrawal of 300...");
             bank.Withdraw(300);

             Console.WriteLine("\n-----Calculating interest for savings account...");
             bank.CalculateInterest();  */
            #endregion
            Bank bank = new Bank();
            bank.StartBanking();
        }
    }
}
    


