using DomainLayer;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public class CountryRepository : IRepository<Country>
    {
        #region Fields & Properties
        private ApplicationDbContext _dbContext;

        public int Count => GetAll().Count();
        #endregion

        #region Constructor
        public CountryRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        #endregion

        #region Methods
        public void Delete(Country entity)
        {
            var country = Get(entity.Id);

            if (country != null)
            {
                _dbContext.Country.Remove(country);
                SaveChanges();
            }
        }

        public Country Get(int id)
        {
            return _dbContext.Country.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return _dbContext.Country;
        }

        public void Insert(Country entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Country.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Country entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Country.Update(entity);
                SaveChanges();
            }
        }
        #endregion
    }
}
