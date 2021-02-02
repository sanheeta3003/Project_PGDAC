using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using BOL;
namespace DAL_RationTruckTracking
{
    public class TrackingDBManager
    {
        public static readonly string connectionString = string.Empty;

        static TrackingDBManager()
        {

            // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";
        }
        public static List<TrackingDetails> GetAllTrackingDeatils()
        {
            List<TrackingDetails> trackListOfAllTrucks = new List<TrackingDetails>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from tracking_details;";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = qery;
            cmd.Connection = conn;

            MySqlDataAdapter ad = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();

            try
            {
                ad.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    TrackingDetails thisDetails = new TrackingDetails();

                    thisDetails.trackingId = int.Parse(row["tracking_id"].ToString());
                    thisDetails.TruckRegNo = (row["truck_reg_no"].ToString());
                    thisDetails.currentMessage = (row["current_message"].ToString());
                    thisDetails.destinationCity = (row["destination_city"].ToString());
                    thisDetails.dispatchedDateTime = DateTime.Parse(row["dispatched_date_time"].ToString());
                    thisDetails.estimatedArrivalDateTime = DateTime.Parse(row["estimated_arrival_date_time"].ToString());
                    thisDetails.sourceCity = (row["source_city"].ToString());
                    thisDetails.status = (Status)Enum.Parse(typeof(Status), row["status"].ToString());
                    trackListOfAllTrucks.Add(thisDetails);
                }


            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            conn.Close();

            return trackListOfAllTrucks;

        } 
        public static TrackingDetails GetTrackingByDestCity(string dcity)
        {
            TrackingDetails thisDetails = new TrackingDetails();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from tracking_details where destination_city ='" + dcity + "'";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = qery;
            cmd.Connection = conn;

            MySqlDataAdapter ad = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();

            try
            {
                ad.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {


                    thisDetails.trackingId = int.Parse(row["tracking_id"].ToString());
                    thisDetails.TruckRegNo = (row["truck_reg_no"].ToString());
                    thisDetails.currentMessage= (row["current_message"].ToString());
                    thisDetails.destinationCity = (row["destination_city"].ToString());
                    thisDetails.dispatchedDateTime = DateTime.Parse(row["dispatched_date_time"].ToString());
                    thisDetails.estimatedArrivalDateTime = DateTime.Parse(row["estimated_arrival_date_time"].ToString());
                    thisDetails.sourceCity = (row["source_city"].ToString());
                    thisDetails.status =(Status) Enum.Parse(typeof(Status), row["status"].ToString());



                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return thisDetails;

        }
        public static void InsertTrackindDetails(string truck_reg_no, string current_message, string destination_city, string dispatched_date_time,
                                                  string estimated_arrival_date_time, string source_city ,string status )
        {
            Console.WriteLine("in fun");
            Console.WriteLine(dispatched_date_time);
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //String inq = "insert into customer values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

            string inq = "INSERT INTO tracking_details(truck_reg_no,current_message, destination_city,dispatched_date_time,estimated_arrival_date_time,source_city,status) " +
                "VALUES('" + truck_reg_no + "', '" + current_message + "', '" + destination_city + "','" + dispatched_date_time + "','" + estimated_arrival_date_time + "', '" + source_city + "', '" + status + "' )";

            Console.WriteLine(inq);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(inq);
            cmd.Connection = conn;

            try
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine("Insertion is successfully completed......");
                }
                else
                {

                    Console.WriteLine("Insertion not done......");

                }
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();

        }
        public static void DeleteTruckTrackingDetails(int truckTrackID)
        {

            string delqury = "delete from tracking_details where tracking_id =" + truckTrackID + "";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(delqury);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine("Deleted Successfully.......");

                }
                else
                {

                    Console.WriteLine("Not deleted updated.......");

                }


            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {

                Console.WriteLine(e.Message);

            }
            conn.Close();

        }

        public static void UpdateTrackingtable(string current_message, string dispatched_date_time, string estimated_arrival_date_time , string status,int tracking_id)
        {

           


            string query = "update tracking_details set current_message ='" + current_message + "',dispatched_date_time ='" + dispatched_date_time + "',estimated_arrival_date_time ='" + estimated_arrival_date_time + "',status ='" + status + "' where tracking_id =" + tracking_id + "";

            

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine("Data Updated Successfully.......");

                }
                else
                {

                    Console.WriteLine("Data not updated.......");

                }


            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {

                Console.WriteLine(e.Message);

            }
            conn.Close();

        }

        public static TrackingDetails GetTrackingByID(int id)
        {
            TrackingDetails thisDetails = new TrackingDetails();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from tracking_details where tracking_id =" + id + "";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = qery;
            cmd.Connection = conn;

            MySqlDataAdapter ad = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();

            try
            {
                ad.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {


                    thisDetails.trackingId = int.Parse(row["tracking_id"].ToString());
                    thisDetails.TruckRegNo = (row["truck_reg_no"].ToString());
                    thisDetails.currentMessage = (row["current_message"].ToString());
                    thisDetails.destinationCity = (row["destination_city"].ToString());
                    thisDetails.dispatchedDateTime = DateTime.Parse(row["dispatched_date_time"].ToString());
                    thisDetails.estimatedArrivalDateTime = DateTime.Parse(row["estimated_arrival_date_time"].ToString());
                    thisDetails.sourceCity = (row["source_city"].ToString());
                    thisDetails.status = (Status)Enum.Parse(typeof(Status), row["status"].ToString());



                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return thisDetails;

        }
    }
}
