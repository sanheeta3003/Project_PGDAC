using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOL
{
    public class TrackingDetails
    {
		public int trackingId { get; set; }
		public String sourceCity { get; set; }
		public String destinationCity { get; set; }

		public DateTime dispatchedDateTime { get; set; }

		public DateTime estimatedArrivalDateTime { get; set; }

		public Status status { get; set; }
		public String currentMessage { get; set; }
		public String TruckRegNo { get; set; }



	}
}
