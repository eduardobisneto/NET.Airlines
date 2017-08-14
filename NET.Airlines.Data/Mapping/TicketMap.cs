using NET.Airlines.Entity;
using System.Data.Entity.ModelConfiguration;

namespace NET.Airlines.Data.Mapping
{
    public class TicketMap : Mapping.Map<Ticket>
    {
        public TicketMap() : base("Ticket")
        {
            this.Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}
