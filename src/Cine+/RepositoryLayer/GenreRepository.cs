using System;
using System.Collections.Generic;
using System.Linq;
using DomainLayer;

namespace RepositoryLayer
{
    public class GenreRepository : IRepository<Genre>
    {
        #region Fields & Properties
        private ApplicationDbContext _dbContext;

        public int Count => GetAll().Count();
        #endregion

        #region Constructor
        public GenreRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        #endregion

        #region Methods
        public void Delete(Genre entity)
        {
            var genre = Get(entity.Id);

            if (genre != null)
            {
                _dbContext.Genre.Remove(genre);
                SaveChanges();
            }
        }

        public Genre Get(int id)
        {
            return _dbContext.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _dbContext.Genre;
        }

        public void Insert(Genre entity)
        {
            if(Get(entity.Id) == null)
            {
                _dbContext.Genre.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Genre entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Genre.Update(entity);
                SaveChanges();
            }
        }
        #endregion
    }
}
