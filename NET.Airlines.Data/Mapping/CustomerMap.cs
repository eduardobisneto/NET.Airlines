using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class CustomerMap : Mapping.Map<Customer>
    {
        public CustomerMap() : base("Customer")
        {
            this.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(128);

            this.Property(p => p.BornDate)
                .HasColumnType("datetime");
        }
    }
}
