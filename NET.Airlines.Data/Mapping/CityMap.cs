using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class CityMap : Mapping.Map<City>
    {
        public CityMap() : base("City")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
