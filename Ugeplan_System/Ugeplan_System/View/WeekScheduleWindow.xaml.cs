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
        List<EmployeeViewModel> eList = new List<EmployeeViewModel>();
        List<String> newEList = new List<String>();
        EmployeeViewModel evm = new EmployeeViewModel();
        public MainViewModel Mvm { get; set; }
        string[] splitArray;
        public int Week { get; set; }
        public DateTime Day { get; set; }
        public int Year { get; set; }



        public WeekScheduleWindow(MainViewModel mvm)
        {
            Mvm = mvm;
            InitializeComponent();
            Week = ISOWeek.GetWeekOfYear(DateTime.Now);
            Year = DateTime.Now.Year;
            WeekNumberLabel.Content = $"uge {Week} {Year}";

            FillWeekSchedule();
            
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
            FillWeekSchedule();
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

            FillWeekSchedule();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Week = int.Parse(SearchTextBox.Text);
            WeekNumberLabel.Content = $"uge {Week} {Year}";

            FillWeekSchedule();
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
        
        private void Clear()
        {
            EmployeeListBox1.Items.Clear();
            EmployeeListBox2.Items.Clear();
            EmployeeListBox3.Items.Clear();
            EmployeeListBox4.Items.Clear();
            EmployeeListBox5.Items.Clear();
        }

        private void FillWeekSchedule()
        {
            Clear();
            Label l;
            string s;

            Day = ISOWeek.ToDateTime(Year, Week, DayOfWeek.Monday);
            MondayLabel.Content = $"Mandag {Day.Day}/{Day.Month}";
            ShowInitials(EmployeeListBox1);

            Day = ISOWeek.ToDateTime(Year, Week, DayOfWeek.Tuesday);
            TuesdayLabel.Content = $"Tirsdag {Day.Day}/{Day.Month}";
            ShowInitials(EmployeeListBox2);

            Day = ISOWeek.ToDateTime(Year, Week, DayOfWeek.Wednesday);
            WednesdayLabel.Content = $"Onsdag {Day.Day}/{Day.Month}";
            ShowInitials(EmployeeListBox3);

            Day = ISOWeek.ToDateTime(Year, Week, DayOfWeek.Thursday);
            ThursdayLabel.Content = $"Torsdag {Day.Day}/{Day.Month}";
            ShowInitials(EmployeeListBox4);

            Day = ISOWeek.ToDateTime(Year, Week, DayOfWeek.Friday);
            FridayLabel.Content = $"Fredag {Day.Day}/{Day.Month}";
            ShowInitials(EmployeeListBox5);
        }

        private void ShowInitials(ListBox listBox) 
        {
            Label l;
            string s;
            foreach (EmployeeViewModel evm in Mvm.Evm)
            {
                if (evm.Dates.Exists(x => x.ScheduleDate.ToShortDateString() == Day.ToShortDateString()))
                {
                    splitArray = evm.Name.Split(' ');
                    s = splitArray[0].Substring(0, 1) + splitArray[splitArray.Length - 1].Substring(0, 1);
                    l = new Label();
                    l.FontSize = 30;
                    l.Content = s;
                    l.Background = new SolidColorBrush(Colors.White);
                    listBox.Items.Add(l);
                }
            }
        }
    }
}
