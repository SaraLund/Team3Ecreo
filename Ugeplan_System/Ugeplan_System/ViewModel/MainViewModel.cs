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
        private static MainViewModel mvm;
        public static MainViewModel Mvm
        {
            get
            {
                if (mvm != null)
                {
                    return mvm;
                }
                else
                {
                    return Mvm = new MainViewModel();
                }
            }
            set { mvm = value; }
        }
        public MainViewModel()
        {
            GetEmployee(er.GetAllEmployee());
            GetDate(dr.GetAllDates());
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
            
        }

        public void GetDate(List<Date> dates)
        {
            foreach (Date d in dates)
            {
                Dvm.Add(new DateViewModel(d.Day, d.ScheduleDate, d.StartTime, d.EndTime));
            }
        }

        public void AddDate(string day, DateTime scheduleDate, string startTime, string endTime)
        {
            Dvm.Add(new DateViewModel(day, scheduleDate, startTime, endTime));
        }



    }
}
