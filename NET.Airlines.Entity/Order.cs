using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Order : EntityBase
    {
        public string Description { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public decimal Price { get; set; }
    }
}
