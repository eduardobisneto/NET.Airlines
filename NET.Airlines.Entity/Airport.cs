using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Airport : EntityBase
    {
        public Airport()
        {
            this.City = new City();
        }

        public string Description { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Way> Ways { get; set; }

        public virtual ICollection<Way> DestinyWays { get; set; }
    }
}
