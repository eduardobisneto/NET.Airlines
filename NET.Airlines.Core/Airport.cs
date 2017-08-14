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
    public class Airport : IAirportRepository
    {
        private readonly IAirportRepository repository;

        public Airport()
        {
            repository = new AirportRepository();
        }        

        public Entity.Airport Delete(Entity.Airport entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Airport Get(Entity.Airport entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Airport> GetAll(Entity.Airport entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Airport Insert(Entity.Airport entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Airport Update(Entity.Airport entity)
        {
            return repository.Update(entity);
        }
    }
}
