using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Staff
    {
        public string Name { get; set; }
        public StaffType TypeOfStaff { get; set; }
        public string PhoneNumber { get; set; }

        public Staff(string name, StaffType staffType, string phoneNumber)
        {
            Name = name;
            TypeOfStaff = staffType;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name}, {TypeOfStaff}, {PhoneNumber}";
        }
    }

    public enum StaffType
    {
        Manager,
        Baker,
        Salesperson
    }
}
