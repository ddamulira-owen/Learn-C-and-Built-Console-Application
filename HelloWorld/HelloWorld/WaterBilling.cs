using System;
using System.Collections.Generic;

namespace WaterBillingSystem
{
    // Enum for customer type
    enum CustomerType
    {
        Residential = 1,
        Commercial,
        Industrial
    }

    // Class representing a Customer
    class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public CustomerType Type { get; set; }
        public double WaterConsumption { get; set; } // In cubic meters

        public Customer(int customerId, string name, CustomerType type, double waterConsumption)
        {
            CustomerID = customerId;
            Name = name;
            Type = type;
            WaterConsumption = waterConsumption;
        }

        // Method to display customer details
        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}, Name: {Name}, Type: {Type}, Water Consumption: {WaterConsumption} cubic meters");
        }
    }

    // Static class for utility methods
    static class BillingCalculator
    {
        // Method overloading to calculate bill based on customer type
        public static double CalculateBill(Customer customer)
        {
            return CalculateBill(customer.Type, customer.WaterConsumption);
        }

        public static double CalculateBill(CustomerType type, double waterConsumption)
        {
            double rate = type switch
            {
                CustomerType.Residential => 0.5,
                CustomerType.Commercial => 1.0,
                CustomerType.Industrial => 1.5,
                _ => throw new ArgumentOutOfRangeException()
            };
            return waterConsumption * rate;
        }

        // Method using named arguments
        public static double ApplyDiscount(double billAmount, double discount = 0.0)
        {
            return billAmount - discount;
        }

        // Method with default parameter
        public static double ApplyTax(double billAmount, double taxRate = 0.1)
        {
            return billAmount + (billAmount * taxRate);
        }
    }

    class ProgramRunning
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();

            Console.WriteLine("Welcome to the National Water Billing Payment System");

            while (true)
            {
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Display All Customers");
                Console.WriteLine("3. Calculate Bill for All Customers");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddCustomer(customers);
                        break;

                    case "2":
                        DisplayAllCustomers(customers);
                        break;

                    case "3":
                        CalculateBills(customers);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddCustomer(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Select Customer Type:");
            Console.WriteLine("1. Residential");
            Console.WriteLine("2. Commercial");
            Console.WriteLine("3. Industrial");
            Console.Write("Enter option (1-3): ");
            CustomerType type = (CustomerType)int.Parse(Console.ReadLine());

            Console.Write("Enter Water Consumption (in cubic meters): ");
            double waterConsumption = double.Parse(Console.ReadLine());

            customers.Add(new Customer(customerId, name, type, waterConsumption));
            Console.WriteLine("Customer added successfully.\n");
        }

        static void DisplayAllCustomers(List<Customer> customers)
        {
            Console.WriteLine("Customer List:");
            foreach (var customer in customers)
            {
                customer.DisplayCustomerInfo();
            }
            Console.WriteLine();
        }

        static void CalculateBills(List<Customer> customers)
        {
            Console.WriteLine("Billing Information:");
            foreach (var customer in customers)
            {
                customer.DisplayCustomerInfo();
                double bill = BillingCalculator.CalculateBill(customer);
                bill = BillingCalculator.ApplyTax(bill);
                bill = BillingCalculator.ApplyDiscount(bill, discount: 10.0);
                Console.WriteLine($"Final Bill for {customer.Name}: ${bill}\n");
            }
        }
    }
}
