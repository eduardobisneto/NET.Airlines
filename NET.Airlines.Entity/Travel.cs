using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Travel : EntityBase
    {
        public Travel()
        {
            this.Way = new Way();
        }

        public string Description { get; set; }

        public int WayId { get; set; }

        public virtual Way Way { get; set; }

        public DateTime? Boarding { get; set; }

        public DateTime? Arrival { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<TravelFlight> TravelFlights { get; set; }
    }
}
