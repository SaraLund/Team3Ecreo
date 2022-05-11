using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ugeplan_System.Model;

namespace Ugeplan_System.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<EmployeeViewModel> Evm { get; set; } = new();
        private static readonly EmployeeRepo er = new();
        public ObservableCollection<DateViewModel> Dvm { get; set; } = new();
        private static readonly DateRepo dr = new();
        public ObservableCollection<MeetingViewModel> Meetvm { get; set; } = new();
        private static readonly MeetingRepo mr = new(er.GetAllEmployee());
        public ObservableCollection<ProjectViewModel> Pvm { get; set; } = new();
        private static readonly ProjectRepo pr = new(er.GetAllEmployee());
        public MainViewModel()
        {
            GetEmployee(er.GetAllEmployee());
            GetDate(dr.GetAllDates());
            GetMeeting(mr.GetAllMeeting());
            GetProject(pr.GetAllProjects());
            GetDatesForEmployee();
        }

        public void GetDatesForEmployee()
        {
            for (int i = 0; i < Evm.Count; i++)
            {
                for (int j = 0; j < Dvm.Count; j++)
                {
                    if (Evm[i].EmployeeId == Dvm[j].EmployeeId)
                    {
                        Evm[i].Dates.Add(Dvm[j]);
                    }
                }
            }
        }

        // ----------------------------------EMPLOYEE---------------------------------- \\
        public void GetEmployee(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                Evm.Add(new EmployeeViewModel(e.EmployeeId, e.Name, e.JobPosition, e.Mail, e.PhoneNumber, e.Initials));
            }
        }

        public void AddEmployee(int employeeId, string name, string jobPosition, string mail, string phoneNumber, string initials)
        {
            Evm.Add(new EmployeeViewModel(employeeId, name, jobPosition, mail, phoneNumber, initials));
            er.AddEmployee(name, jobPosition, mail, phoneNumber, initials);
        }

        // ----------------------------------DATE---------------------------------- \\

        public void GetDate(List<Date> dates)
        {
            foreach (Date d in dates)
            {
                Dvm.Add(new DateViewModel(d.ScheduleDate, d.StartTime, d.EndTime, d.EmployeeId, d.WorkFromhome));
            }
        }

        public void AddDate(DateTime scheduleDate, string startTime, string endTime, int employeeId, bool workFromHome)
        {
            Dvm.Add(new DateViewModel(scheduleDate, startTime, endTime, employeeId, workFromHome));
            dr.AddDate(scheduleDate, startTime, endTime, employeeId, workFromHome);
            Evm.First(x => x.EmployeeId == employeeId).Dates.Add(new DateViewModel(scheduleDate, startTime, endTime, employeeId, workFromHome));
        }

        // ----------------------------------MEETING---------------------------------- \\

        public void GetMeeting(List<Meeting> meetings)
        {
            foreach (Meeting m in meetings)
            {
                List<EmployeeViewModel> newEmployees = new();
                EmployeeViewModel temp = new();
                for (int i = 0; i < m.Employees.Count; i++)
                {
                    temp.EmployeeId = m.Employees[i].EmployeeId;
                    temp.JobPosition = m.Employees[i].JobPosition;
                    temp.Mail = m.Employees[i].Mail;
                    temp.Name = m.Employees[i].Name;
                    temp.PhoneNumber = m.Employees[i].PhoneNumber;
                    newEmployees.Add(temp);
                }

                Meetvm.Add(new MeetingViewModel(m.Room, m.MeetingDescription, m.StartTime, m.EndTime, m.MeetingDate, m.OnlineMeeting, newEmployees));
            }
        }

        public void AddMeeting(string room, string meetingDescription, string startTime, string endTime, DateTime meetingDate, bool onlineMeeting, List<EmployeeViewModel> employees, string initials)
        {
            Meetvm.Add(new MeetingViewModel(room, meetingDescription, startTime, endTime, meetingDate, onlineMeeting, employees));
            List<Employee> newEmployees = new();
            Employee temp = new();
            for (int i = 0; i < employees.Count; i++)
            {
                temp.EmployeeId = employees[i].EmployeeId;
                temp.JobPosition = employees[i].JobPosition;
                temp.Mail = employees[i].Mail;
                temp.Name = employees[i].Name;
                temp.PhoneNumber = employees[i].PhoneNumber;
                temp.Initials = employees[i].Initials;
                newEmployees.Add(temp);
            }
          
            mr.AddMeeting(meetingDescription, startTime, endTime, meetingDate, onlineMeeting, newEmployees, room, initials);
        }

        // ----------------------------------PROJECT---------------------------------- \\

        public void GetProject(List<Project> projects)
        {
            foreach (Project p in projects)
            {
                List<EmployeeViewModel> newEmployees = new();
                EmployeeViewModel temp = new();
                for (int i = 0; i < p.Employees.Count; i++)
                {
                    temp.EmployeeId = p.Employees[i].EmployeeId;
                    temp.JobPosition = p.Employees[i].JobPosition;
                    temp.Mail = p.Employees[i].Mail;
                    temp.Name = p.Employees[i].Name;
                    temp.PhoneNumber = p.Employees[i].PhoneNumber;
                    temp.Initials = p.Employees[i].Initials;
                    newEmployees.Add(temp);
                }

                Pvm.Add(new ProjectViewModel(p.ProjectId ,p.ProjectName, p.Description, p.StartTime, p.EndTime, p.Priority, newEmployees));
            }
        }

        public void AddProject(string projectName, string description, string startTime, string endTime, int priority, List<EmployeeViewModel> employees, string names)
        {
            Pvm.Add(new ProjectViewModel(Pvm.Count + 1, projectName, description, startTime, endTime, priority, employees));
            List<Employee> newEmployees = new();
            Employee temp = new();
            for (int i = 0; i < employees.Count; i++)
            {
                temp.EmployeeId = employees[i].EmployeeId;
                temp.JobPosition = employees[i].JobPosition;
                temp.Mail = employees[i].Mail;
                temp.Name = employees[i].Name;
                temp.PhoneNumber = employees[i].PhoneNumber;
                temp.Initials = employees[i].Initials;
                newEmployees.Add(temp);
            }

            pr.AddProject(projectName, description, startTime, endTime, priority, newEmployees, names);
        }
    }
}
