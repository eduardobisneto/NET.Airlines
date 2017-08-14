using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository() : base()
        {
        }

        public IEnumerable<Data.DTO.Country> GetAllCountries(Entity.Country entity)
        {
            if (null == entity)
                entity = new Country();

            var list = (from c in context.Country
                        join co in context.Continent on c.ContinentId equals co.Id
                        where (entity.ContinentId > 0 ? c.ContinentId.Equals(entity.ContinentId) : entity.ContinentId == 0)
                        //&& (entity.Way != null ? w.AirportDestinyId == entity.Way.AirportDestinyId : entity.Way == null)
                        //&& (entity.Boarding != null ? t.Boarding == entity.Boarding : entity.Boarding == null)
                        //&& (entity.Arrival != null ? t.Arrival == entity.Arrival : entity.Arrival == null)
                        select new DTO.Country()
                        {
                            ContinentId = c.ContinentId,
                            Description = c.Description,
                            Id = c.Id
                        }).ToList();

            return list;

        }
    }
}
