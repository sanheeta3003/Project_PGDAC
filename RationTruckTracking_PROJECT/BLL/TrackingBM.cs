using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL_RationTruckTracking;
namespace BLL
{
    public class TrackingBM
    {
       
            public static List<TrackingDetails> GetAllTrackingDetails()
            {
            List<TrackingDetails> tlist = TrackingDBManager.GetAllTrackingDeatils();
                return tlist;
            }
          
           public static void InsertTrackingDetails(string TruckRegNo, string currentMessage,
                                                    string destinationCity, string date1,
                                                    string date2, string sourceCity,
                                                    string st)
            {
           // var sqlFormattedDate1= date1.ToString("yyyy-MM-dd HH:mm:ss");
            //var sqlFormattedDate2 = newTrack.estimatedArrivalDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
            



            TrackingDBManager.InsertTrackindDetails(TruckRegNo,currentMessage,
                                                    destinationCity, date1,
                                                    date2, sourceCity,
                                                    st);
       
            }
            public static void UpdateTrackingDetails(string currentMessage, string date1,
                                                   string date2, string stat,
                                                    int id)
            {
           // var sqlFormattedDate1 = oldTrack.dispatchedDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
          //  var sqlFormattedDate2 = oldTrack.dispatchedDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");

            TrackingDBManager.UpdateTrackingtable( currentMessage,  date1,
                                                    date2,  stat,
                                                     id);
                
            }
           public static void DeleteTrack(int TrackId)
        {
            TrackingDBManager.DeleteTruckTrackingDetails(TrackId);
        }

        public static TrackingDetails GetTrackByCity(string dcity)
        {
            return TrackingDBManager.GetTrackingByDestCity(dcity);
        }
        public static TrackingDetails GetTrackById(int id)
        {
            return TrackingDBManager.GetTrackingByID(id);
        }
    }
 }
