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
    public class Ticket : ITicketRepository
    {
        private readonly ITicketRepository repository;

        public Ticket()
        {
            repository = new TicketRepository();
        }        

        public Entity.Ticket Delete(Entity.Ticket entity)
        {
            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Ticket Get(Entity.Ticket entity)
        {
            return repository.Get(entity);
        }

        public IEnumerable<Data.DTO.Ticket> GetAllTickets(Entity.Ticket entity)
        {
            return repository.GetAllTickets(entity);
        }

        public IEnumerable<Entity.Ticket> GetAll(Entity.Ticket entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.Ticket Insert(Entity.Ticket entity)
        {
            return repository.Insert(entity);
        }

        public Entity.Ticket Update(Entity.Ticket entity)
        {
            return repository.Update(entity);
        }
    }
}
