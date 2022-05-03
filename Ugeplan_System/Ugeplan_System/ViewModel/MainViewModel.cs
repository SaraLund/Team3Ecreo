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
        private static readonly EmployeeRepo er = new EmployeeRepo();
        public ObservableCollection<DateViewModel> Dvm { get; set; } = new();
        private static readonly DateRepo dr = new DateRepo();
        public MainViewModel()
        {
            GetEmployee(er.GetAllEmployee());
            GetDate(dr.GetAllDates());
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

        public void GetEmployee(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                Evm.Add(new EmployeeViewModel(e.EmployeeId, e.Name, e.JobPosition, e.Mail, e.PhoneNumber));
            }
        }

        public void AddEmployee(int employeeId, string name, string jobPosition, string mail, string phoneNumber)
        {
            Evm.Add(new EmployeeViewModel(employeeId, name, jobPosition, mail, phoneNumber));
            er.AddEmployee(name, jobPosition, mail, phoneNumber);
        }

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

    }
}
