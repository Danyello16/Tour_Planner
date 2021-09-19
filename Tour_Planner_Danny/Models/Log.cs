using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner_Danny.Models
{
    public class Log : INotifyPropertyChanged
    {
        private int _LogID;

        public int LogID
        {
            get { return _LogID; }
            set { _LogID = value; OnPropertyChanged("LogID"); }
        }

        private int _TourID;

        public int TourID
        {
            get { return _TourID; }
            set { _TourID = value; OnPropertyChanged("TourID"); }
        }

        private int _Rating;

        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; OnPropertyChanged("Rating"); }
        }

        private string _TotalTime;

        public string TotalTime
        {
            get { return _TotalTime; }
            set { _TotalTime = value; OnPropertyChanged("TotalTime"); }
        }

        private string _Date;

        public string Date
        {
            get { return _Date; }
            set { _Date = value; OnPropertyChanged("Date"); }
        }

        private string _Distance;

        public string Distance
        {
            get { return _Distance; }
            set { _Distance = value; OnPropertyChanged("Distance"); }
        }


        private string _Temperature;

        public string Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; OnPropertyChanged("Temperature"); }
        }
        private string _Cadence;

        public string Cadence
        {
            get { return _Cadence; }
            set { _Cadence = value; OnPropertyChanged("Cadence"); }
        }

        private string _PositionLong;

        public string PositionLong
        {
            get { return _PositionLong; }
            set { _PositionLong = value; OnPropertyChanged("PositionLong"); }
        }

        private string _PositionLat;

        public string PositionLat
        {
            get { return _PositionLat; }
            set { _PositionLat = value; OnPropertyChanged("PositionLat"); }
        }
        private int _AirPower;

        public int AirPower
        {
            get { return _AirPower; }
            set { _AirPower = value; OnPropertyChanged("AirPower"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) ph(this, new PropertyChangedEventArgs(p));
        }
    }
}
