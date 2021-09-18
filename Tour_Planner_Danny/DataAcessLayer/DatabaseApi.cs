using Npgsql;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using Tour_Planner_Danny.Models;

namespace Tour_Planner_Danny.DataAcessLayer
{
    public static class DatabaseApi
    {


        static NpgsqlConnection Npgsql;
        static void makeConnection()
        {
            Npgsql = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionQuery"].ConnectionString);
            Npgsql.Open();
        }

        public static List<Tour> GetTours()
        {
            makeConnection();
            List<Tour> tours = Npgsql.Query<Tour>("SELECT * FROM public.\"Tour\" ").ToList();
            foreach (Tour tour in tours)
            {
                List<Log> logs = GetlogsofTour(tour.TourID);
                foreach (Log log in logs) tour.Logs.Add(log);
            }
            return tours;
        }

        public static List<Log> GetlogsofTour(int TourID)
        {
            makeConnection();
            return Npgsql.Query<Log>("SELECT * FROM public.\"Log\" WHERE \"TourID\"=" + TourID).ToList();
        }

    }
}
