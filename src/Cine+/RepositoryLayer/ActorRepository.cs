using System.Collections.Generic;
using System.Linq;
using DomainLayer;

namespace RepositoryLayer
{
    public class ActorRepository : IRepository<Actor>
    {
        #region Fields & Properties
        private ApplicationDbContext _dbContext;
        public int Count => GetAll().Count();
        #endregion

        public ActorRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        #region Methods
        public void Delete(Actor entity)
        {
            var actor = Get(entity.Id);

            if (actor != null)
            {
                _dbContext.Actor.Remove(actor);
                SaveChanges();
            }
        }

        public Actor Get(int id)
        {
            return _dbContext.Actor.Find(id);
        }

        public IEnumerable<Actor> GetAll()
        {
            return _dbContext.Actor;
        }

        public void Insert(Actor entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Actor.Add(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Actor entity)
        {
            if (Get(entity.Id) == null)
            {
                _dbContext.Actor.Update(entity);
                SaveChanges();
            }
        }
        #endregion
    }
}
