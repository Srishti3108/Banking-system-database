using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.Model
{
    internal class Customer
    {
        private int CustomerID { get; set; }
        private string? FirstName { get; set; }
        private string? LastName { get; set; }
        private string? EmailAddress { get; set; }
        private string? PhoneNumber { get; set; }
        private string? Address { get; set; }

        
        public Customer() { }
        public Customer(int id, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            PhoneNumber = phone;
            Address = address;
        }
        public void PrintCustomerDetails()
        {
            Console.WriteLine($"Customer ID: {CustomerID}, Name: {FirstName} {LastName}, Email: {EmailAddress}, Phone: {PhoneNumber}, Address: {Address}");
        }
    }
}
    
