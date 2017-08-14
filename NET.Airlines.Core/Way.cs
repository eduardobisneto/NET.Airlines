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
    public class Way : IWayRepository
    {
        private readonly IWayRepository repository;

        public Way()
        {
            repository = new WayRepository();
        }        

        public Entity.Way Delete(Entity.Way entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Way Get(Entity.Way entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Way> GetAll(Entity.Way entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Way Insert(Entity.Way entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Way Update(Entity.Way entity)
        {
            return repository.Update(entity);
        }
    }
}
