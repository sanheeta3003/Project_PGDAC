using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL_RationTruckTracking;
namespace BLL
{
   public class DistributorsBM
    {
       
            public static List<Distributors> GetAllDistributors()
            {
            List<Distributors> dlist = DistributorsDBManager.GetAllDistributor();
                return dlist;
            }
            public static Distributors GetDistributorByLogin(string uname, long contactNumber)
            {
                Distributors theDistributor = new Distributors();
               theDistributor = DistributorsDBManager.GetDistributorByUser(uname, contactNumber);
                return theDistributor;

            }
            public static void InsertDistributor(string distributorName,string distributorAddress, long distributorContactNumber)
            {
                DistributorsDBManager.InsertDistributor( distributorName, distributorAddress, distributorContactNumber);
                 
            }

            public static void UpdateDistributor(Distributors exitsDistributor)
            {
            DistributorsDBManager.UpdateDistributor(exitsDistributor.distributorContactNumber, exitsDistributor.distributorID);
            }
           public static void DeleteDistributor(int id)
            {
            DistributorsDBManager.DeleteDistributor(id);
            }

    }
    
}
