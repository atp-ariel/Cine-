using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace RepositoryLayer
{
    public class CinemaRepository : IRepository<Cinema>
    {
        #region Fields & Properties
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public int Count => GetAll().Count();
        #endregion
        #region Methods
        public void Delete(Cinema entity)
        {
            var cinema = Get(entity.Id);

            if (cinema != null)
            {
                _dbContext.Cinema.Remove(cinema);
                SaveChanges();
            }
        }

        public Cinema Get(int id)
        {
            return _dbContext.Cinema.Find(id);
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _dbContext.Cinema;
        }

        public void Insert(Cinema entity)
        {
            if (Get(entity.Id) == null)
            {
             
                for (int i = 1; i <= entity.Capacity; i++)
                {
                    Seat seat = new Seat
                    {
                        Id = i,
                        CinemaId = entity.Id,
                        Cinema = entity,
                    };
                _dbContext.Seat.Add(seat);
                }
                _dbContext.Cinema.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Cinema entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Cinema.Update(entity);
                SaveChanges();
            }
        }
        #endregion
    }
}
