using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Mapping
{
    public class Map<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        public Map(string t)
        {
            this.Property(p => p.CreatedDate)
                .HasColumnType("datetime");

            this.HasKey<int>(k => k.Id)
                .ToTable(t);
        }
    }
}
