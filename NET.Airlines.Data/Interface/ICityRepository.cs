using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Interface
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<Data.DTO.City> GetAllCities(Entity.City entity);
    }
}
