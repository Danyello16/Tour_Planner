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
using Tour_Planner_Danny.ViewModels;

namespace Tour_Planner_Danny.Views
{

    public partial class TourView : Window
    {
        public TourView()
        {
            InitializeComponent();

             vm = new TourViewModel();
             this.DataContext = vm;
            SingletoneVM singletoneVM = SingletoneVM.getInstance();
            singletoneVM.ViewModel = vm;
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

        private void AddLog(object sender, RoutedEventArgs e)
        {
            new TourLogEditView(vm.SelectedLog).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.Tour.TourName);
        }
        TourViewModel vm;

      

        private void Tourlistview_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tourlistview.SelectedItem = null;
        }
    }
}
