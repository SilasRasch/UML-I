using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class PizzaOrder
    {
        public static int OrderTotalAmount { get; set; } = 0;
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza;
        private int _totalPrice;

        public PizzaOrder(Customer customer, Pizza pizza)
        {   
            Pizza = pizza;
            Customer = customer;
            
            OrderId = OrderTotalAmount + 1; // Order ID generation
            OrderTotalAmount++;

            _totalPrice = pizza.Price; // Total init
        }

        public double CalculateTotalPrice()
        {
            double deliveryFee = 40;
            double taxPercentage = 0.25;

            double totalPrice = (Pizza.Price + deliveryFee) * (1 + taxPercentage);

            return totalPrice;
        }

        public override string ToString()
        {
            return $"Order ID: {OrderId} for {Customer.Name}. \n{Pizza}.\n";
        }

        public void PrintOrder()
        {
            Console.WriteLine(ToString() + "total: " + CalculateTotalPrice() + ",- incl. delivery & tax\n");
        }
    }
}
