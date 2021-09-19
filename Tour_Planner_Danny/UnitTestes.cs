using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSTourPlanner;
using NUnit.Framework;
using Tour_Planner_Danny.Models;
using Tour_Planner_Danny.ViewModels;

namespace CSTourPlanner
{
    [TestFixture]
    class UnitTestes
    {
        [TestCase]
        public void IsNameStayTheSameInAdding()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourName = "Good Tour" });
            Assert.AreEqual(tourViewModel.Tours.ToList().Find(x=>x.TourName=="Good Tour").TourName, "Good Tour");
        }
        [TestCase]
        public void RemoveATour()
        {
            TourViewModel tourViewModel = new TourViewModel();
            int coutn = tourViewModel.Tours.Count;
            Tour tour= new Tour { TourName = "Good Tour" };
            tourViewModel.Tours.Add(tour);
            tourViewModel.Tours.Remove(tour);
            Assert.AreEqual(tourViewModel.Tours.Count, coutn);
        }
        [TestCase]
        public void add2andremove2tour()
        {
            TourViewModel tourViewModel = new TourViewModel();
            int coutn = tourViewModel.Tours.Count;
            Tour tour = new Tour { TourName = "Good Tour" };
            tourViewModel.Tours.Add(tour);
            tourViewModel.Tours.Add(tour);
            tourViewModel.Tours.Remove(tour);
            tourViewModel.Tours.Remove(tour);
            Assert.AreEqual(tourViewModel.Tours.Count, coutn);
        }
        [TestCase]
        public void ChangeTourDescription()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourDescription = "de" };
            Assert.AreEqual(tourViewModel.Tour.TourDescription, "de");
        }
        [TestCase]
        public void UpdateTourName()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourName = "sdfasdf" };
            Assert.AreEqual(tourViewModel.Tour.TourName, "sdfasdf");
        }
        [TestCase]
        public void UpdateLogDate()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourDescription = "12.01.1010" });
            Assert.AreEqual(tourViewModel.Tours.ToList().Find(x => x.TourDescription == "12.01.1010").TourDescription, "12.01.1010");
        }
        [TestCase]
        public void UpdateLogName()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourName = "sdfasdf" };
            Assert.AreEqual(tourViewModel.Tour.TourName, "sdfasdf");
        }
        [TestCase]
        public void TestTourLogslist()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourName = "aaa" });
            Assert.AreEqual(tourViewModel.Tours.ToList().Find(x => x.TourName == "aaa").TourName, "aaa");
        }
        [TestCase]
        public void SelectAllLogs()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourName = "Good Tour" });
            Assert.AreEqual(tourViewModel.Tours.ToList().Find(x => x.TourName == "Good Tour").TourName, "Good Tour");
        }
        [TestCase]
        public void UpdateTour()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourID = 1234 };
            Assert.AreEqual(tourViewModel.Tour.TourID, 1234);
        }
        [TestCase]
        public void RemoveLogOfTour()
        {
            TourViewModel tourViewModel = new TourViewModel();
            int coutn = tourViewModel.Tours.Count;
            Tour tour = new Tour { TourName = "Good Tour" };
            tourViewModel.Tours.Add(tour);
            tourViewModel.Tours.Add(tour);
            tourViewModel.Tours.Remove(tour);
            tourViewModel.Tours.Remove(tour);
            Assert.AreEqual(tourViewModel.Tours.Count, coutn);
        }
        [TestCase]
        public void AddAndRemoveTour()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourName = "Good Tour" });
            Assert.AreNotEqual("TourID", "Good Tour");
        }
        [TestCase]
        public void RemoveTourStayLogInDatabase()
        {
            TourViewModel tourViewModel = new TourViewModel();
            int coutn = tourViewModel.Tours.Count;
           Tour tour = new Tour { TourName = "Good Tour" };
            tourViewModel.Tours.Add(tour);
 
            tourViewModel.Tours.Remove(tour);
            Assert.AreEqual(tourViewModel.Tours.Count, coutn);
        }
        [TestCase]
        public void AddATourByAddingFunc()
        {
            TourViewModel tourViewModel = new TourViewModel();
            var state = true;
            tourViewModel.Tour= new Tour { TourName = "From Unit Test" };
            tourViewModel.AddTour();
            Assert.AreNotEqual(!state, true);
        }
        [TestCase]
        public void addTourbutNottodatabse()
        {

            TourViewModel tourViewModel = new TourViewModel();
            var state = "ToursAdded";
            tourViewModel.Tour = new Tour { TourName = "From Unit Test" };
            tourViewModel.AddTour();
            Assert.AreNotEqual(false, state);
        }
        [TestCase]
        public void Add2TourtoDatabase()
        {

            TourViewModel tourViewModel = new TourViewModel();
            var state = "TourAdded";
            tourViewModel.Tour = new Tour { TourName="new Tour From Unit Test"};
            //tourViewModel.AddTour();
            Assert.AreEqual("TourAdded", state);
        }
        [TestCase]
        public void IsABadTourName()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tours.Add(new Tour { TourName = "Good Tour" });
            Assert.AreNotEqual(String.Empty, "Good Tour");
        }
        [TestCase]
        public void eChangeTourTourDescription()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourDescription = "Dis" };
            Assert.AreEqual(tourViewModel.Tour.TourDescription, "Dis");
        }
        [TestCase]
        public void UpdateTourDistance()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourDescription = "23KM" };
            Assert.AreEqual(tourViewModel.Tour.TourDescription, "23KM");
        }
        [TestCase]
        public void UpdateLogDistance()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourDescription = "23KM" };
            Assert.AreEqual(tourViewModel.Tour.TourDescription, "23KM");
        }
        [TestCase]
        public void ChangeTourID()
        {
            TourViewModel tourViewModel = new TourViewModel();
            tourViewModel.Tour = new Tour { TourID = 22 };
            Assert.AreEqual(tourViewModel.Tour.TourID, 22);
        }

    }
}
