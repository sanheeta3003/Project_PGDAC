using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Distributors
    {
        public int distributorID { get; set; }
        public string distributorName { get; set; }
        public long distributorContactNumber { get; set; }
        public string distributorAddress { get; set; }
        public List<Customers> CustomerList { get; set; }
      //  public int RationList { get; set; }

    }
}




