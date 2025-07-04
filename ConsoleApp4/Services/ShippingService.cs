using System;
using System.Collections.Generic;
using FawryInternship.Models;

namespace FawryInternship.Services
{
    public static class ShippingService
    {
        public static void Ship(List<IShippable> itemsToShip, Dictionary<string, int> quantities)
        {
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;

            foreach (var item in itemsToShip)
            {
                string name = item.GetName();
                int qty = quantities[name];
                double weight = item.GetWeight() * qty;
                totalWeight += weight;

                Console.WriteLine($"{qty}x {name.PadRight(12)} {weight * 1000}g");
            }

            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
        }
    }
}
