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

namespace Ugeplan_System.View
{
    /// <summary>
    /// Interaction logic for AddMeetingWindow.xaml
    /// </summary>
    public partial class AddMeetingWindow : Window
    {
        private bool online = false;
        public AddMeetingWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnlineCheck_Checked(object sender, RoutedEventArgs e)
        {
            online = true;
        }
    }
}
