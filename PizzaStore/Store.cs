using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Store
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Menu Menu { get; set; }
        public Customer? Customer1 { get; set; }
        public Customer? Customer2 { get; set; }
        public Customer? Customer3 { get; set; }
        public Pizza? Pizza1 { get; set; }
        public Pizza? Pizza2 { get; set; }
        public Pizza? Pizza3 { get; set; }

        public Store(string name, string phoneNumber, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Menu = new Menu();
        }

        public void Start()
        {
            // Creating customers
            Customer1 = new Customer("Lars Larsen", "Gadevej 100", "+45 12345678", "larslarsen@email.com");
            Customer2 = new Customer("Jesper Jespersen", "Vejgade 100", "+45 87654321", "jesperjespersen@email.com");
            Customer3 = new Customer("Henrik Henriksen", "Strædegade 75", "+45 12344321", "henrikhenriksen@email.com");
            
            // Creating pizzas
            Pizza Pizza1 = new Pizza("Margherita", "Tomato & Cheese", 69);
            Pizza Pizza2 = new Pizza("Vesuvio", "Tomato, cheese & ham", 75);
            Pizza Pizza3 = new Pizza("Capricciosa", "Tomato, cheese, ham & mushrooms", 80);

            // Creating orders
            PizzaOrder firstOrder = new PizzaOrder(Customer1, Pizza1); 
            Console.WriteLine($"{firstOrder.ToString()}Total is: {firstOrder.CalculateTotalPrice()}kr (incl. delivery fee & tax)\n");

            PizzaOrder secondOrder = new PizzaOrder(Customer2, Pizza2);
            Console.WriteLine($"{secondOrder.ToString()}Total is: {secondOrder.CalculateTotalPrice()}kr (incl. delivery fee & tax)\n");

            PizzaOrder thirdOrder = new PizzaOrder(Customer3, Pizza3);
            Console.WriteLine($"{thirdOrder.ToString()}Total is: {thirdOrder.CalculateTotalPrice()}kr (incl. delivery fee & tax)\n");
        }

        public override string ToString()
        {
            string storeString = $"{Name}, {PhoneNumber}, {Address}";
            return storeString;
        }
    }
}
