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
    /// Interaction logic for IdScheduleWindow.xaml
    /// </summary>
    public partial class IdScheduleWindow : Window
    {
        public IdScheduleWindow(MainViewModel mvm)
        {
            InitializeComponent();
            mainViewModel = mvm;
        }

        public MainViewModel mainViewModel;

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = SearchTextBox.Text;
            if(mainViewModel.Evm.Any(x => x.Name == Name))
            {
                EmployeeViewModel evm = mainViewModel.Evm.First(x => x.Name == Name);
                List<DateViewModel> dates = evm.Dates.OrderBy(x => x.ScheduleDate).ToList();
                foreach (DateViewModel d in dates) 
                {
                    ListBoxItem listBoxItem = new();
                    listBoxItem.FontSize = 30;
                    string WFH;
                    if (d.WorkFromHome)
                    {
                        WFH = "Online";
                    }
                    else
                    {
                        WFH = "Fysisk";
                    }
                    listBoxItem.Content = evm.Name + ": " + d.ScheduleDate.DayOfWeek + " d " 
                                                   + d.ScheduleDate.ToShortDateString() 
                                                   + " " + d.StartTime + " - " + d.EndTime + " : " + WFH;
                    listBox.Items.Add(listBoxItem);
                }
            }
            else
            {
                MessageBox.Show("Du har vist tastet forkert");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
