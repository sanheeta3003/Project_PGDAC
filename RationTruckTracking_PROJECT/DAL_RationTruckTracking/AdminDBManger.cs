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
   public class AdminDBManger
    {
        
       
            public static readonly string connectionString = string.Empty;

            static AdminDBManger()
            {

                // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
                connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";

        }
        public static List<Admin> GetAllAdmin()
           {
                List<Admin> adminlist = new List<Admin>();

            Console.WriteLine("in fun");

                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                string qery = "select * from admin";
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
                        Admin theAdmin = new Admin();
                        theAdmin.adminId = int.Parse(row["admin_id"].ToString());
                        theAdmin.adminName = (row["emp_name"].ToString());
                        theAdmin.adminEmail = (row["emp_email"].ToString());
                        theAdmin.empID = (row["empid"].ToString());
                        adminlist.Add(theAdmin);
                    }
                Console.WriteLine("after for loop");
                
                }
                catch (MySqlException e)
                {
                    string message = e.Message;
                }
            
                 conn.Close();
            
            return adminlist;

            }
        public static void DeleteAdmin(int adminID)
        {

            string delqury = "delete from admin where admin_id=" + adminID + "";

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
        public static void InsertAdmin(string emp_email, string emp_name, string empid)
        {


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //String inq = "insert into customer values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

            string inq = "INSERT INTO admin(emp_email,emp_name, empid) VALUES('" + emp_email + "', '" + emp_name + "', '" + empid + "')";

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
        public static Admin GetAdminByIdEmail(string useremail, string passempId)
        {
            Admin thisAdmin = new Admin();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from admin where emp_email='" + useremail + "' and empid='" + passempId + "'";
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


                    thisAdmin.adminId = int.Parse(row["admin_id"].ToString());
                    thisAdmin.adminName = (row["emp_name"].ToString());
                    thisAdmin.adminEmail = (row["emp_email"].ToString());
                    thisAdmin.empID = (row["empid"].ToString());
                 


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return thisAdmin;

        }


    }
    }
