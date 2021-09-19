using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tour_Planner_Danny.Models
{
    public class Tour:INotifyPropertyChanged 
    {

        private int tourID;
        public int TourID
        {
            get { return tourID; }
            set { tourID = value; OnPropertyChanged("TourID"); }
        }

        private string tourName;
        public string TourName
        {
            get { return tourName; }
            set { tourName = value; OnPropertyChanged("TourName"); }
        }

        private string tourDescription;
        public string TourDescription
        {
            get { return tourDescription; }
            set { tourDescription = value; OnPropertyChanged("TourDescription"); }
        }

        private string route;
        public string Route
        {
            get { return route; }
            set { route = value; OnPropertyChanged("Route"); }
        }

        private string distance;
        public string Distance
        {
            get { return distance; }
            set { distance = value; OnPropertyChanged("Distance"); }
        }
        private ObservableCollection<Log> _Logs;
        public ObservableCollection<Log> Logs
        {
            get { return _Logs; }
            set { _Logs = value; OnPropertyChanged("Logs"); }
        }
       
        public Tour()
        {
            Logs = new ObservableCollection<Log>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) ph(this, new PropertyChangedEventArgs(p));
        }
    }
}
