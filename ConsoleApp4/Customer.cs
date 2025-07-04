namespace FawryInternship
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public bool CanPay(double amount) => Balance >= amount;
        public void Pay(double amount) => Balance -= amount;
    }
}
