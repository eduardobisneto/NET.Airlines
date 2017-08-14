using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class TravelFlight
    {
        public TravelFlight()
        {
        }

        public int FlightId { get; set; }

        public int TravelId { get; set; }

        public virtual Travel Travel { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
