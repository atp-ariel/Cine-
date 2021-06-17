using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public class BatchRepository : IRepository<Batch>
    {
        #region Fields & Properties
        private readonly ApplicationDbContext _dbContext;
        public int Count => _dbContext.Batch.Count();
        #endregion

        #region Constructor
        public BatchRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        #endregion

        #region Methods
        public void Delete(Batch entity)
        {
        }

        public Batch Get(int id)
        {
            return null;
        }

        public IEnumerable<Batch> GetAll()
        {
            return null;
        }

        public void Insert(Batch entity)
        {
           
        }

        public void SaveChanges()
        {
        }

        public void Update(Batch entity)
        {
           
        }
        #endregion
    }
}
