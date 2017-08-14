using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Interface
{
    public interface IRepository<T> : IDisposable
        where T : Entity.EntityBase
    {
        T Insert(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Get(T entity);

        IEnumerable<T> GetAll(T entity);
    }
}
