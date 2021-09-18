using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner_Danny.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public int TourID { get; set; }  
        
        public int Rating { get; set; }
        public string TotalTime { get; set; }
        public string Date { get; set; }
        public string Distance { get; set; }

        public string Temperature { get; set; }
        public string Cadence { get; set; }
        public string PositionLong { get; set; }
        public string PositionLat { get; set; }
        public string AirPower { get; set; }
    }
}
