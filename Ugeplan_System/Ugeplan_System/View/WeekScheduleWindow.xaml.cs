﻿using System;
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
        // MainViewModel mvm = MainViewModel.Mvm;
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
            Day = ISOWeek.ToDateTime(DateTime.Now.Year, Week, DayOfWeek.Monday);
            foreach (EmployeeViewModel evm in mvm.Evm)
            {
                if (evm.Dates.Exists(x => x.ScheduleDate.ToShortDateString() == Day.ToShortDateString()))
                {
                    eList.Add(evm);
                    splitArray = evm.Name.Split(' ');

                    newEList.Add(splitArray[0].Substring(0,1) + splitArray[splitArray.Length - 1].Substring(0,1));
                }
            }
            for (int i = 0; i < eList.Count; i++)
            {
                Label l = new Label();
                Ellipse e = new Ellipse();
                e.Width = 35;
                e.Height = 35;
                e.Fill = new SolidColorBrush(Colors.Red);
                EmployeeListBox.Items.Add(e);
            }
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
