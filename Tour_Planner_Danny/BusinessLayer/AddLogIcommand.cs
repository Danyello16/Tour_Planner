using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner_Danny.ViewModels;

namespace Tour_Planner_Danny.BusinessLayer
{

    internal class AddLogIcommand : ICommand
    {
        private TourViewModel _TourViewModel;

        public AddLogIcommand(TourViewModel mainViewModel)
        {
            _TourViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _TourViewModel.AddLog();
        }
    }
}
