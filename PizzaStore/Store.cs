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
        public PizzaMenu? Menu { get; set; } // Helper property for Menu dialogue-system and Start-method

        public Store(string name, string phoneNumber, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        #region StartMethod
        public void Start()
        {
            // Creating customers
            CustomerFile customerFile = new CustomerFile();

            Customer Customer1 = new Customer("Lars Larsen", "Gadevej 100", "+45 12345678", "larslarsen@email.com");
            customerFile.AddCustomer(Customer1);

            customerFile.AddCustomer("Jesper Jespersen", "Vejgade 100", "+45 87654321", "jesperjespersen@email.com");

            customerFile.UpdateInfo(Customer1, "Lars Jespersen", "Gadevej 99", "12341234", "larsjespersen@hotmail.com"); // Update customer
            customerFile.RemoveById(customerFile.LookupByName("Jesper Jespersen").Id); // Lookup by name, then remove by ID

            // Creating pizzas
            Menu = new PizzaMenu();

            Pizza Pizza1 = new Pizza("Margherita", "Tomato & Cheese", 69);
            Menu.AddPizza(Pizza1);

            Pizza Pizza2 = new Pizza("Vesuvio", "Tomato, cheese & ham", 75);
            Menu.AddPizza(Pizza2);

            Menu.AddPizza("Capricciosa", "Tomato, cheese, ham & mushrooms", 80); // -
            Menu.RemoveByNo(3); // Remove pizza

            Menu.UpdatePizza(Pizza1, "Margherita", "Tomato & Cheese", 75); // Update pizza

            // Creating orders
            Order firstOrder = new Order(Customer1, Pizza1); // Create order with existing objects
            firstOrder.PrintOrder();


            Order secondOrder = new Order(customerFile.LookupByName("Lars Jespersen"), Pizza2); // Create order by looking up name of customer

            Order thirdOrder = new Order(customerFile.LookupById(1), Menu.SearchPizza(2)); // Create order by looking up customer ID and pizza no. !SEARCH PIZZA!

            // Print menu
            Menu.PrintMenu();
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            // Creating menu dialogue
            List<string> menuItems = new List<string>(); // Har svært ved at forestille mig, det her er det bedste sted...
            menuItems.Add("1. Add new pizza to the menu");
            menuItems.Add("2. Delete pizza");
            menuItems.Add("3. Update pizza");
            menuItems.Add("4. Search pizza");
            menuItems.Add("5. Display pizza menu");
            menuItems.Add("6. To exit application");

            MenuStart(menuItems, Menu);
        }

        #endregion
        #region Menu
        // Menu!!
        public int MenuChoice(List<string> menuItems)
        {
            foreach (string item in menuItems)
            {
                Console.WriteLine(item);
            }

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice < menuItems.Count + 1)
                {
                    return choice;
                }
                Console.WriteLine("Please input a valid number");
                return -1;
            }
            catch
            {
                Console.WriteLine("Input error - please input a number");
                return -1;
            }
        }

        public void MenuStart(List<string> menuItems, PizzaMenu pizzaMenu)
        {
            int choice = MenuChoice(menuItems);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please input the name of the new pizza");
                    string pizzaName = Console.ReadLine();
                    Console.WriteLine("Please input the toppings of the new pizza");
                    string pizzaToppings = Console.ReadLine();
                    Console.WriteLine("Please input the price of the new pizza");
                    try
                    {
                        int pizzaPrice = Convert.ToInt32(Console.ReadLine());
                        pizzaMenu.AddPizza(pizzaName, pizzaToppings, pizzaPrice);
                    }
                    catch
                    {
                        Console.WriteLine("Input error: please input a number");
                        MenuStart(menuItems, pizzaMenu);
                    }
                    break;

                case 2:
                    Menu.PrintMenu();
                    Console.WriteLine("Please input number of pizza to remove");
                    try
                    {
                        int pizzaToRemove = Convert.ToInt32(Console.ReadLine());
                        if (pizzaMenu.SearchPizza(pizzaToRemove) != null)
                        {
                            pizzaMenu.RemoveByNo(pizzaToRemove);
                            MenuStart(menuItems, pizzaMenu);
                        }
                        else
                        {
                            Console.WriteLine("Pizza does not exist in menu");
                            MenuStart(menuItems, pizzaMenu);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Input error: please input the number of an existing pizza");
                        MenuStart(menuItems, pizzaMenu);
                    }
                    break;

                case 3:
                    Menu.PrintMenu();
                    Console.WriteLine("Please input the number of the pizza to update");
                    try
                    {
                        int numOfPizzaToUpdate = Convert.ToInt32(Console.ReadLine());
                        if (pizzaMenu.SearchPizza(numOfPizzaToUpdate) != null)
                        {
                            Pizza pizzaToUpdate = pizzaMenu.SearchPizza(numOfPizzaToUpdate);

                            Console.WriteLine("Please input the updated name of the pizza");
                            string updatedName = Console.ReadLine();
                            Console.WriteLine("Please input the updated toppings of the pizza");
                            string updatedToppings = Console.ReadLine();
                            Console.WriteLine("Please input the updated price of the pizza");
                            try
                            {
                                int updatedPrice = Convert.ToInt32(Console.ReadLine());
                                pizzaMenu.UpdatePizza(pizzaToUpdate, updatedName, updatedToppings, updatedPrice);
                                MenuStart(menuItems, pizzaMenu);
                            }
                            catch
                            {
                                Console.WriteLine("Input error: please input a number");
                                MenuStart(menuItems, pizzaMenu);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pizza does not exist in menu");
                            MenuStart(menuItems, pizzaMenu);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Input error: please input the number of an existing pizza");
                        MenuStart(menuItems, pizzaMenu);
                    }
                    break;

                case 4:
                    Console.WriteLine("Please input number of the desired pizza");
                    try
                    {
                        int pizzaNum = Convert.ToInt32(Console.ReadLine());
                        if (pizzaMenu.Menu.TryGetValue(pizzaNum, out Pizza? value))
                        {
                            Console.WriteLine(value);
                            MenuStart(menuItems, pizzaMenu);
                        }
                        else
                        {
                            Console.WriteLine("Input error: please input the number of an existing pizza");
                            MenuStart(menuItems, pizzaMenu);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Input error: please input the number of an existing pizza");
                        MenuStart(menuItems, pizzaMenu);
                    }
                    break;

                case 5:
                    pizzaMenu.PrintMenu();
                    MenuStart(menuItems, pizzaMenu);
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default: 
                    MenuStart(menuItems, pizzaMenu);
                    break;
            }
        }

        #endregion
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(PhoneNumber)}={PhoneNumber}, {nameof(Address)}={Address}}}";
        }
    }
}
