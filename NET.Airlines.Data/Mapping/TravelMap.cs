using NET.Airlines.Entity;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class TravelMap : Mapping.Map<Travel>
    {
        public TravelMap() : base("Travel")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);

            //this.HasMany(t => t.TravelFlights)
            //    .WithRequired()
            //    .HasForeignKey(f => f.IdTravel);

            //    .WithMany(f => f.Travels)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("FlightId");
            //        m.MapRightKey("TravelId");
            //        m.ToTable("TravelFlight");
            //    });
        }
    }
}
