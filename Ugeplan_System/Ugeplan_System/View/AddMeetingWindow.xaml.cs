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
    /// Interaction logic for AddMeetingWindow.xaml
    /// </summary>
    public partial class AddMeetingWindow : Window
    {
        private bool online = false;
        public MainViewModel Mvm { get; set; }
        public AddMeetingWindow(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
            ListBoxItem lbi;
            foreach(EmployeeViewModel evm in Mvm.Evm)
            {
                lbi = new();
                lbi.FontSize = 15;
                lbi.Content = evm.Name;
                AllEmpListBox.Items.Add(lbi);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string room = TextBoxRoom.Text;
            string description = TextBoxDescription.Text;
            string startTime = TextBoxStartTime.Text;
            string endTime = TextBoxEndTime.Text;

            List<string> names = new();
            foreach(ListBoxItem lbi in SelEmpListBox.Items)
            {
                names.Add(lbi.Content.ToString());
            }

            List<EmployeeViewModel> employees = new();
            foreach (string s in names)
            {
                if (Mvm.Evm.Any(e => e.Name == s))
                {
                    employees.Add(Mvm.Evm.First(e => e.Name == s));
                }
            }

            string emptyString = "";
            string[] stringArrayAgain;
            foreach (string s in names)
            {
                stringArrayAgain = s.Split(' ');
                emptyString += stringArrayAgain[0].Substring(0, 1);
                emptyString += stringArrayAgain[stringArrayAgain.Length - 1].Substring(0, 1);
                emptyString += ";";
            }

            emptyString = emptyString.Remove(emptyString.Length - 1);
            DateTime date = Convert.ToDateTime(MeetingCal.SelectedDate);
            
            Mvm.AddMeeting(room, description, startTime, endTime, date, online, employees, emptyString);
            MessageBox.Show("Mødet er tilføjet");
            this.Close();
            
        }

        private void OnlineCheck_Checked(object sender, RoutedEventArgs e)
        {
            online = true;
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = (AllEmpListBox.SelectedItem as ListBoxItem).Content;
            AllEmpListBox.Items.Remove(AllEmpListBox.SelectedItem);
            ListBoxItem lbi = new();
            lbi.FontSize = 15;
            lbi.Content = emp;
            SelEmpListBox.Items.Add(lbi);
        }

        private void RemEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = (SelEmpListBox.SelectedItem as ListBoxItem).Content;
            SelEmpListBox.Items.Remove(SelEmpListBox.SelectedItem);
            ListBoxItem lbi = new();
            lbi.FontSize = 15;
            lbi.Content = emp;
            AllEmpListBox.Items.Add(lbi);
        }
    }
}
