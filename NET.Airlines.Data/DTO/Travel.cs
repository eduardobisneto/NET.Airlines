using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.DTO
{
    public class Travel : EntityBase
    {
        public string Description { get; set; }

        public int WayId { get; set; }

        public virtual Way Way { get; set; }

        public DateTime? Boarding { get; set; }

        public DateTime? Arrival { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<TravelFlight> TravelFlights { get; set; }
    }
}
