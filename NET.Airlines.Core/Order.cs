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
    public class Order : IOrderRepository
    {
        private readonly IOrderRepository repository;

        public Order()
        {
            repository = new OrderRepository();
        }        

        public Entity.Order Delete(Entity.Order entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Order Get(Entity.Order entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Entity.Order> GetAll(Entity.Order entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Order Insert(Entity.Order entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Order Update(Entity.Order entity)
        {
            return repository.Update(entity);
        }
    }
}
