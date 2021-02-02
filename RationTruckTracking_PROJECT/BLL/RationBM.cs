using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL_RationTruckTracking;
namespace BLL
{
   public class RationBM
    {
      
            public static List<Ration> GetAllRation()
            {
            List<Ration> rlist = RationDBManager.GetAllRation();
                return rlist;
            }

            public static void InsertRation(string goodsName, int goodsCost, int goodsQuantity)
            {
                RationDBManager.InsertRation(goodsName, goodsCost, goodsQuantity);
            }
            public static void UpdateRation(int goodsCost, int goodsQuantity, int goodsId)
            {
                RationDBManager.UpdateRation( goodsCost, goodsQuantity, goodsId);
            }
           public static void DeleteRation(int rationId)
           {
            RationDBManager.DeleteRation(rationId);
          }
        public static Ration GetGoodsById(int rationId)
        {
            return RationDBManager.GetRationByID(rationId);
        }
    }
 }
