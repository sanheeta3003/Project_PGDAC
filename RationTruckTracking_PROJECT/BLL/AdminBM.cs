using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL_RationTruckTracking;
namespace BLL
{
   public class AdminBM
    {

        public static List<Admin> GetAllAdmin()
        {
            List<Admin> clist = AdminDBManger.GetAllAdmin();
            return clist;
        }
        public static Admin GetAdminByLogin(string emailid, string empid)
        {
            Admin theAdmin = new Admin();
            theAdmin = AdminDBManger.GetAdminByIdEmail(emailid, empid);
            return theAdmin;

        }
        public static void InsertAdmin( string email, string aname, string empid)
        {
            AdminDBManger.InsertAdmin( email, aname, empid);

        }

        public static void DeleteAdmin(int diId)
        {
            AdminDBManger.DeleteAdmin(diId);
        }
    }
}