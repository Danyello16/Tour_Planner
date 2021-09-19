using iTextSharp.text;
using iTextSharp.text.pdf;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public TourViewModel()
        {           
            Tour = new Tour();
            SelectedLog = new Log();
            Tours = new ObservableCollection<Tour>();
            log.Info("data got from database...");
            foreach(Tour t in DataAcessLayer.DatabaseApi.GetTours())
            {
                Tours.Add(t);
            }
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
              ///  DataAcessLayer.DatabaseApi.InsertTour(CurrentTour, Tours.Count + 1); inser to database implament latter on inserting ***
            }
            else System.Windows.MessageBox.Show("File does not exist at " + path);
        }
        public void AddTour()
        {
            Tours.Add(Tour);
        }
        public void DelTour()
        {
            DataAcessLayer.DatabaseApi.DeleteTour(tour);
            Tours.Remove(tour);
         
        }
        public void EditTour()
        {

        }
        public void AddLog()
        {
            DataAcessLayer.DatabaseApi.InsertATour(Tour);
            tour.Logs.Add(SelectedLog);       
        }
        public void DelLog()
        {
            tour.Logs.Remove(SelectedLog);
        }
        public void EditLog()
        {

        }
        public void ReportAsPdf()
        {
          
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Report.pdf";
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
            document.Open();

            foreach (Tour t in Tours)
            {
                Paragraph elements = new Paragraph("Tour Name: " + t.TourName + "\tRoute: " + t.Route + "\tDistance: " + t.Distance + "\tDescription: " + t.TourDescription + "\nTour logs:\n");
                foreach (Log l in t.Logs)
                {
                    elements.Add(new Paragraph("Log Date: " + l.Date + "\tLog PositionLat: " + l.PositionLat + "\tPositionLong " + l.PositionLong));
                }
                document.Add(elements);
            }



            document.Close();
            System.Windows.MessageBox.Show("Report has been Saved As " + path);
         
        }
        public void SearchText()
        {

        }

    }
}
