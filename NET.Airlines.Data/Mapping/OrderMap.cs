using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class OrderMap : Mapping.Map<Order>
    {
        public OrderMap() : base("Order")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
