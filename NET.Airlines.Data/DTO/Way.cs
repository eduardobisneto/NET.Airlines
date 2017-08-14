using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.DTO
{
    public class Way : EntityBase
    {
        public string Description { get; set; }

        public int AirportId { get; set; }

        public int AirportDestinyId { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport AirportDestiny { get; set; }
    }
}
