using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Employee
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Employee(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(PhoneNumber)}={PhoneNumber}}}";
        }
    }

    public class Manager : Employee
    {
        public string Email { get; set; }
        public Manager(string name, string phoneNumber, string email)
            : base(name, phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Baker : Employee
    {
        public Baker(string name, string phoneNumber)
            : base(name, phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    public class Salesperson : Employee
    {
        public Salesperson(string name, string phoneNumber)
            : base(name, phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
