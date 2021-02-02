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
    public class RationDBManager
    {
        public static readonly string connectionString = string.Empty;

        static  RationDBManager()
        {

            // connectionString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            connectionString = "server=localhost;port=3306;uid=root;password='root';database=cdac_project";
        }
        public static List<Ration> GetAllRation()
        {
            List<Ration> rationList = new List<Ration>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from ration";
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
                    Ration theGoods = new Ration();
                    theGoods.goodsId = int.Parse(row["goods_id"].ToString());
                    theGoods.goodsName = row["goods_name"].ToString();
                    theGoods.goodsCost = int.Parse(row["goods_cost"].ToString());
                    theGoods.goodsQuantity = int.Parse(row["goods_quantity"].ToString());
                    rationList.Add(theGoods);


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            conn.Close();

            return rationList;

        }


        public static void UpdateRation( int goodsCost,int goodsQuantity,int goodsId)
        {

           

            string query = "update ration set goods_cost=" + goodsCost + " , goods_quantity=" + goodsQuantity + " where goods_id=" + goodsId + "";

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

        public static void DeleteRation(int goodsID)
        {

            string delqury = "delete from ration where goods_id=" + goodsID + "";

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

        public static void InsertRation(string goodsName,int goodsCost,int goodsQuantity)
        {


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            //String inq = "insert into customer values(" + id + ",'" + ttl + "','" + desc + "'," + up + "," + qtny + ")";

            string inq = "INSERT INTO ration(goods_name,goods_cost, goods_quantity) VALUES('" + goodsName + "', " + goodsCost + ", " + goodsQuantity + ")";

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

        public static Ration GetRationByID(int id)
        {
            Ration theGoods = new Ration();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            string qery = "select * from ration where goods_id =" + id + "";
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


                    theGoods.goodsId = int.Parse(row["goods_id"].ToString());
                    theGoods.goodsName = row["goods_name"].ToString();
                    theGoods.goodsCost = int.Parse(row["goods_cost"].ToString());
                    theGoods.goodsQuantity = int.Parse(row["goods_quantity"].ToString());


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return theGoods;

        }
    }
}
