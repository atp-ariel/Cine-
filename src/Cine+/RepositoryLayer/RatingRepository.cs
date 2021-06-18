using DomainLayer;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class RatingRepository : IRepository<Rating>
    {
        private ApplicationDbContext context;
        public int Count => GetAll().Count();


        public RatingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Delete(Rating entity)
        {
            if(Get(entity.Id) != null)
            {
                context.Rating.Remove(entity);
                SaveChanges();
            }
        }

        public Rating Get(int id)
        {
            var ratings = GetAll().Where(r => r.Id == id);
            return ratings == null || ratings.Count() == 0 ? null : ratings.First();
        }

        public IEnumerable<Rating> GetAll()
        {
            return context.Rating.Include(m => m.Movies);
        }

        public void Insert(Rating entity)
        {
            if(Get(entity.Id) != null)
            {
                context.Rating.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(Rating entity)
        {
            if (Get(entity.Id) != null)
            {
                Delete(entity);
                context.Rating.Add(entity);
                SaveChanges();
            }
        }
    }
}
