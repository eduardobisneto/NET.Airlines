using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class ContinentMap : Mapping.Map<Continent>
    {
        public ContinentMap() : base("Continent")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
