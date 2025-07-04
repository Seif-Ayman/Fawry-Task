using System;
using System.Collections.Generic;
using System.Linq;
using FawryInternship.Models;

namespace FawryInternship.Cart
{
    public class ShoppingCart
    {
        private List<CartItem> _items = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
                throw new Exception($"Not enough stock for {product.Name}");

            if (product.IsExpired())
                throw new Exception($"{product.Name} is expired and cannot be added.");

            _items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty() => !_items.Any();

        public List<CartItem> GetItems() => _items;
    }
}
