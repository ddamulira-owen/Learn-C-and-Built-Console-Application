using System;

namespace WaterBillingSystem
{
    // Class representing a Customer
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public CustomerType Type { get; set; }
        public double WaterConsumption { get; set; } // In cubic meters
        public int Balance { get; set; } // Outstanding balance in integer

        public Customer(int customerId, string name, CustomerType type, double waterConsumption)
        {
            CustomerID = customerId;
            Name = name;
            Type = type;
            WaterConsumption = waterConsumption;
            Balance = CalculateAndUpdateBill();
        }

        // Method to display customer details
        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}, Name: {Name}, Type: {Type}, Water Consumption: {WaterConsumption:F1} cubic meters, Balance: ${Balance}");
        }

        // Method to update balance after receiving payment
        public void ReceivePayment(int amount)
        {
            Balance -= amount;
            /* if (Balance < 0)
             {
                 Balance = 0;
             }*/
        }

        // Method to update water consumption
        public void UpdateWaterConsumption(double newConsumption)
        {
            WaterConsumption += newConsumption;
            CalculateAndUpdateBill();
        }

        // Method to calculate and update the bill
        private int CalculateAndUpdateBill()
        {
            var billingCalculator = new BillingCalculator();
            double bill = billingCalculator.CalculateBill(this);
            bill = billingCalculator.ApplyTax(bill);
            return Balance += (int)Math.Ceiling(bill);
        }
    }
}