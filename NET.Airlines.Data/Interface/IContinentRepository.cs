using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Interface
{
    public interface IContinentRepository : IRepository<Continent>
    {
        IEnumerable<Data.DTO.Continent> GetAllContinents(Entity.Continent entity);
    }
}
