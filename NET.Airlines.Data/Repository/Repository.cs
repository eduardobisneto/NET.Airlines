using NET.Airlines.Data.Interface;
using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Repository
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : EntityBase
    {
        protected readonly Context context;

        public Repository()
        {
            context = new Context();
        }

        public T Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public T Get(T entity)
        {
            return context.Set<T>().Find(entity.Id);
        }

        public virtual IEnumerable<T> GetAll(T entity = null)
        {
            return context.Set<T>().ToList();
        }

        public T Insert(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
