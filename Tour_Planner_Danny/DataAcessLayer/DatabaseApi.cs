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
            if (Npgsql.State != ConnectionState.Open)
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
            Npgsql.Close();
            return tours;
        }
        public static void DeleteTour(Tour tour)
        {      
            makeConnection();

            string sql = "DELETE FROM public.\"Tour\" WHERE \"TourID\"=@TourID";
            var cmd = new NpgsqlCommand(sql, Npgsql);

            cmd.Parameters.AddWithValue("TourID",tour.TourID);
     
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Npgsql.Close();
        }

        public static void InsertATour(Tour tour)
        {
            if (tour.TourName == null || tour.TourDescription == null|| tour.Route == null || tour.Distance== null)
            {
                System.Windows.MessageBox.Show("Tour has empty properties,Database Operation failed.");
            }
            else { 
                makeConnection();
        
        
            string sql= "INSERT INTO public.\"Tour\"(\"TourID\", \"TourName\", \"TourDescription\", \"Route\", \"Distance\") VALUES (@TourID, @TourName, @TourDescription, @Route, @Distance);";

         
            var cmd = new NpgsqlCommand(sql, Npgsql);

            cmd.Parameters.AddWithValue("TourID", new Random().Next(0, 10000));
            cmd.Parameters.AddWithValue("TourName", tour.TourName);
            cmd.Parameters.AddWithValue("TourDescription", tour.TourDescription);
            cmd.Parameters.AddWithValue("Route", tour.Route);
            cmd.Parameters.AddWithValue("Distance", tour.Distance);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Npgsql.Close();
            }
        }

        public static void UpdateATour(Tour tour)
        {
 
            if (tour.TourName == null || tour.TourDescription == null || tour.Route == null || tour.Distance == null)
            {
                System.Windows.MessageBox.Show("Tour has empty properties,Database Operation failed.");
            }
            else
            {
                makeConnection();

                string sql = "UPDATE public.\"Tour\" SET \"TourName\"=@TourName, \"TourDescription\"=@TourDescription, \"Route\"=@Route, \"Distance\"=@Distance WHERE \"TourID\"=@TourID";
                var cmd = new NpgsqlCommand(sql, Npgsql);

                cmd.Parameters.AddWithValue("TourName", tour.TourName);
                cmd.Parameters.AddWithValue("TourDescription", tour.TourDescription);
                cmd.Parameters.AddWithValue("Route", tour.Route);
                cmd.Parameters.AddWithValue("Distance", tour.Distance);
                cmd.Parameters.AddWithValue("TourID", tour.TourID);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Npgsql.Close();
            }
        }

        public static List<Log> GetlogsofTour(int TourID)
        {
            makeConnection();
            return Npgsql.Query<Log>("SELECT * FROM public.\"Log\" WHERE \"TourID\"=" + TourID).ToList();
        }

        public static void InsertALog(Log selectedLog)
        {
            selectedLog.LogID = new Random().Next(0, 10000);
            if (typeof(Log).GetProperties().Any(propertyInfo => propertyInfo.GetValue(selectedLog).ToString() == string.Empty))
            {
                System.Windows.MessageBox.Show("Log has empty properties,Database Operation failed.");
            }
            else
            {
                makeConnection();


                string sql = "INSERT INTO public.\"Log\"(\"LogID\", \"TourID\", \"Rating\", \"TotalTime\", \"Date\", \"Distance\", \"Temperature\", \"Cadence\", \"PositionLong\", \"PositionLat\", \"AirPower\") VALUES (@LogID, @TourID, @Rating, @TotalTime, @Date, @Distance, @Temperature, @Cadence, @PositionLong, @PositionLat, @AirPower);";


                var cmd = new NpgsqlCommand(sql, Npgsql);

                cmd.Parameters.AddWithValue("LogID", selectedLog.LogID);
                cmd.Parameters.AddWithValue("TourID", selectedLog.TourID);
                cmd.Parameters.AddWithValue("Rating", selectedLog.Rating);
                cmd.Parameters.AddWithValue("TotalTime", selectedLog.TotalTime);
                cmd.Parameters.AddWithValue("Date", selectedLog.Date);
                cmd.Parameters.AddWithValue("Distance", selectedLog.Distance);
                cmd.Parameters.AddWithValue("Temperature", selectedLog.Temperature);
                cmd.Parameters.AddWithValue("Cadence", selectedLog.Cadence);
                cmd.Parameters.AddWithValue("PositionLong", selectedLog.PositionLong);
                cmd.Parameters.AddWithValue("PositionLat", selectedLog.PositionLat);
                cmd.Parameters.AddWithValue("AirPower", selectedLog.AirPower);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Npgsql.Close();
            }
        }

        public static void DeleteLog(Log selectedLog)
        {
            if (selectedLog != null) {
            makeConnection();

            string sql = "DELETE FROM public.\"Log\" WHERE \"LogID\"=@LogID";
            var cmd = new NpgsqlCommand(sql, Npgsql);

            cmd.Parameters.AddWithValue("LogID", selectedLog.LogID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Npgsql.Close();
            }
        }

        public static void UpdateALog(Log selectedLog)
        {
            if (typeof(Log).GetProperties().Any(propertyInfo => propertyInfo.GetValue(selectedLog).ToString() == string.Empty))
            {
                System.Windows.MessageBox.Show("Log has empty properties,Database Operation failed.");
            }
            else
            {
                makeConnection();

                string sql= "UPDATE public.\"Log\" SET \"TourID\"=@TourID, \"Rating\"=@Rating, \"TotalTime\"=@TotalTime, \"Date\"=@Date, \"Distance\"=@Distance, \"Temperature\"=@Temperature, \"Cadence\"=@Cadence, \"PositionLong\"=@PositionLong, \"PositionLat\"=@PositionLat, \"AirPower\"=@AirPower WHERE \"LogID\"=@LogID";

                var cmd = new NpgsqlCommand(sql, Npgsql);
 
                cmd.Parameters.AddWithValue("TourID", selectedLog.TourID);
                cmd.Parameters.AddWithValue("Rating", selectedLog.Rating);
                cmd.Parameters.AddWithValue("TotalTime", selectedLog.TotalTime);
                cmd.Parameters.AddWithValue("Date", selectedLog.Date);
                cmd.Parameters.AddWithValue("Distance", selectedLog.Distance);
                cmd.Parameters.AddWithValue("Temperature", selectedLog.Temperature);
                cmd.Parameters.AddWithValue("Cadence", selectedLog.Cadence);
                cmd.Parameters.AddWithValue("PositionLong", selectedLog.PositionLong);
                cmd.Parameters.AddWithValue("PositionLat", selectedLog.PositionLat);
                cmd.Parameters.AddWithValue("AirPower", selectedLog.AirPower);
                cmd.Parameters.AddWithValue("LogID", selectedLog.LogID);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Npgsql.Close();
            }
        }
    }
}
