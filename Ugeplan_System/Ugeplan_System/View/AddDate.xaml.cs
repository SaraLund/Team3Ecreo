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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime scheduleDate = Convert.ToDateTime(TextBoxScheduleDate.Text);
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

        private void TextBoxScheduleDate_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxScheduleDate.Text = "";
        }

        private void TextBoxScheduleDate_LostFocus(object sender, RoutedEventArgs e)
        {
            if(TextBoxScheduleDate.Text == "")
            {
                TextBoxScheduleDate.Text = "YYYY/MM/DD";
            }
        }
    }
}
