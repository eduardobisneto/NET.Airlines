using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class CountryMap : Mapping.Map<Country>
    {
        public CountryMap() : base("Country")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
