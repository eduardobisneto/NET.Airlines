using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public class Ticket : EntityBase
    {
        public Ticket()
        {
            this.Travel = new Travel();
        }

        public string Description { get; set; }

        public int TravelId { get; set; }

        public virtual Travel Travel { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
