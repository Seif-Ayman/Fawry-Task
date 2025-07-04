using FawryInternship.Models;

namespace FawryInternship.Models
{
    public class NonExpirableProduct : Product, IShippable
    {
        public bool RequiresShipping { get; set; }
        public double Weight { get; set; }

        public NonExpirableProduct(string name, double price, int quantity, bool requiresShipping, double weight)
            : base(name, price, quantity)
        {
            RequiresShipping = requiresShipping;
            Weight = weight;
        }

        public override bool IsExpired() => false;
        public override bool NeedsShipping() => RequiresShipping;
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
