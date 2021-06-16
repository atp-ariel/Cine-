using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using RepositoryLayer;

namespace ServiceLayer
{
    public class ActorManager 
    {
        #region Fields
        private readonly IRepository<Actor> actorRepository;
        #endregion


        #region Constructor
        public ActorManager(IRepository<Actor> repository)
        {
            this.actorRepository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all the genres on database
        /// </summary>
        public IEnumerable<Actor> GetAllActors () => this.actorRepository.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        public void AddActor(Actor actor)
        {
            this.actorRepository.Insert(actor);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="genreID"></param>
        /// <returns></returns>
        public Actor FindById(int actorID)
        {
            return actorRepository.Get(actorID);
        }

        /// <summary>
        /// Update genre 
        /// </summary>
        /// <param name="genre"></param>
        public void UpdateActor(Actor actor)
        {
            this.actorRepository.Update(actor);
        }

        public void DeleteActor(int actorID)
        {
            this.actorRepository.Delete(actorRepository.Get(actorID));
        }
        #endregion
    }
}
