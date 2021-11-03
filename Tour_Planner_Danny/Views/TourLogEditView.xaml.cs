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
using Tour_Planner_Danny.Models;
using Tour_Planner_Danny.ViewModels;

namespace Tour_Planner_Danny.Views
{
    public partial class TourLogEditView : Window
    {
       
        public TourLogEditView(Log log,bool ISNew)
        {
            InitializeComponent();
            this.log = log;
            IsNew = ISNew;
            this.DataContext = new TourLogEditViewModel(log);         
            Toolbar();
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
        void Toolbar()
        {
            RateingTB.Text = log.Rating.ToString();
            AirPowTB.Text = log.AirPower.ToString();
            CadanceTB.Text = log.Cadence;
            DateTB.Text = log.Date;
            DistanceTB.Text = log.Distance;
            PosLatTB.Text = log.PositionLat;
            PosLonTB.Text = log.PositionLong;
            TempTB.Text = log.Temperature;
            TotalTimeTB.Text = log.TotalTime;
        }
        void MoveToolbar()
        {
            log.Rating=Convert.ToInt32(RateingTB.Text);
            log.AirPower=Convert.ToInt32(AirPowTB.Text);
            log.Cadence = CadanceTB.Text ;
            log.Date=DateTB.Text ;
            log.Distance = DistanceTB.Text ;
            log.PositionLat = PosLatTB.Text ;
            log.PositionLong = PosLonTB.Text ;
            log.Temperature = TempTB.Text ;
            log.TotalTime = TotalTimeTB.Text;
        }
        private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        Log log;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MoveToolbar();
            if (IsNew)
            {
                DataAcessLayer.DatabaseApi.InsertALog(log);
            }
            else
            {
                DataAcessLayer.DatabaseApi.UpdateALog(log);
            }
        }
        bool IsNew;
    }
}
