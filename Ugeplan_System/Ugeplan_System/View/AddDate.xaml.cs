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
        private MainViewModel mvm;
        private string[] validFormats = {"d/M/yyyy"};
        public MainViewModel Mvm
        {
            get { return mvm; }
            set { mvm = value; }
        }

        public AddDate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mvm = new MainViewModel();
            string day = "Mandag";
            DateTime scheduleDate = Convert.ToDateTime(TextBoxScheduleDate.Text);
            string startTime = TextBoxStartTime.Text;
            string endTime = TextBoxEndTime.Text;
            int emplayeeId = int.Parse(TextBoxID.Text);
            Mvm.AddDate(day, scheduleDate, startTime, endTime, emplayeeId);
        }
    }
}
