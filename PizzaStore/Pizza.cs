using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        public static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Toppings { get; set; }
        public int Price { get; set; }

        public Pizza(string name, string toppings, int price)
        {
            Name = name;
            Toppings = toppings;
            Price = price;
            Id = NextId++;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Toppings)}={Toppings}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
