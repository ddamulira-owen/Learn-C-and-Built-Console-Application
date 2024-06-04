using System;
using System.Collections.Generic;

namespace WaterBillingSystem
{
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
                Console.WriteLine("3. Receive Payment");
                Console.WriteLine("4. Display Customers with Outstanding Balance");
                Console.WriteLine("5. Display Customers with No Outstanding Balance");
                Console.WriteLine("6. Update Water Consumption");
                Console.WriteLine("7. Update Customer Details");
                Console.WriteLine("8. Remove Customer");
                Console.WriteLine("9. Retrieve Specific Customer");
                Console.WriteLine("10. Exit");
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
                        ReceivePayment(customers);
                        break;

                    case "4":
                        DisplayCustomersWithOutstandingBalance(customers);
                        break;

                    case "5":
                        DisplayCustomersWithNoOutstandingBalance(customers);
                        break;

                    case "6":
                        UpdateWaterConsumption(customers);
                        break;

                    case "7":
                        UpdateCustomerDetails(customers);
                        break;

                    case "8":
                        RemoveCustomer(customers);
                        break;

                    case "9":
                        RetrieveSpecificCustomer(customers);
                        break;

                    case "10":
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

            if (customers.Exists(c => c.CustomerID == customerId))
            {
                Console.WriteLine("Customer with this ID already exists.\n");
                return;
            }

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

        static void ReceivePayment(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.CustomerID == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.\n");
                return;
            }

            Console.Write("Enter Payment Amount: ");
            int payment = int.Parse(Console.ReadLine());

            customer.ReceivePayment(payment);
            Console.WriteLine($"Payment received. New balance for {customer.Name}: ${customer.Balance}\n");
        }

        static void DisplayCustomersWithOutstandingBalance(List<Customer> customers)
        {
            Console.WriteLine("Customers with Outstanding Balance:");
            foreach (var customer in customers)
            {
                if (customer.Balance > 0)
                {
                    customer.DisplayCustomerInfo();
                }
            }
            Console.WriteLine();
        }

        static void DisplayCustomersWithNoOutstandingBalance(List<Customer> customers)
        {
            Console.WriteLine("Customers with No Outstanding Balance:");
            foreach (var customer in customers)
            {
                if (customer.Balance <= 0)
                {
                    customer.DisplayCustomerInfo();
                }
            }
            Console.WriteLine();
        }

        static void UpdateWaterConsumption(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Customer customer = customers.Find(c => c.CustomerID == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.\n");
                return;
            }

            Console.Write("Enter Additional Water Consumption (in cubic meters): ");
            double additionalConsumption = double.Parse(Console.ReadLine());

            customer.UpdateWaterConsumption(additionalConsumption);
            Console.WriteLine($"Water consumption updated for {customer.Name}.\n");
        }

        static void UpdateCustomerDetails(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.CustomerID == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.\n");
                return;
            }

            Console.Write("Enter New Customer Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                customer.Name = newName;
            }

            Console.WriteLine("Select New Customer Type (leave blank to keep current):");
            Console.WriteLine("1. Residential");
            Console.WriteLine("2. Commercial");
            Console.WriteLine("3. Industrial");
            Console.Write("Enter option (1-3): ");
            string typeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(typeInput))
            {
                customer.Type = (CustomerType)int.Parse(typeInput);
            }

            Console.WriteLine($"Customer details updated for {customer.Name}.\n");
        }

        static void RemoveCustomer(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.CustomerID == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.\n");
                return;
            }

            customers.Remove(customer);
            Console.WriteLine("Customer removed successfully.\n");
        }

        static void RetrieveSpecificCustomer(List<Customer> customers)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.CustomerID == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.\n");
                return;
            }

            customer.DisplayCustomerInfo();
            Console.WriteLine();
        }
    }
}