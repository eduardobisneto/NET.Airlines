using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository() : base()
        {
        }
    }
}
