using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class AirlineMap : Mapping.Map<Airline>
    {
        public AirlineMap() : base("Airline")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
