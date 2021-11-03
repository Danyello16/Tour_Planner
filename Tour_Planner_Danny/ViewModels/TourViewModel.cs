using iTextSharp.text;
using iTextSharp.text.pdf;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tour_Planner_Danny.BusinessLayer;
using Tour_Planner_Danny.Models;

namespace Tour_Planner_Danny.ViewModels
{
    public class TourViewModel : INotifyPropertyChanged
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ICommand AddTourCommand { get; set; }
        public ICommand SaveTourAsFileCommand { get; set; }
        public ICommand LoadTourAsFileCommand { get; set; }
        public ICommand DelTourCommand { get; set; }
        public ICommand EditTourCommand { get; set; }
        public ICommand AddLogCommand { get; set; }
        public ICommand SearchTextCommand { get; set; }
        public ICommand ReportAsPdfCommand { get; set; }
        public ICommand EditLogCommand { get; set; }
        public ICommand DelLogCommand { get; set; }

        void ReaLoadTours()
        {
            Tours = new ObservableCollection<Tour>();
            foreach (Tour t in DataAcessLayer.DatabaseApi.GetTours())
            {
                Tours.Add(t);
            }
        }

        public TourViewModel()
        {           
            Tour = new Tour();
            SelectedLog = new Log();
            Tours = new ObservableCollection<Tour>();
            log.Info("data got from database...");
            ReaLoadTours();
            log.Info("tour created..");
            log.Error("example Error Log...");
            AddTourCommand = new AddTourIcommand(this);
            SaveTourAsFileCommand = new SaveTourIcommand(this);
            LoadTourAsFileCommand = new LoadTourIcommand(this);
            DelTourCommand = new DelTourIcommand(this);
            EditTourCommand = new EditTourIcommand(this);
            AddLogCommand = new AddLogIcommand(this);
            SearchTextCommand = new SearchTextIcommand(this);
            ReportAsPdfCommand = new ReportTourIcommand(this);
            EditLogCommand = new EditLogIcommand(this);
            DelLogCommand = new DelLogIcommand(this);
        }
        private Log _SelectedLog;

        public Log SelectedLog
        {
            get { return _SelectedLog; }
            set { _SelectedLog = value; NotifyPropertyChanged("SelectedLog"); }
        }

        private Tour tour;
        public Tour Tour
        {
            get { return tour; }
            set { tour = value; NotifyPropertyChanged("Tour"); }
        }

        private ObservableCollection<Tour> tours;

        public ObservableCollection<Tour> Tours
        {
            get { return tours; }
            set { tours = value; NotifyPropertyChanged("Tours"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
       
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    


        public void SaveTourAsFile()
        {
            if (tour != null)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\SaveTourFile.txt";

                System.Windows.MessageBox.Show("Tour " + Tour.TourName + " Saved at: " + path);
                File.WriteAllText(path, JsonConvert.SerializeObject(Tour));
            }
            else System.Windows.MessageBox.Show("No tour is Selected...");
        }
        public void LoadTourAsFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\SaveTourFile.txt";
            if (File.Exists(path))
            {
                System.Windows.MessageBox.Show("Tour " + tour.TourName + " Loded from: " + path);

                Tour LoadedTour = JsonConvert.DeserializeObject<Tour>(File.ReadAllText(path));

                Tours.Add(LoadedTour);
                tour = LoadedTour;
                DataAcessLayer.DatabaseApi.InsertATour(LoadedTour);
                tours.Clear();
                ReaLoadTours();
            }
            else System.Windows.MessageBox.Show("File does not exist at " + path);
        }
        public void AddTour()
        {
           // Tours.Add(Tour);
            DataAcessLayer.DatabaseApi.InsertATour(Tour);
            tours.Clear();
            ReaLoadTours();
        }
        public void DelTour()
        {
            DataAcessLayer.DatabaseApi.DeleteTour(tour);
            Tours.Remove(tour);
         
        }
        public void EditTour()
        {
            DataAcessLayer.DatabaseApi.UpdateATour(tour);
            tours.Clear();
            ReaLoadTours();
        }
        public void AddLog()
        {
            //SelectedLog.TourID = tour.TourID;
            //DataAcessLayer.DatabaseApi.InsertALog(SelectedLog);
            //tours.Clear();
            //ReaLoadTours();           
        }
        public void DelLog()
        {
           DataAcessLayer.DatabaseApi.DeleteLog(SelectedLog);
           tour.Logs.Remove(SelectedLog);
        }
        public void EditLog()
        {
            //DataAcessLayer.DatabaseApi.UpdateALog(SelectedLog);
            //tours.Clear();
            //ReaLoadTours();
        }
        byte[] ImageByte(string Route)
        {
            
                    string apiLink = "https://www.mapquestapi.com/staticmap/v5/map?key=ENC6vtgWXGlFY0zvJoevS5Ek2XN5Kmkc&center=" + Route.Replace(' ', '+') + "&zoom=11&type=hyb&size=600,400@2x";
                    if (Route.Contains("-"))
                    {
                        string start = "", stop = "";

                        string route = Route.Replace(' ', '+');


                        string[] Routesplited = route.Split('-');

                        start = Routesplited[0];
                        stop = Routesplited[1];


                        apiLink = "https://www.mapquestapi.com/staticmap/v5/map?start=" + start + "&end=" + stop + "&size=@2x&key=ENC6vtgWXGlFY0zvJoevS5Ek2XN5Kmkc&type=hyb";
                    }

            return new WebClient().DownloadData(apiLink);
        }
        public void ReportAsPdf()
        {
            
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Report.pdf";
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
                document.Open();

                foreach (Tour t in Tours)
                {
                    Paragraph elements = new Paragraph("Tour Name: " + t.TourName + "\tRoute: " + t.Route + "\tDistance: " + t.Distance + "\tDescription: " + t.TourDescription + "\nTour logs:\n");
                    iTextSharp.text.Image ItextImage = iTextSharp.text.Image.GetInstance(ImageByte(t.Route));
                    ItextImage.Alignment = Element.ALIGN_CENTER;
                    elements.Add(ItextImage);
                    foreach (Log l in t.Logs)
                    {
                        elements.Add(new Paragraph("Log Date: " + l.Date + "\tLog PositionLat: " + l.PositionLat + "\tPositionLong " + l.PositionLong));
                    }
                    document.Add(elements);
                }



                document.Close();
                System.Windows.MessageBox.Show("Report has been Saved As " + path);
            } catch { }
          
         
        }
        public void SearchText()
        {
            System.Windows.MessageBox.Show("implment the search :D");
        }

    }
}
