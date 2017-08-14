using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.DTO
{
    public class Continent : EntityBase
    {
        public string Description { get; set; }        

        public virtual ICollection<Country> Countries { get; set; }
    }
}
