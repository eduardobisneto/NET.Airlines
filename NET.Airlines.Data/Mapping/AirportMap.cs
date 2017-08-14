using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class AirportMap : Mapping.Map<Airport>
    {
        public AirportMap() : base("Airport")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
