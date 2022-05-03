using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ugeplan_System.ViewModel;

namespace Ugeplan_System.View
{
    /// <summary>
    /// Interaction logic for DateScheduleWindow.xaml
    /// </summary>
    public partial class DateScheduleWindow : Window
    {
        
        EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        public DateTime Day { get; set; }
        public MainViewModel Mvm { get; set; }
        List<EmployeeViewModel> eList = new List<EmployeeViewModel>();
        

        public DateScheduleWindow(DateTime day, MainViewModel mvm)
        {
            InitializeComponent();
            Day = day;
            Mvm = mvm;
            string weekDay = day.DayOfWeek.ToString();
            DateLabel.Content = $"{weekDay} {Day.Day}/{Day.Month}";
            foreach (EmployeeViewModel evm in mvm.Evm)
            {
                if(evm.Dates.Exists(x => x.ScheduleDate == day))
                {
                    eList.Add(evm);
                }
            }
            for (int i = 0; i < eList.Count; i++)
            {
                
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.FontSize = 30;
                string WFH = eList[i].Dates.Find(x => x.ScheduleDate == day).WorkFromHome ? "Online" : "Fysisk";
                listBoxItem.Content = eList[i].Name + ": " + eList[i].Dates.Find(x => x.ScheduleDate == day).StartTime + " - " + eList[i].Dates.Find(x => x.ScheduleDate == day).EndTime + " : " + WFH;
                listBox.Items.Add(listBoxItem);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
