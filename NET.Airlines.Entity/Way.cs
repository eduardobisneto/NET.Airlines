using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Way : EntityBase
    {
        public Way()
        {
            this.Airport = new Airport();
            this.AirportDestiny = new Airport();
        }

        public string Description { get; set; }

        public int AirportId { get; set; }

        public int AirportDestinyId { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport AirportDestiny { get; set; }

        public virtual ICollection<Travel> Travels { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
