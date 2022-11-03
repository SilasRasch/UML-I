using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        public static int NextId = 1;
        public int Id { get; set; }
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
            Id = NextId++;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Address)}={Address}, {nameof(Telephone)}={Telephone}, {nameof(Email)}={Email}}}";
        }
    }
}
