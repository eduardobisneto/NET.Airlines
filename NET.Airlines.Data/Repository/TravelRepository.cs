using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        public TravelRepository() : base()
        {
        }

        public IEnumerable<DTO.Airport> GetAllSources()
        {
            var list = (from t in context.Travel
                        join w in context.Way on t.WayId equals w.Id
                        join a in context.Airport on w.AirportId equals a.Id
                        join c in context.City on a.CityId equals c.Id
                        select new DTO.Airport()
                        {
                            CityId = a.CityId,
                            CreatedDate = a.CreatedDate,
                            Description = a.Description,
                            Id = a.Id,
                            City = new DTO.City()
                            {
                                CountryId = c.CountryId,
                                CreatedDate = c.CreatedDate,
                                Description = c.Description,
                                Id = c.Id
                            }
                        }).Distinct().ToList();

            return list;
        }

        public IEnumerable<DTO.Airport> GetAllDestinies()
        {
            var list = (from t in context.Travel
                        join w in context.Way on t.WayId equals w.Id
                        join a in context.Airport on w.AirportDestinyId equals a.Id
                        join c in context.City on a.CityId equals c.Id
                        select new DTO.Airport()
                        {
                            CityId = a.CityId,
                            CreatedDate = a.CreatedDate,
                            Description = a.Description,
                            Id = a.Id,
                            City = new DTO.City()
                            {
                                CountryId = c.CountryId,
                                CreatedDate = c.CreatedDate,
                                Description = c.Description,
                                Id = c.Id
                            }
                        }).Distinct().ToList();

            return list;
        }

        public IEnumerable<DTO.Travel> GetAllTravels(Travel entity = null)
        {
            if (null == entity)
                entity = new Travel();

            var list = (from t in context.Travel
                        join w in context.Way on t.WayId equals w.Id
                        join a in context.Airport on w.AirportId equals a.Id
                        join c in context.City on a.CityId equals c.Id
                        join ad in context.Airport on w.AirportDestinyId equals ad.Id
                        join cd in context.City on ad.CityId equals cd.Id
                        //where (entity.Way != null ? w.AirportId.Equals(entity.Way.AirportId) : entity.Way == null)
                        //&& (entity.Way != null ? w.AirportDestinyId == entity.Way.AirportDestinyId : entity.Way == null)
                        //&& (entity.Boarding != null ? t.Boarding == entity.Boarding : entity.Boarding == null)
                        //&& (entity.Arrival != null ? t.Arrival == entity.Arrival : entity.Arrival == null)
                        select new DTO.Travel()
                        {
                            Arrival = t.Arrival,
                            Boarding = t.Boarding,
                            Description = t.Description,
                            Id = t.Id,
                            WayId = t.WayId,
                            Way = new DTO.Way()
                            {
                                CreatedDate = w.CreatedDate,
                                Description = w.Description,
                                Id = w.Id,
                                ModifiedDate = w.ModifiedDate,
                                AirportId = a.Id,
                                AirportDestinyId = ad.Id,
                                Airport = new DTO.Airport()
                                {
                                    CityId = a.CityId,
                                    CreatedDate = a.CreatedDate,
                                    Description = a.Description,
                                    Id = a.Id,
                                    City = new DTO.City()
                                    {
                                        CountryId = c.CountryId,
                                        CreatedDate = c.CreatedDate,
                                        Description = c.Description,
                                        Id = c.Id
                                    }
                                },
                                AirportDestiny = new DTO.Airport()
                                {
                                    CityId = ad.CityId,
                                    CreatedDate = ad.CreatedDate,
                                    Description = ad.Description,
                                    Id = ad.Id,
                                    City = new DTO.City()
                                    {
                                        CountryId = cd.CountryId,
                                        CreatedDate = cd.CreatedDate,
                                        Description = cd.Description,
                                        Id = cd.Id
                                    }
                                }
                            }
                        }).ToList();

            return list;
        }
    }
}