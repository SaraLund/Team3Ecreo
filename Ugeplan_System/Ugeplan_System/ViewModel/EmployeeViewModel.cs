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
        private EmployeeRepo emRepo = new EmployeeRepo();
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string JobPosition { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public List<DateViewModel> dates { get; set; } = new List<DateViewModel>();
        public EmployeeViewModel(int employeeId, string name, string jobPosition, string mail, string phoneNumber)
        {
            EmployeeId = employeeId;
            Name = name;
            JobPosition = jobPosition;
            Mail = mail;
            PhoneNumber = phoneNumber;
        }

        public List<EmployeeViewModel> employeeList { get; set; }
        public EmployeeViewModel()
        {
            employeeList = new List<EmployeeViewModel>();
            GetAllEmployees();
        }

        public void GetAllEmployees()
        {
            List<Employee> employeeTemp = emRepo.GetAllEmployee();
            foreach (Employee e in employeeTemp)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel(e.EmployeeId ,e.Name, e.JobPosition, e.Mail, e.PhoneNumber);
                employeeList.Add(employeeViewModel);
            }
        }

        public override string ToString()
        {
            return $"{EmployeeId}, {Name}, {JobPosition}, {Mail}, {PhoneNumber}";
        }
    }
}
