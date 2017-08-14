using NET.Airlines.Data.Interface;
using NET.Airlines.Data.Repository;
using System.Collections.Generic;

namespace NET.Airlines.Core
{
    public class Travel : ITravelRepository
    {
        private readonly ITravelRepository repository;

        public Travel()
        {
            repository = new TravelRepository();
        }

        public Entity.Travel Delete(Entity.Travel entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Travel Get(Entity.Travel entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Travel> GetAll(Entity.Travel entity)
        {
            return (IEnumerable<Entity.Travel>)repository.GetAll(entity);
        }

        public IEnumerable<Data.DTO.Airport> GetAllDestinies()
        {
            return repository.GetAllDestinies();
        }

        public IEnumerable<Data.DTO.Airport> GetAllSources()
        {
            return repository.GetAllSources();
        }

        public IEnumerable<Data.DTO.Travel> GetAllTravels(Entity.Travel entity)
        {
            return repository.GetAllTravels(entity);
        }

        public Entity.Travel Insert(Entity.Travel entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Travel Update(Entity.Travel entity)
        {
            return repository.Update(entity);
        }
    }
}
