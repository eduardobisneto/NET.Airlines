using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository() : base()
        {
        }

        public IEnumerable<Data.DTO.City> GetAllCities(Entity.City entity)
        {
            if (null == entity)
                entity = new City();

            var list = (from c in context.City
                        join co in context.Country on c.CountryId equals co.Id
                        where (entity.CountryId > 0 ? c.CountryId.Equals(entity.CountryId) : entity.CountryId == 0)
                        //&& (entity.Way != null ? w.AirportDestinyId == entity.Way.AirportDestinyId : entity.Way == null)
                        //&& (entity.Boarding != null ? t.Boarding == entity.Boarding : entity.Boarding == null)
                        //&& (entity.Arrival != null ? t.Arrival == entity.Arrival : entity.Arrival == null)
                        select new DTO.City()
                        {
                            CountryId = c.CountryId,
                            Description = c.Description,
                            Id = c.Id
                        }).ToList();

            return list;

        }
    }
}