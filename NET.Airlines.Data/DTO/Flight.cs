using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.DTO
{
    public class Flight : EntityBase
    {
        public string Description { get; set; }

        public int AirlineId { get; set; }

        public int WayId { get; set; }

        public virtual Airline Airline { get; set; }

        public virtual Way Way { get; set; }

        public DateTime? Boarding { get; set; }

        public DateTime? Arrival { get; set; }

        public ICollection<Travel> Travels { get; set; }
    }
}
