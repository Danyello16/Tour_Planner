using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_Danny.Models;

namespace Tour_Planner_Danny.ViewModels
{
    public class TourLogEditViewModel : INotifyPropertyChanged
    {
        public Log SelectedLog { get; set; }
        private Log _SelectedLog;

        public Log sSelectedLog
        {
            get { return _SelectedLog; }
            set { _SelectedLog = value; NotifyPropertyChanged("SelectedLog");

            }
        }
        
        public TourLogEditViewModel(Log log)
        {
            SingletoneVM singletoneVM;
            singletoneVM = SingletoneVM.getInstance();

            SelectedLog = singletoneVM.ViewModel.SelectedLog;
            SelectedLog = log;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
