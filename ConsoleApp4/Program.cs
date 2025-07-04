using System;
using FawryInternship.Models;
using FawryInternship.Cart;
using FawryInternship.Services;

namespace FawryInternship
{
    class Program
    {
        static void Main(string[] args)
        {
            var cheese = new ExpirableProduct("Cheese", 100, 5, false, 0.2);
            var biscuits = new ExpirableProduct("Biscuits", 150, 3, false, 0.7);
            var tv = new NonExpirableProduct("TV", 5000, 2, true, 7.0);
            var scratchCard = new NonExpirableProduct("Scratch Card", 50, 10, false, 0);

            var customer = new Customer("Seif", 1000);
            var cart = new ShoppingCart();

            try
            {
                cart.Add(cheese, 2);
                cart.Add(biscuits, 1);
                cart.Add(scratchCard, 1);

                CheckoutService.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
