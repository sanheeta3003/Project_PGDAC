using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_RationTruckTracking;
using BOL;

namespace BLL
{
    public class CustomerBM
    {
       public static List<Customers> GetAllCustomers()
        {
            List<Customers> clist = CustomersDBManager.GetAllCustomers();
            return clist;
        }
        public static Customers GetCustomerByLogin(string uname, string rationNum)
        {
            Customers theCustomer = new Customers();
            theCustomer = CustomersDBManager.GetCustomerByUnameAndRationNum(uname, rationNum);
            return theCustomer;
        
        }
        public static void InsertCustomer(Customers newCust)
        {
            CustomersDBManager.InsertCustomer(newCust.customerName, newCust.customerAddress, newCust.customerContactNumber, newCust.RationCardNumber);
        }
        public static void UpdateCustomer(Customers exitsCustomer)
        {
            CustomersDBManager.UpdateCustomer(exitsCustomer.customerContactNumber, exitsCustomer.customerAddress, exitsCustomer.customerId);
        }
        public static void DeleteCutsomer(int custId)
        {
            CustomersDBManager.DeleteCustomer(custId);
        }
    }
}
