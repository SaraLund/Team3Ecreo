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
    /// Interaction logic for ShowProjectWindow.xaml
    /// </summary>
    public partial class ShowProjectWindow : Window
    {
        public DateTime Day { get; set; }
        public MainViewModel Mvm { get; set; }
        public List<ProjectViewModel> ProjectList = new();
        int projectNumber = 0;

        public ShowProjectWindow(MainViewModel mvm)
        {
            InitializeComponent();
            Mvm = mvm;
            foreach (ProjectViewModel pvm in mvm.Pvm)
            {
                ProjectList.Add(pvm);
            }

            TempNameMethod();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LastProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if(projectNumber == 0)
            {
                projectNumber = ProjectList.Count() - 1;
            }
            else
            {
                projectNumber -= 1 ;
            }

            TempNameMethod();
        }

        private void NextProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (projectNumber == ProjectList.Count() - 1)
            {
                projectNumber = 0;
            }
            else
            {
                projectNumber += 1;
            }

            TempNameMethod();
        }

        private void TempNameMethod()
        {
            string temp = "";
            TextBoxID.Text = ProjectList[projectNumber].ProjectName.ToString();
            TextBoxStartTime.Text = ProjectList[projectNumber].StartTime.ToString();
            TextBoxEndTime.Text = ProjectList[projectNumber].EndTime.ToString();
            TextBoxPriority.Text = ProjectList[projectNumber].Priority.ToString();
            TextBoxDescription.Text = ProjectList[projectNumber].Description.ToString();
            TextBoxEmployees.Text = "";
            foreach (EmployeeViewModel employee in ProjectList[projectNumber].Employees)
            {
                temp += employee.Name + ", ";

            }

            temp = temp.Remove(temp.Length - 2,2);
            TextBoxEmployees.Text = temp;
        }
    }
}
