using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string JobPosition { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public List<Date> Dates { get; set; } = new List<Date>(); 
        

        public Employee(int employeeId, string name, string jobPosition, string mail, string phoneNumber, List<Date> dates)
        {
            EmployeeId = employeeId;
            Name = name;
            JobPosition = jobPosition;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Dates = dates;
        }

        public Employee()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
