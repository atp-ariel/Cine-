using System.Collections.Generic;
using System.Linq;
using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class MovieRepository : IRepository<Movie>
    {
        #region Fields & Properties
        private readonly ApplicationDbContext _dbContext;
        public int Count => GetAll().Count();
        #endregion

        public MovieRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
            GetAll();
        }

        #region Methods
        public void Delete(Movie entity)
        {
            var movie = Get(entity.Id);

            if (movie != null)
            {
                _dbContext.Movie.Remove(movie);
                SaveChanges();
            }
        }

        public Movie Get(int id)
        {
            return _dbContext.Movie.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).Include(m=>m.Rating);
        }

        public void Insert(Movie entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Movie.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Movie entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Movie.Update(entity);
                SaveChanges();
            }
        }
        #endregion
    }
}
