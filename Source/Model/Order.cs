using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrder.Model
{
    public class Order
    {
        private readonly List<OrderItem> _chips = new List<OrderItem>();
        private readonly List<OrderItem> _cookies = new List<OrderItem>();
        private readonly List<OrderItem> _drinks = new List<OrderItem>();
        private readonly List<Sandwich> _sandwiches = new List<Sandwich>();

        public List<Sandwich> Sandwiches
        {
            get { return _sandwiches; }
        }

        public List<OrderItem> Drinks
        {
            get { return _drinks; }
        }

        public List<OrderItem> Chips
        {
            get { return _chips; }
        }

        public List<OrderItem> Cookies
        {
            get { return _cookies; }
        }

        public double Total
        {
            get
            {
                return _sandwiches.Sum(sandwich => sandwich.Total * sandwich.Quantity) + _drinks.Sum(drink => drink.price * drink.quantity) +
                       _chips.Sum(chips => chips.price * chips.quantity) + _cookies.Sum(cookie => cookie.price * cookie.quantity);
            }
        }

        public bool IsCompleted
        {
            get { return _sandwiches.Count > 0 || _drinks.Count > 0 || _cookies.Count > 0 || _chips.Count > 0; }
        }
    }
}