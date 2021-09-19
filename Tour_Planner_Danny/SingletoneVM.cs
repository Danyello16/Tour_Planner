using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_Danny.ViewModels;

namespace Tour_Planner_Danny
{
    public class SingletoneVM
    {
        public TourViewModel ViewModel { get; set; }
        private static SingletoneVM instance = new SingletoneVM();

            private SingletoneVM() { }

            public static SingletoneVM getInstance()
            {
                return instance;
            }

    }
}
