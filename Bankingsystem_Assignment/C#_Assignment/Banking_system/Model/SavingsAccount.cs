using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banking_system.Model
{
    internal class SavingsAccount : Account
    {
        public double InterestRate { get; set; } = 4.5;

        public SavingsAccount() { } 
        public override double CalculateInterest()
        {
            return AccountBalance * (InterestRate / 100);
        }
    }
}

