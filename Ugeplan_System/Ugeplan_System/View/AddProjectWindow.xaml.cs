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

            List<EmployeeViewModel> employees = new();


            Mvm.AddProject();



            this.Close();
        }
    }
}
