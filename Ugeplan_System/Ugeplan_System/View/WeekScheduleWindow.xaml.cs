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
    public partial class WeekScheduleWindow : Window
    {
        public MainViewModel Mvm { get; set; }
        public int Week { get; set; }
        public DateTime Day { get; set; }
        public int Year { get; set; }

        public WeekScheduleWindow(MainViewModel mvm)
        {
            Mvm = mvm;
            InitializeComponent();
            Week = ISOWeek.GetWeekOfYear(DateTime.Now);
            Year = DateTime.Now.Year;
            WeekNumberLabel.Content = $"Uge {Week} {Year}";

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NextWeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (Week == 52)
            {
                Week = 0;
                Year++;
            }

            Week++;
            WeekNumberLabel.Content =$"Uge {Week} {Year}";
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
            WeekNumberLabel.Content = $"Uge {Week} {Year}";

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
            WeekNumberLabel.Content = $"Uge {Week} {Year}";

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
            var DayWindow = new DateScheduleWindow(Day, Mvm);
            DayWindow.Show();
        }

        private void TuesdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Tuesday);
            var DayWindow = new DateScheduleWindow(Day, Mvm);
            DayWindow.Show();
        }

        private void WednsdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Wednesday);
            var DayWindow = new DateScheduleWindow(Day, Mvm);
            DayWindow.Show();
        }

        private void ThursdayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Thursday);
            var DayWindow = new DateScheduleWindow(Day, Mvm);
            DayWindow.Show();
        }

        private void FridayButton_Click(object sender, RoutedEventArgs e)
        {
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Friday);
            var DayWindow = new DateScheduleWindow(Day, Mvm);
            DayWindow.Show();
        }
    }
}
