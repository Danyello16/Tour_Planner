using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tour_Planner_Danny.Models;
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

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.Tour.TourName);
        }
        TourViewModel vm;
        BitmapSource LoadImage(Byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                return decoder.Frames[0];
            }
        }


        private void Tourlistview_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tourlistview.SelectedItem = null;
        }
        
        private void MapButton(object sender, RoutedEventArgs e)
        {
           
                if (tbRoute.Text != string.Empty)
                {

                    try
                    {
                        string apiLink = "https://www.mapquestapi.com/staticmap/v5/map?key=ENC6vtgWXGlFY0zvJoevS5Ek2XN5Kmkc&center=" + tbRoute.Text.Replace(' ', '+') + "&zoom=11&type=hyb&size=600,400@2x";
                        if (tbRoute.Text.Contains("-"))
                        {
                            string start = "", stop = "";

                            string route = tbRoute.Text.Replace(' ', '+');


                            string[] Routesplited = route.Split('-');

                            start = Routesplited[0];
                            stop = Routesplited[1];


                            apiLink = "https://www.mapquestapi.com/staticmap/v5/map?start=" + start + "&end=" + stop + "&size=@2x&key=ENC6vtgWXGlFY0zvJoevS5Ek2XN5Kmkc&type=hyb";
                        }

                   
                    mapImage.Source = LoadImage(new WebClient().DownloadData(apiLink));
                    }
                    catch
                    {
                        MessageBox.Show("Could not download the Map...");
                    }

                }
           
        }
        private void AddLog(object sender, RoutedEventArgs e)
        {
            var log = new Models.Log();
            if (Tourlistview.SelectedIndex != -1)
                log.TourID = DataAcessLayer.DatabaseApi.GetTours()[Tourlistview.SelectedIndex].TourID;
            new TourLogEditView(log, true).ShowDialog();
            lvLog.ItemsSource = DataAcessLayer.DatabaseApi.GetlogsofTour(DataAcessLayer.DatabaseApi.GetTours()[Tourlistview.SelectedIndex].TourID);
        }
        private void UpLog(object sender, RoutedEventArgs e)
        {
            if (lvLog.SelectedIndex > -1 && Tourlistview.SelectedIndex != -1){ 
           
            new TourLogEditView(DataAcessLayer.DatabaseApi.GetlogsofTour(DataAcessLayer.DatabaseApi.GetTours()[Tourlistview.SelectedIndex].TourID)[lvLog.SelectedIndex], false).ShowDialog();           
                lvLog.ItemsSource = DataAcessLayer.DatabaseApi.GetlogsofTour(DataAcessLayer.DatabaseApi.GetTours()[Tourlistview.SelectedIndex].TourID);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Tourlistview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                if (Tourlistview.SelectedIndex != -1)
                    lvLog.ItemsSource = DataAcessLayer.DatabaseApi.GetlogsofTour(DataAcessLayer.DatabaseApi.GetTours()[Tourlistview.SelectedIndex].TourID);
            }
            catch
            {

            }
        }

        private void SearchBarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Tour> AllTours =  DataAcessLayer.DatabaseApi.GetTours();
          //  Tourlistview.Items.Clear();
            if (SearchBarTextBox.Text == string.Empty)
            {
                Tourlistview.ItemsSource = AllTours;
            }
            else
            {
                Tourlistview.ItemsSource = AllTours.FindAll(x=>x.TourName.ToLower().StartsWith(SearchBarTextBox.Text.ToLower()));

            }
        }
    }
}
