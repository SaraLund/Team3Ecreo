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

        public MainWindow()
        {
            Mvm = new MainViewModel();
            InitializeComponent();
        }

        private void WeekScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var WeekWindow = new WeekScheduleWindow(Mvm);
            WeekWindow.Show();
        }

        private void AddDateButton_Click(object sender, RoutedEventArgs e)
        {
            //var AddDateWindow = new AddDateWindow();
            //AddDateWindow.Show();
        }

        private void IdScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            //var IdWindow = new IdScheduleWindow();
            //IdWindow.Show();
        }
    }
}
