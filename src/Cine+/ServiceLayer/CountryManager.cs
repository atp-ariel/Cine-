using System.Collections.Generic;
using DomainLayer;
using RepositoryLayer;

namespace ServiceLayer
{
    public class CountryManager
    {
        #region Fields
        private readonly IRepository<Country> CountryRepository;
        #endregion


        #region Constructor
        public CountryManager(IRepository<Country> repository)
        {
            this.CountryRepository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all the Countrys on database
        /// </summary>
        public IEnumerable<Country> GetAllCountrys() => this.CountryRepository.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        public void AddCountry(Country Country)
        {
            this.CountryRepository.Insert(Country);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        public Country FindById(int CountryID)
        {
            return CountryRepository.Get(CountryID);
        }

        /// <summary>
        /// Update Country 
        /// </summary>
        /// <param name="Country"></param>
        public void UpdateCountry(Country Country)
        {
            this.CountryRepository.Update(Country);
        }

        public void DeleteCountry(int CountryID)
        {
            this.CountryRepository.Delete(CountryRepository.Get(CountryID));
        }
        #endregion
    }
}
