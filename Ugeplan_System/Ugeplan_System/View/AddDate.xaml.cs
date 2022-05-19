using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddDate.xaml
    /// </summary>
    public partial class AddDate : Window
    {
        public bool WorkFromHome { get; set; } = false;
        private MainViewModel mvm;
        public MainViewModel Mvm
        {
            get { return mvm; }
            set { mvm = value; }
        }
        
        public AddDate(MainViewModel mvm)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime scheduleDate = Convert.ToDateTime(scheduleCal.SelectedDate);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            if(scheduleDate < dateTime)
            {
                MessageBox.Show("Denne dato er i fortiden");
            }
            else
            {
                int employeeId = int.Parse(TextBoxID.Text);
                string startTime = TextBoxStartTime.Text;
                string endTime = TextBoxEndTime.Text;
                if(Mvm.AddDate(scheduleDate, startTime, endTime, employeeId, WorkFromHome))
                {
                    MessageBox.Show("Den nye dato er tilføjet");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Denne dato er optaget");
                }
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WFHCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            WorkFromHome = true;
        }

        private void AllEmpListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var emp = (AllEmpListBox.SelectedItem as ListBoxItem).Content;
            string SelEmployee = emp.ToString();
            foreach (EmployeeViewModel evm in Mvm.Evm)
            {
                if (evm.Name == SelEmployee)
                {
                    TextBoxID.Text = evm.EmployeeId.ToString();
                }
            }
        }
    }
}
