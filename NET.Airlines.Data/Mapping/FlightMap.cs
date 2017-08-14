using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class FlightMap : Mapping.Map<Flight>
    {
        public FlightMap() : base("Flight")
        {
            this.Property(p => p.Arrival)
                .HasColumnType("datetime");

            this.Property(p => p.Boarding)
                .HasColumnType("datetime");

            this.Property(p => p.Description)
                .HasMaxLength(128);

            //this.HasMany(t => t.TravelFlights)
            //    .WithRequired()
            //    .HasForeignKey(f => f.IdFlight);
        }
    }
}
