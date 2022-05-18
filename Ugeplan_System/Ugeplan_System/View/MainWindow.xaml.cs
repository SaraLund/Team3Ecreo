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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel Mvm { get; set; }
        public DateTime Day { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Mvm = new MainViewModel();
        }

        private void WeekScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var WeekWindow = new WeekScheduleWindow(Mvm);
            WeekWindow.Show();
        }

        private void AddDateButton_Click(object sender, RoutedEventArgs e)
        {
            var AddDateWindow = new AddDate(Mvm);
            AddDateWindow.Show();
        }

        private void IdScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var IdWindow = new IdScheduleWindow(Mvm);
            IdWindow.Show();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            var AddProject = new AddProjectWindow(Mvm);
            AddProject.Show();
        }

        private void AddMeetimg_Click(object sender, RoutedEventArgs e)
        {
            var AddMeeting = new AddMeetingWindow(Mvm);
            AddMeeting.Show();
        }

        private void ShowProject_Click(object sender, RoutedEventArgs e)
        {
            var ShowProject = new ShowProjectWindow(Mvm);
            ShowProject.Show();
        }

        private void ShowMeeting_Click(object sender, RoutedEventArgs e)
        {
            var ShowMeeting = new ShowMeetingWindow(Mvm);
            ShowMeeting.Show();
        }
    }
}
