using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Tour_Planner_Danny.Models
{
    public class Tour
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public string TourDescription { get; set; }
        public string Route { get; set; }
        public string Distance { get; set; }
        public ObservableCollection<Log> Logs { get; set; }
        public Tour()
        {
            Logs = new ObservableCollection<Log>();
        }
    }
}
