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
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        private MainViewModel mvm;
        public MainViewModel Mvm
        {
            get { return mvm; }
            set { mvm = value; }
        }
        public AddProjectWindow(MainViewModel mvm)
        {
            Mvm = mvm;
            InitializeComponent();
            ListBoxItem lbi;
            foreach (EmployeeViewModel evm in Mvm.Evm)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string projectName = TextBoxID.Text;
            string description = TextBoxDescription.Text;
            string startTime = TextBoxStartTime.Text;
            string endTime = TextBoxEndTime.Text;
            int priority = int.Parse(TextBoxPriority.Text);
            List<string> names = new();
            foreach (ListBoxItem lbi in SelEmpListBox.Items)
            {
                names.Add(lbi.Content.ToString());
            }

            List<EmployeeViewModel> employees = new();
            foreach (string s in names)
            {
                if(Mvm.Evm.Any(e => e.Name == s))
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
            Mvm.AddProject(projectName, description, startTime, endTime, priority, employees, emptyString);
            this.Close();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = (AllEmpListBox.SelectedItem as ListBoxItem).Content;
            ListBoxItem lbi = new();
            lbi.FontSize = 15;
            lbi.Content = emp;
            SelEmpListBox.Items.Add(lbi);
        }
    }
}
