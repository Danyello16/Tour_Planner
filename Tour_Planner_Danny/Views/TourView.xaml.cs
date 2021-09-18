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

namespace Tour_Planner_Danny.Views
{

    public partial class TourView : Window
    {
        public TourView()
        {
            InitializeComponent();
            Tourlistview.Items.Add("hi");
            lvLog.Items.Add("hi");
        }

        private void MouseDownPanel(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeBtn(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else this.WindowState = WindowState.Maximized;
        }

        private void MinimizeBTn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}