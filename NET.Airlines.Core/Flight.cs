using NET.Airlines.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Airlines.Entity;
using NET.Airlines.Data.Repository;

namespace NET.Airlines.Core
{
    public class Flight : IFlightRepository
    {
        private readonly IFlightRepository repository;

        public Flight()
        {
            repository = new FlightRepository();
        }        

        public Entity.Flight Delete(Entity.Flight entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Flight Get(Entity.Flight entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Flight> GetAll(Entity.Flight entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Flight Insert(Entity.Flight entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Flight Update(Entity.Flight entity)
        {
            return repository.Update(entity);
        }
    }
}
