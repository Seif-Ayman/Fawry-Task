using System;

namespace FawryInternship.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        protected Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public abstract bool IsExpired();
        public abstract bool NeedsShipping();
    }
}
