using NET.Airlines.Data.Interface;
using NET.Airlines.Data.Repository;
using System.Collections.Generic;

namespace NET.Airlines.Core
{
    public class City : ICityRepository
    {
        private readonly ICityRepository repository;

        public City()
        {
            repository = new CityRepository();
        }        

        public Entity.City Delete(Entity.City entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.City Get(Entity.City entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.City> GetAll(Entity.City entity)
        {
            return repository.GetAll(entity);
        }

        public IEnumerable<Data.DTO.City> GetAllCities(Entity.City entity)
        {
            return repository.GetAllCities(entity);
        }

        public Entity.City Insert(Entity.City entity)
        {
            return repository.Insert(entity);
        }

        public Entity.City Update(Entity.City entity)
        {
            return repository.Update(entity);
        }
    }
}
