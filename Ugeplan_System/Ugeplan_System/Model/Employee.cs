using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class Employee
    {
        
        public string Name { get; set; }
        public string JobPosition { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        public Employee(string name, string jobPosition, string mail, string phoneNumber)
        {
            Name = name;
            JobPosition = jobPosition;
            Mail = mail;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
