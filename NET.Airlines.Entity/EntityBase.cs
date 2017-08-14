using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Entity
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
        }

        public int Id { get; set; }

        private DateTime? _CreatedDate { get; set; }

        public DateTime? CreatedDate
        {
            get { return _CreatedDate.HasValue ? _CreatedDate.Value : DateTime.Now; }
            set { _CreatedDate = value; }
        }

        public DateTime? ModifiedDate { get; set; }
    }
}
