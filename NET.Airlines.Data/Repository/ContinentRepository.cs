using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Airlines.Data.DTO;

namespace NET.Airlines.Data.Repository
{
    public class ContinentRepository : Repository<Entity.Continent>, IContinentRepository
    {
        public ContinentRepository() : base()
        {
        }

        public IEnumerable<Data.DTO.Continent> GetAllContinents(Entity.Continent entity)
        {
            if (null == entity)
                entity = new Entity.Continent();

            var list = (from c in context.Continent
                        //where (entity.CountryId > 0 ? c.CountryId.Equals(entity.CountryId) : entity.CountryId == 0)
                        //&& (entity.Way != null ? w.AirportDestinyId == entity.Way.AirportDestinyId : entity.Way == null)
                        //&& (entity.Boarding != null ? t.Boarding == entity.Boarding : entity.Boarding == null)
                        //&& (entity.Arrival != null ? t.Arrival == entity.Arrival : entity.Arrival == null)
                        select new DTO.Continent()
                        {
                            Description = c.Description,
                            Id = c.Id
                        }).ToList();

            return list;

        }
    }
}
