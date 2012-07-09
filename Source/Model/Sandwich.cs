using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrder.Model
{
    public class Sandwich
    {
        public Guid Id { get; set; }
        private int _quantity;

        public Sandwich()
        {
            Id = Guid.NewGuid();
            Size = SubSize.SixInch;
        }

        public SubSize Size { get; set; }

        public double Total
        {
            get
            {
                return Meats.Sum(meat => meat.price * meat.quantity) + Cheese.quantity +
                       (Size == SubSize.SixInch ? Bread.price/2 : Bread.price);
            }
        }

        public int Quantity
        {
            get { return (_quantity = _quantity <=0  ? 1 : _quantity); }
            set { _quantity = value; }
        }

        private OrderItem _bread = new OrderItem();
        private OrderItem _cheese = new OrderItem();
        private readonly List<OrderItem> _meats = new List<OrderItem>();
        private readonly List<OrderItem> _veggies = new List<OrderItem>();

        public OrderItem Bread
        {
            get { return _bread; }
            set
            {
                if (value.type != "Bread") return;
                _bread = value;
            }
        }

        public OrderItem Cheese
        {
            get { return _cheese; }
            set
            {
                if (value.type != "Cheese") return;
                _cheese = value;
            }
        }

        public List<OrderItem> Meats
        {
            get {return _meats;}
        }

        public List<OrderItem> Veggies
        {
            get { return _veggies; }
        }
    }
}