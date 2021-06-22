using RepositoryLayer;
using ServiceLayer;
using System;
using Xunit;

namespace Unit_Testing_Project
{
    public class UnitTest1
    {
        [Fact]
        public void CountryManager()
        {
            var _country_manager = new CountryManager(new CountryRepository());
            var country = new DomainLayer.Country { Name = "My_country", Id = 1234, Movies = null };

            _country_manager.AddCountry(country);

            var find = _country_manager.FindById(1234);
            Assert.Equal("My_country", find.Name);
        }
    }
}
