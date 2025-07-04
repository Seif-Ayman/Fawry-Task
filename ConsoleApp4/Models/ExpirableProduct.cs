using FawryInternship.Models;

namespace FawryInternship.Models
{
    public class ExpirableProduct : Product, IShippable
    {
        public bool Expired { get; set; }
        public double Weight { get; set; }

        public ExpirableProduct(string name, double price, int quantity, bool expired, double weight)
            : base(name, price, quantity)
        {
            Expired = expired;
            Weight = weight;
        }

        public override bool IsExpired() => Expired;
        public override bool NeedsShipping() => true;
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
