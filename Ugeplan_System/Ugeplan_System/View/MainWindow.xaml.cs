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
using System.Globalization;

namespace Ugeplan_System.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // MainViewModel mvm = MainViewModel.Mvm;
        EmployeeViewModel evm = new EmployeeViewModel();
        private MainViewModel mvm;

        public MainViewModel Mvm
        {
            get { return mvm; }
            set { mvm = value; }
        }

        public int Week { get; set; }
        public DateTime Day { get; set; }
        public int Year { get; set; }



        public MainWindow()
        {
            Mvm = new MainViewModel();
            InitializeComponent();
            Week = ISOWeek.GetWeekOfYear(DateTime.Now);
            Year = DateTime.Now.Year;
            WeekNumberLabel.Content = $"uge {Week} {Year}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            MondayLabel.Content = $"Mandag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            TuesdayLabel.Content = $"Tirsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            WednesdayLabel.Content = $"Onsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            ThursdayLabel.Content = $"Torsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            FridayLabel.Content = $"Fredag {Day.Day}/{Day.Month}";
            
        }

        private void NextWeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (Week == 52)
            {
                Week = 0;
                Year++;
            }
            Week++;
            WeekNumberLabel.Content =$"uge {Week} {Year}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            MondayLabel.Content = $"Mandag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            TuesdayLabel.Content = $"Tirsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            WednesdayLabel.Content = $"Onsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            ThursdayLabel.Content = $"Torsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            FridayLabel.Content = $"Fredag {Day.Day}/{Day.Month}";
        }

        private void LastWeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (Week == 1 || Week == 0)
            {
                Week = 53;
                Year--;
            }
            Week--;

            WeekNumberLabel.Content = $"uge {Week} {Year}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            MondayLabel.Content = $"Mandag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            TuesdayLabel.Content = $"Tirsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            WednesdayLabel.Content = $"Onsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            ThursdayLabel.Content = $"Torsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            FridayLabel.Content = $"Fredag {Day.Day}/{Day.Month}";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Week = int.Parse(SearchTextBox.Text);
            WeekNumberLabel.Content = $"uge {Week} {Year}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            MondayLabel.Content = $"Mandag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            TuesdayLabel.Content = $"Tirsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            WednesdayLabel.Content = $"Onsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            ThursdayLabel.Content = $"Torsdag {Day.Day}/{Day.Month}";
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            FridayLabel.Content = $"Fredag {Day.Day}/{Day.Month}";
        }
        private void MondayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            var DayWindow = new DateScheduleWindow(Day, mvm);
            DayWindow.Show();
        }

        private void TuesdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            var DayWindow = new DateScheduleWindow(Day, mvm);
            DayWindow.Show();
        }

        private void WednsdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            var DayWindow = new DateScheduleWindow(Day, mvm);
            DayWindow.Show();
        }

        private void ThursdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            var DayWindow = new DateScheduleWindow(Day, mvm);
            DayWindow.Show();
        }

        private void FridayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            var DayWindow = new DateScheduleWindow(Day, mvm);
            DayWindow.Show();
        }
    }
}
