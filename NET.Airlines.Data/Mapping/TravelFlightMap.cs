using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class TravelFlightMap : EntityTypeConfiguration<TravelFlight>
    {
        public TravelFlightMap()
        {
            this.HasKey(k => new { k.FlightId, k.TravelId });
        }
    }
}
