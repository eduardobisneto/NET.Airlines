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
    public class Airline : IAirlineRepository
    {
        private readonly IAirlineRepository repository;

        public Airline()
        {
            repository = new AirlineRepository();
        }        

        public Entity.Airline Delete(Entity.Airline entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Airline Get(Entity.Airline entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Airline> GetAll(Entity.Airline entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Airline Insert(Entity.Airline entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Airline Update(Entity.Airline entity)
        {
            return repository.Update(entity);
        }
    }
}
