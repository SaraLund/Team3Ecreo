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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ugeplan_System.ViewModel;

namespace Ugeplan_System.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        EmployeeViewModel evm = new EmployeeViewModel();
        int week = 1;
        int day = 4;
        int year = 2022;
        int month = 4;
        
        public MainWindow()
        {
            InitializeComponent();
            MondayLabel.Content = $"Mandag {day}/{month}";
            day++;
            TuesdayLabel.Content = $"Tirsdag {day}/{month}";
            day++;
            WednesdayLabel.Content = $"Onsdag {day}/{month}";
            day++;
            ThursdayLabel.Content = $"Torsdag {day}/{month}";
            day++;
            FridayLabel.Content = $"Fredag {day}/{month}";

            for (int i = 0; i < mvm.Evm.Count; i++)
            {
                Ellipse EllipseSpawner = new Ellipse();
                
            }
        }

        private void MondayButton_Click(object sender, RoutedEventArgs e)
        {
            var Hej = new DateScheduleWindow();
            Hej.Show();
            MondayLabel.Content = $"Mandag {day}/{month}";
            
        }

        private void NextWeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (week == 52)
            {
                week = 0;
                year++;
            }
            week++;
            WeekNumberLabel.Content =$"uge {week} {year}";
        }

        private void LastWeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (week == 1 || week == 0)
            {
                week = 53;
                year--;
            }
            week--;

            WeekNumberLabel.Content = $"uge {week} {year}";
        }
    }
}
