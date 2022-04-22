﻿using System;
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

        public Employee(int employeeId, string name, string jobPosition, string mail, string phoneNumber)
        {
            EmployeeId = employeeId;
            Name = name;
            JobPosition = jobPosition;
            Mail = mail;
            PhoneNumber = phoneNumber;
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
