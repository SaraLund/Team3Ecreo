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
    /// Interaction logic for ShowMeetingWindow.xaml
    /// </summary>
    public partial class ShowMeetingWindow : Window
    {
        public MainViewModel Mvm { get; set; }
        public List<MeetingViewModel> MeetingList = new();
        int meetingnumber = 0;
        public ShowMeetingWindow(MainViewModel mvm)
        {
            InitializeComponent();
            foreach (MeetingViewModel meetvm in mvm.Meetvm)
            {
                MeetingList.Add(meetvm);
            }
            ShowMeetingInfo();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NextMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            if (meetingnumber == MeetingList.Count() - 1)
            {
                meetingnumber = 0;
            }
            else
            {
                meetingnumber += 1;
            }
            ShowMeetingInfo();
        }

        private void LastMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            if (meetingnumber == 0)
            {
                meetingnumber = MeetingList.Count() - 1;
            }
            else
            {
                meetingnumber -= 1;
            }
            ShowMeetingInfo();
        }
        private void ShowMeetingInfo()
        {
            string temp = "";
            TextBoxRoom.Text = MeetingList[meetingnumber].Room.ToString();
            TextBoxDescription.Text = MeetingList[meetingnumber].MeetingDescription.ToString();
            TextBoxDate.Text = MeetingList[meetingnumber].MeetingDate.ToString();
            TextBoxStartTime.Text = MeetingList[meetingnumber].StartTime.ToString();
            TextBoxEndTime.Text = MeetingList[meetingnumber].EndTime.ToString();
            OnlineCheck.IsChecked = MeetingList[meetingnumber].OnlineMeeting;
            TextBoxEmployees.Text = "";
            foreach (EmployeeViewModel employee in MeetingList[meetingnumber].Employees)
            {
                temp += employee.Name + ", ";

            }

            temp = temp.Remove(temp.Length - 2, 2);
            TextBoxEmployees.Text = temp;
        }
    }
}
