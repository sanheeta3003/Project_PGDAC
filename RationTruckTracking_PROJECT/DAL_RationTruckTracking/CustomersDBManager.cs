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
    public class CustomersDBManager
    {
        public static readonly string connectionString = string.Empty;

        static CustomersDBManager()
        {

            // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";
        }
        public static List<Customers> GetAllCustomers()
        {
            List<Customers> clist = new List<Customers>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from customers";
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
                    Customers thecustomer = new Customers();

                    thecustomer.customerId = int.Parse(row["customer_id"].ToString());
                    thecustomer.customerName = row["customer_name"].ToString();
                    thecustomer.customerContactNumber = long.Parse(row["customer_contact_number"].ToString());
                    thecustomer.customerAddress = row["customer_address"].ToString();
                    thecustomer.distributor = (Distributors)(row["distributorid"]);
                    thecustomer.RationCardNumber = (row["ration_card_number"].ToString());
                    clist.Add(thecustomer);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }



            return clist;

        }

        public static Customers GetCustomerByUnameAndRationNum(string uname, string rationNumber)
        {
            Customers thisCustomer = new Customers();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from customers where customer_name='" + uname + "' and ration_card_number='" + rationNumber + "'";
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


                    thisCustomer.customerId = int.Parse(row["customer_id"].ToString());
                    thisCustomer.customerName = row["customer_name"].ToString();
                    thisCustomer.customerContactNumber = long.Parse(row["customer_contact_number"].ToString());
                    thisCustomer.customerAddress = row["customer_address"].ToString();
                    //thisCustomer.distributor = (Distributors)(row["distributorid"]);
                    thisCustomer.RationCardNumber = row["ration_card_number"].ToString();

                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }



            return thisCustomer;

        }

        public static void UpdateCustomer(long contactNumber, string customerAddress, int customerID)
        {



            string query = "update customers set customer_contact_number=" + contactNumber + " , customer_address='" + customerAddress + "' where customer_id=" + customerID + "";

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

        public static void DeleteCustomer(int customerID)
        {

            string delqury = "delete from customers where customer_id=" + customerID + "";

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

        public static void InsertCustomer(string customerName, string customerAddress, long customerContactNum, string rationNumber)
        {


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //String inq = "insert into customer values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

            string inq = "INSERT INTO customers(ration_card_number, customer_address,  customer_contact_number, customer_name) VALUES('" + rationNumber + "', '" + customerAddress + "', " + customerContactNum + ", '" + customerName + "')";

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
                
    
