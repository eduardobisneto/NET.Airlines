using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Country : EntityBase
    {
        public Country()
        {
            this.Continent = new Continent ();
        }

        public string Description { get; set; }

        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
