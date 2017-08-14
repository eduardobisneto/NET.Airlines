using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class WayMap : Mapping.Map<Way>
    {
        public WayMap() : base("Way")
        {
            this.HasRequired(f => f.Airport)
                .WithMany(f => f.Ways)
                .HasForeignKey(f => f.AirportId)
                .WillCascadeOnDelete(false);

            this.HasRequired(f => f.AirportDestiny)
                .WithMany(f => f.DestinyWays)
                .HasForeignKey(f => f.AirportDestinyId)
                .WillCascadeOnDelete(false);

            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
