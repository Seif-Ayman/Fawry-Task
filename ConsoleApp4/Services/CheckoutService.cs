using System;
using System.Collections.Generic;
using FawryInternship.Cart;
using FawryInternship.Models;

namespace FawryInternship.Services
{
    public class CheckoutService
    {
        private const double ShippingFee = 30.0;

        public static void Checkout(Customer customer, ShoppingCart cart)
        {
            if (cart.IsEmpty())
                throw new Exception("Cart is empty. Add some items before checkout.");

            double subtotal = 0;
            List<IShippable> shippables = new List<IShippable>();
            Dictionary<string, int> shippingQuantities = new Dictionary<string, int>();
            bool requiresShipping = false;

            foreach (var item in cart.GetItems())
            {
                var p = item.Product;
                subtotal += p.Price * item.Quantity;

                if (p.NeedsShipping())
                {
                    requiresShipping = true;
                    shippables.Add((IShippable)p);
                    shippingQuantities[p.Name] = item.Quantity;
                }
            }

            double total = subtotal + (requiresShipping ? ShippingFee : 0);

            if (!customer.CanPay(total))
                throw new Exception("Insufficient balance.");

            foreach (var item in cart.GetItems())
                item.Product.Quantity -= item.Quantity;

            customer.Pay(total);

            if (requiresShipping)
                ShippingService.Ship(shippables, shippingQuantities);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.GetItems())
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name.PadRight(12)} {item.Product.Price * item.Quantity}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {subtotal}");
            if (requiresShipping)
                Console.WriteLine($"Shipping         {ShippingFee}");
            Console.WriteLine($"Amount           {total}");
            Console.WriteLine($"Balance Left     {customer.Balance}");
        }
    }
}
