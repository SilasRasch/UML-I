using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Customer(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Telephone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name}, {Address}, {Telephone}, {Email}";
        }
    }
}
