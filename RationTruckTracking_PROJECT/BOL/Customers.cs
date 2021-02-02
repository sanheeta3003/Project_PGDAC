using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Customers
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public long customerContactNumber { get; set; }
        public string customerAddress { get; set; }
        public Distributors distributor;
        public string RationCardNumber { get; set; }

    }

}

