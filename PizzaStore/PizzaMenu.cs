using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class PizzaMenu
    {
        public Dictionary<int, Pizza> Menu { get; set; }

        public PizzaMenu()
        {
            Menu = new Dictionary<int, Pizza>();
        }
        
        public void AddPizza(Pizza pizza)
        {
            Menu.Add(pizza.Id, pizza);
        }
        
        public void AddPizza(string name, string topping, int price)
        {
            Pizza pizza = new Pizza(name, topping, price);

            Menu.Add(pizza.Id, pizza);
        }

        public void UpdatePizza(Pizza pizza, string name, string topping, int price)
        {
            if (pizza != null)
            {
                pizza.Name = name;
                pizza.Toppings = topping;
                pizza.Price = price;
            }
        }

        public Pizza SearchPizza(int pizzaNo)
        {
            if (Menu.TryGetValue(pizzaNo, out Pizza? value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        
        public List<Pizza> PizzaList()
        {
            List<Pizza> pizzaList = new List<Pizza>();

            foreach (Pizza pizza in Menu.Values)
            {
                pizzaList.Add(pizza);
            }

            return pizzaList;
        }

        public void PrintMenu()
        {
            Console.WriteLine("- Menu -");
            Console.WriteLine();
            foreach (Pizza pizza in PizzaList())
            {
                Console.WriteLine($"No. {pizza.Id} - {pizza.Toppings} - {pizza.Price} kr");
            }
            Console.WriteLine();
        }

        public Pizza RemoveByNo(int pizzaNo)
        {
            if (Menu.TryGetValue(pizzaNo, out Pizza? value))
            {
                Menu.Remove(pizzaNo);
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
