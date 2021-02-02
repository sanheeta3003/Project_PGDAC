using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;
namespace DAL_RationTruckTracking
{
   public class DistributorsDBManager
    {
        public static readonly string connectionString = string.Empty;
        static DistributorsDBManager()
        {

            // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";
        }
        public static Distributors GetDistributorByUser(string user, double pass)
        {
            Distributors thisdistributor = new Distributors();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from distributors where distributor_name='" + user + "' and distributor_contact_number=" + pass + "";
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
                    //Distributors theDistributor = new Distributors();

                    thisdistributor.distributorID = int.Parse(row["distributorid"].ToString());
                    thisdistributor.distributorName = row["distributor_name"].ToString();
                    thisdistributor.distributorAddress = row["distributor_address"].ToString();
                    thisdistributor.distributorContactNumber = long.Parse(row["distributor_contact_number"].ToString());
                    //thisdistributor.CustomerList = int.Parse(row["DistributorList"].ToString());
                    

                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return thisdistributor;

        }
        public static List<Distributors> GetAllDistributor()
        {
            List<Distributors> listOfDistributors = new List<Distributors>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from distributors";
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
                    Distributors thedistributor = new Distributors();

                    thedistributor.distributorID = int.Parse(row["distributorid"].ToString());
                    thedistributor.distributorName = row["distributor_name"].ToString();
                    thedistributor.distributorAddress = row["distributor_address"].ToString();
                    thedistributor.distributorContactNumber = long.Parse(row["distributor_contact_number"].ToString());

                    listOfDistributors.Add(thedistributor);

                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return listOfDistributors;

        }
           public static void UpdateDistributor(long contactNumber,int DistributorID)
            {

                Console.WriteLine(contactNumber);


                string query = "update distributors set distributor_contact_number=" + contactNumber + " where distributorid=" + DistributorID + "";

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
            public static void InsertDistributor(string DistributorName, string DistributorAddress, long DistributorContactNum)
            {


                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                //String inq = "insert into Distributor values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

                string inq = "INSERT INTO distributors(distributor_address, distributor_contact_number, distributor_name) VALUES('" + DistributorAddress + "', " + DistributorContactNum + ",'" + DistributorName + "' )";

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


                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                conn.Close();

            }
            public static void DeleteDistributor(int DistributorID)
            {

                string delqury = "delete from distributors where distributorid=" + DistributorID + "";

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
        }
    }
