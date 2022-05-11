using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ugeplan_System.Model;

namespace Ugeplan_System.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string JobPosition { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public List<DateViewModel> Dates { get; set; } = new List<DateViewModel>();
        public string Initials { get; set; }

        public EmployeeViewModel(int employeeId, string name, string jobPosition, string mail, string phoneNumber, string initials)
        {
            EmployeeId = employeeId;
            Name = name;
            JobPosition = jobPosition;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Initials = initials;
        }

        public EmployeeViewModel()
        {

        }

        public override string ToString()
        {
            return $"{EmployeeId}, {Name}, {JobPosition}, {Mail}, {PhoneNumber}";
        }
    }
}
