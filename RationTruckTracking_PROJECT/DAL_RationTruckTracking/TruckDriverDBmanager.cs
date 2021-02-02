using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;
namespace DAL_RationTruckTracking
{
    public class TruckDriverDBmanager
    {
             public static readonly string connectionString = string.Empty;

          static TruckDriverDBmanager()
          {

            // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";
        }
            public static List<TruckDriverDetails> GetAllTruckDriverDetails()
            {
                List<TruckDriverDetails> clist = new List<TruckDriverDetails>();

                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                string qery = "select * from truck_driver_details";
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
                        TruckDriverDetails thetruckdriverdetails = new TruckDriverDetails();

                        thetruckdriverdetails.truckId = int.Parse(row["truck_id"].ToString());
                        thetruckdriverdetails.truckDriverName = row["truck_driver_name"].ToString();
                        thetruckdriverdetails.DriverContactNumber = long.Parse(row["driver_contact_number"].ToString());
                        thetruckdriverdetails.truckRegnoNumber = row["truck_reg_num"].ToString();

                        clist.Add(thetruckdriverdetails);
                    }
                }
                catch (MySqlException e)
                {
                    string message = e.Message;
                }



                return clist;

            }


            public static void UpdateTruckDriverDetails(long DriverContactNumber, int truckId)
            {

           

                string query = "update truck_driver_details set driver_contact_number=" + DriverContactNumber + " where truck_id=" + truckId + "";

                Console.WriteLine(query);

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

            public static void DeleteTruckDriverDetails(int truckId)
            {

                string delqury = "delete from truck_driver_details where truck_id=" + truckId + "";

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

            public static void InsertTruckDriverDetails( string truckDriverName, string truckRegnoNumber,long DriverContactNumber)
            {


                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //String inq = "insert into customer values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

            string inq = "INSERT INTO truck_driver_details ( driver_contact_number, truck_driver_name,truck_reg_num) VALUES(" + DriverContactNumber + ", '" + truckDriverName + "', '" + truckRegnoNumber + "')";

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


        }
    }
    

}
  