using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PizzaStore
{
    public class Order
    {
        public static int NextId = 1;
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; } // First pizza in order
        public List<Pizza> Pizzas { get; set; } // Space for extra pizzas

        public Order(Customer customer, Pizza pizza)
        {
            Id = NextId++;
            Pizza = pizza;
            Customer = customer;
            Pizza = pizza;

            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        public void RemovePizza(Pizza pizza)
        {
            Pizzas.Remove(pizza);
        }

        public double CalculateTotalPrice()
        {
            double deliveryFee = 40;
            double taxPercentage = 0.25;
            double netTotal = Pizza.Price;

            foreach (Pizza p in Pizzas)
            {
                netTotal += p.Price;
            }
            

            double totalPrice = (netTotal + deliveryFee) * (1 + taxPercentage);

            return totalPrice;
        }

        public void PrintOrder()
        {
            Console.WriteLine(ToString() + "total: " + CalculateTotalPrice() + ",- incl. delivery & tax\n");
        }

        public override string ToString()
        {
            string extraPizzasString = "";

            foreach (Pizza p in Pizzas)
            {
                extraPizzasString = extraPizzasString + Pizza.ToString();
            }

            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Customer)}={Customer}, {nameof(Pizza)}={Pizza}, {nameof(Pizzas)}={extraPizzasString}}}";
        }
    }
}
