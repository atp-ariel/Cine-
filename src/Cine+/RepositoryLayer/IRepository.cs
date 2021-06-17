using DomainLayer;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface IRepository<T> 
    {
        public int Count { get;  }
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
