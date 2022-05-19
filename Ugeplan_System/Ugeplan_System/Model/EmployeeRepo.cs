using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class EmployeeRepo
    {
        List<Employee> employees = new List<Employee>();
        private static readonly string connStr = "Server=10.56.8.36;Database=PEDB03;User Id=PE-03;Password=OPENDB_03";


        public EmployeeRepo()
        {
            InitializeRepo();
        }

        public void InitializeRepo()
        {
            Employee employee;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT EmployeeId, EmployeeName, JobPosition, Mail, PhoneNumber FROM Employee", conn);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeId = int.Parse(reader["EmployeeId"].ToString());
                        employee.Name = reader["EmployeeName"].ToString();
                        employee.JobPosition = reader["JobPosition"].ToString();
                        employee.Mail = reader["Mail"].ToString();
                        employee.PhoneNumber = reader["PhoneNumber"].ToString();
                        string[] temp = employee.Name.Split(' ');
                        employee.Initials = temp[0].Substring(0, 1) + temp[temp.Length - 1].Substring(0, 1);

                        employees.Add(employee);
                    }
                }
            }
        }

        public List<Employee> GetAllEmployee()
        {
            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            if(!employees.Exists(e => e.EmployeeId == employeeId))
            {
                return null;
            }
            return employees.Find(e => e.EmployeeId == employeeId);
        }
    }
}
