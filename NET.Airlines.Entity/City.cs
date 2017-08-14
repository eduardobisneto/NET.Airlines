using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class City : EntityBase
    {
        public City()
        {
            this.Country = new Country();
        }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Airport> Airports{ get; set; }
    }
}
