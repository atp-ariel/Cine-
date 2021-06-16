using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryLayer;
using System.Data;

namespace ServiceLayer.Criteria
{
    class RandomCriterion : ICriterion
    {
        IRepository<Movie> movieRepository;
        public string Name => "Random";

        public RandomCriterion(IRepository<Movie> movies)
        {
            this.movieRepository = movies;
        }

        public DataTable ApplyCriterion(int n) 
        {
            Random rnd = new Random();

            var _movies = this.movieRepository.GetAll().OrderBy(x => rnd.Next()).Take(n);
         
            DataTable _table = new DataTable();
            _table.Columns.Add("Movies", typeof(Movie));

            foreach (var movie in _movies)
                _table.Rows.Add(movie);

            return _table;
        }
    }
}
