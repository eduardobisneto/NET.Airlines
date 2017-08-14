using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.DTO
{
    public class TravelFlight : EntityBase
    {
        public int FlightId { get; set; }

        public int TravelId { get; set; }

        public virtual Travel Travel { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
