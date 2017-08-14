using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository() : base()
        {
        }

        public IEnumerable<DTO.Ticket> GetAllTickets(Ticket entity)
        {
            if (entity == null)
                entity = new Ticket();

            var list = (from t in context.Ticket
                        join tr in context.Travel on t.TravelId equals tr.Id
                        join w in context.Way on tr.WayId equals w.Id
                        join a in context.Airport on w.AirportId equals a.Id
                        join c in context.City on a.CityId equals c.Id
                        join ad in context.Airport on w.AirportDestinyId equals ad.Id
                        join cd in context.City on ad.CityId equals cd.Id
                        select new DTO.Ticket()
                        {
                            CreatedDate = t.CreatedDate,
                            Description = t.Description,
                            Id = t.Id,
                            Price = t.Price,
                            Travel = new DTO.Travel()
                            {
                                Id = tr.Id,
                                Boarding = tr.Boarding,
                                Arrival = tr.Arrival,
                                Description = tr.Description,
                                Way = new DTO.Way()
                                {
                                    Description = w.Description,
                                    Id = w.Id,
                                    Airport = new DTO.Airport()
                                    {
                                        Id = a.Id,
                                        CityId = a.CityId,
                                        Description = a.Description,
                                        City = new DTO.City()
                                        {
                                            Id = c.Id,
                                            CountryId = c.CountryId,
                                            Description = c.Description
                                        }
                                    },
                                    AirportDestiny = new DTO.Airport()
                                    {
                                        Id = ad.Id,
                                        CityId = ad.CityId,
                                        Description = ad.Description,
                                        City = new DTO.City()
                                        {
                                            Id = cd.Id,
                                            CountryId = cd.CountryId,
                                            Description = cd.Description
                                        }
                                    }
                                }
                            }
                        }).ToList();

            foreach (DTO.Ticket ticket in list)
            {
                ticket.Travel.Flights = (from tf in context.TravelFlight
                                         join t in context.Travel on tf.TravelId equals t.Id
                                         join f in context.Flight on tf.FlightId equals f.Id
                                         join ar in context.Airline on f.AirlineId equals ar.Id
                                         join w in context.Way on f.WayId equals w.Id
                                         join a in context.Airport on w.AirportId equals a.Id
                                         join c in context.City on a.CityId equals c.Id
                                         join ad in context.Airport on w.AirportDestinyId equals ad.Id
                                         join cd in context.City on ad.CityId equals cd.Id
                                         where tf.TravelId.Equals(ticket.Travel.Id)
                                         select new DTO.Flight()
                                         {

                                             Airline = new DTO.Airline()
                                             {
                                                 Description = ar.Description,
                                                 Id = ar.Id,
                                                 CreatedDate = ar.CreatedDate,
                                                 ModifiedDate = ar.ModifiedDate
                                             },
                                             Way = new DTO.Way()
                                             {
                                                 Description = w.Description,
                                                 Id = w.Id,
                                                 AirportId = w.AirportId,
                                                 CreatedDate = w.CreatedDate,
                                                 ModifiedDate = w.ModifiedDate,
                                                 Airport = new DTO.Airport()
                                                 {
                                                     Id = a.Id,
                                                     CityId = a.CityId,
                                                     Description = a.Description,
                                                     CreatedDate = a.CreatedDate,
                                                     ModifiedDate = a.ModifiedDate,
                                                     City = new DTO.City()
                                                     {
                                                         Id = c.Id,
                                                         CountryId = c.CountryId,
                                                         Description = c.Description,
                                                         CreatedDate = c.CreatedDate,
                                                         ModifiedDate = c.ModifiedDate
                                                     }
                                                 },
                                                 AirportDestiny = new DTO.Airport()
                                                 {
                                                     Id = ad.Id,
                                                     CityId = ad.CityId,
                                                     Description = ad.Description,
                                                     CreatedDate = ad.CreatedDate,
                                                     ModifiedDate = ad.ModifiedDate,
                                                     City = new DTO.City()
                                                     {
                                                         Id = cd.Id,
                                                         CountryId = cd.CountryId,
                                                         Description = cd.Description,
                                                         CreatedDate = cd.CreatedDate,
                                                         ModifiedDate = cd.CreatedDate
                                                     }
                                                 }
                                             },
                                             AirlineId = f.AirlineId,
                                             Arrival = f.Arrival,
                                             Boarding = f.Boarding,
                                             Description = f.Description,
                                             Id = f.Id,
                                             WayId = f.WayId,
                                             CreatedDate = f.CreatedDate,
                                             ModifiedDate = f.ModifiedDate

                                         }).ToList();
            };

            return list;
        }
    }
}
