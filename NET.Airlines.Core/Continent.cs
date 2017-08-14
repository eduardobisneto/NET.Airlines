using NET.Airlines.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Airlines.Entity;
using NET.Airlines.Data.Repository;
using NET.Airlines.Data;
using NET.Airlines.Data.DTO;

namespace NET.Airlines.Core
{
    public class Continent : IContinentRepository
    {
        private readonly IContinentRepository repository;

        public Continent()
        {
            repository = new ContinentRepository();
        }

        public Entity.Continent Delete(Entity.Continent entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Continent Get(Entity.Continent entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Continent> GetAll(Entity.Continent entity)
        {
            return repository.GetAll(entity);
        }

        public IEnumerable<Data.DTO.Continent> GetAllContinents(Entity.Continent entity)
        {
            return repository.GetAllContinents(entity);
        }

        public Entity.Continent Insert(Entity.Continent entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Continent Update(Entity.Continent entity)
        {
            return repository.Update(entity);
        }
    }
}
