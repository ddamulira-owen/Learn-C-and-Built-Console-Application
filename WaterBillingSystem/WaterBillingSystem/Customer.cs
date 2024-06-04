namespace WaterBillingSystem
{
    // Class for utility methods
    public class BillingCalculator
    {
        // Method overloading to calculate bill based on customer type
        public double CalculateBill(Customer customer)
        {
            return CalculateBill(customer.Type, customer.WaterConsumption);
        }

        public double CalculateBill(CustomerType type, double waterConsumption)
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

        // Method with default parameter
        public double ApplyTax(double billAmount, double taxRate = 0.1)
        {
            return billAmount + (billAmount * taxRate);
        }
    }
}