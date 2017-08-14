using NET.Airlines.Data.Interface;
using NET.Airlines.Data.Repository;
using System.Collections.Generic;

namespace NET.Airlines.Core
{
    public class Country : ICountryRepository
    {
        private readonly ICountryRepository repository;

        public Country()
        {
            repository = new CountryRepository();
        }        

        public Entity.Country Delete(Entity.Country entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Country Get(Entity.Country entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Country> GetAll(Entity.Country entity)
        {
            return repository.GetAll(entity);
        }

        public IEnumerable<Data.DTO.Country> GetAllCountries(Entity.Country entity)
        {
            return repository.GetAllCountries(entity);
        }

        public Entity.Country Insert(Entity.Country entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Country Update(Entity.Country entity)
        {
            return repository.Update(entity);
        }
    }
}
