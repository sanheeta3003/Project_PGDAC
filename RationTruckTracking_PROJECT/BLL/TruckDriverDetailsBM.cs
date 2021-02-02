using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL_RationTruckTracking;
namespace BLL
{
    public class TruckDriverDetailsBM
    {
            public static List<TruckDriverDetails> GetAllTruckDriverDetails()
            {
                List<TruckDriverDetails> tlist = TruckDriverDBmanager.GetAllTruckDriverDetails();
                return tlist;
            }
            
            public static void InsertTruckDriverDetails(string name, string regNo, long mobNo)
        {
            TruckDriverDBmanager.InsertTruckDriverDetails(name, regNo, mobNo);
        
            }
            public static void UpdateTruckDriverDetails(TruckDriverDetails exitsTruckDriverDetails)
            {
            TruckDriverDBmanager.UpdateTruckDriverDetails(exitsTruckDriverDetails.DriverContactNumber, exitsTruckDriverDetails.truckId);
            }
            public static void DeleteTruckDriver(int driverId)
        {
            TruckDriverDBmanager.DeleteTruckDriverDetails(driverId);
        }

    }
    }
