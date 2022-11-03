using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class CustomerFile
    {
        public List<Customer> customerList { get; set; }

        public CustomerFile()
        {
            customerList = new List<Customer>();
        }

        public void AddCustomer(string name, string address, string phone, string email)
        {
            customerList.Add(new Customer(name, address, phone, email));
        }

        public void AddCustomer(Customer customer)
        {
            customerList.Add(customer);
        }

        public Customer RemoveById(int id)
        {
            foreach (Customer customer in customerList)
            {
                if (customer.Id == id)
                {
                    customerList.Remove(customer);
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetCustomers()
        {
            return customerList;
        }

        public void PrintMenu()
        {
            foreach (Customer customer in GetCustomers())
            {
                Console.WriteLine(customer);
            }
        }

        public Customer LookupById(int id)
        {
            foreach (Customer customer in customerList)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer LookupByName(string name)
        {
            foreach (Customer customer in customerList)
            {
                if (customer.Name.ToLower().Equals(name.ToLower()))
                {
                    return customer;
                }
            }
            return null;
        }

        public void UpdateInfo(Customer customer, string name, string address, string phone, string email)
        {
            if (customer != null)
            {
                customer.Name = name;
                customer.Address = address;
                customer.Telephone = phone;
                customer.Email = email;
            }
        }
    }
}
