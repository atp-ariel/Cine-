using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer
{
    public class CinemaManager
    {
        #region Fields
        private readonly IRepository<Cinema> cinemaRepository;
        #endregion


        #region Constructor
        public CinemaManager(IRepository<Cinema> repository)
        {
            this.cinemaRepository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all the cinemas on database
        /// </summary>
        public IEnumerable<Cinema> GetAllCinemas() => this.cinemaRepository.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cinema"></param>
        public void AddCinema(Cinema cinema)
        {
            this.cinemaRepository.Insert(cinema);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="cinemaID"></param>
        /// <returns></returns>
        public Cinema FindById(int cinemaID)
        {
            return cinemaRepository.Get(cinemaID);
        }

        /// <summary>
        /// Update cinema 
        /// </summary>
        /// <param name="cinema"></param>
        public void UpdateCinema(Cinema cinema)
        {
            this.cinemaRepository.Update(cinema);
        }

        public void DeleteCinema(int cinemaID)
        {
            this.cinemaRepository.Delete(cinemaRepository.Get(cinemaID));
        }
        #endregion
    }
}

