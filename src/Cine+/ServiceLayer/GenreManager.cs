using DomainLayer;
using RepositoryLayer;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class GenreManager
    {
        #region Fields
        private readonly IRepository<Genre> genreRepository;
        #endregion


        #region Constructor
        public GenreManager(IRepository<Genre> repository)
        {
            this.genreRepository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all the genres on database
        /// </summary>
        public IEnumerable<Genre> GetAllGenres() => this.genreRepository.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        public void AddGenre(Genre genre)
        {
            this.genreRepository.Insert(genre);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="genreID"></param>
        /// <returns></returns>
        public Genre FindById(int genreID)
        {
            return genreRepository.Get(genreID);
        }

        /// <summary>
        /// Update genre 
        /// </summary>
        /// <param name="genre"></param>
        public void UpdateGenre(Genre genre)
        {
            this.genreRepository.Update(genre);
        }

        public void DeleteGenre(int genreID)
        {
            this.genreRepository.Delete(genreRepository.Get(genreID));
        }
        #endregion
    }
}
