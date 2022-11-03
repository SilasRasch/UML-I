using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Toppings { get; set; }
        public int Price { get; set; }

        public Pizza(string name, string toppings, int price)
        {
            Name = name;
            Toppings = toppings;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}: {Toppings}: {Price}kr";
        }
    }
}
