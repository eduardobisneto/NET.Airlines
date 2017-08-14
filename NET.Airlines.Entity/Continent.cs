using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Continent : EntityBase
    {
        public string Description { get; set; }        

        public virtual ICollection<Country> Countries { get; set; }
    }
}
