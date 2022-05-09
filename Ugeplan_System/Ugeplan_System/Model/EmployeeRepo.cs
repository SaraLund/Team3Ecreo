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

        public void AddEmployee(string name, string jobPosition, string mail, string phoneNumber, string initials)
        {
            Employee e = new Employee();
            e.EmployeeId = employees.Count;
            e.Name = name;
            e.JobPosition = jobPosition;
            e.Mail = mail;
            e.PhoneNumber = phoneNumber;
            e.Initials = initials;

            employees.Add(e);

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Employee(EmployeeName, JobPosition, Mail, PhoneNumber)" +
                                                    "VALUES (@employeeName, @ jobPosition, @mail, @phoneNumber)", conn);
                command.Parameters.Add("@employeeName", System.Data.SqlDbType.NVarChar).Value = e.Name;
                command.Parameters.Add("@jobPosition", System.Data.SqlDbType.NVarChar).Value = e.JobPosition;
                command.Parameters.Add("@mail", System.Data.SqlDbType.NVarChar).Value = e.Mail;
                command.Parameters.Add("@phoneNumber", System.Data.SqlDbType.NVarChar).Value = e.PhoneNumber;
                command.ExecuteNonQuery();
            }
        }

        public void RemoveEmployee(Employee oldEmployee)
        {
            if(employees.Contains(oldEmployee))
            {
                employees.Remove(oldEmployee);

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE EmployeeId = @employeeId;", conn);

                    command.Parameters.Add("@employeeId", System.Data.SqlDbType.Int).Value = oldEmployee.EmployeeId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(int employeeId, string name, string jobPosition, string mail, string phoneNumber)
        {
            if(employees.Exists(e => e.EmployeeId == employeeId))
            {
                Employee temp = employees.Find(e => e.EmployeeId == employeeId);
                temp.Name = name;
                temp.JobPosition = jobPosition;
                temp.Mail = mail;
                temp.PhoneNumber = phoneNumber;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Employee SET EmployeeName = @employeeName, JobPosition = @jobPosition, Mail = @mail, PhoneNumber = @phoneNumber" +
                                                        "WHERE EmployeeId = @employeeId", conn);

                    command.Parameters.Add(@name, System.Data.SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add(@jobPosition, System.Data.SqlDbType.NVarChar).Value = jobPosition;
                    command.Parameters.Add(@mail, System.Data.SqlDbType.NVarChar).Value = mail;
                    command.Parameters.Add(@phoneNumber, System.Data.SqlDbType.NVarChar).Value = phoneNumber;

                    command.ExecuteNonQuery();
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
