﻿using System;
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
    /// Interaction logic for DateScheduleWindow.xaml
    /// </summary>
    public partial class DateScheduleWindow : Window
    {

        EmployeeViewModel employeeViewModel = new EmployeeViewModel();

        public DateScheduleWindow()
        {
            InitializeComponent();
            for (int i = 0; i < employeeViewModel.employeeList.Count; i++)
            {
                //listBox.Items.Add(new ListBoxItem().Content = i);
                listBox.Items.Add(new ListBoxItem().Content = employeeViewModel.Name[i].ToString());
            }
        }

        //private void LoadLabel(Object sender, EventArgs e)
        //{
        //    for(int i = 0; i < mvm.Evm.Count; i++)
        //    {
        //        labels.Add(new Label() { Name = evm.Name[i].ToString() });
        //    }
        //}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}