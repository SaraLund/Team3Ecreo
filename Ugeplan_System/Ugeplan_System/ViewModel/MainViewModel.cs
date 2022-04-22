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

        }

        public void GetEmployee(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                Evm.Add(new EmployeeViewModel());
            }
        }

        public void AddEmployee()
        {
            bool r = EmployeeRepo.AddEmployee();

            if (r)
            {
                Evm.Add(new EmployeeViewModel());
            }
        }

        public void GetDate(List<Date> dates)
        {
            foreach (Date d in dates)
            {
                Dvm.Add(new DateViewModel());
            }
        }

        public void AddDate()
        {
            bool r = DateRepo.AddDate();

            if (r)
            {
                Dvm.Add(new DateViewModel());
            }
        }



    }
}
