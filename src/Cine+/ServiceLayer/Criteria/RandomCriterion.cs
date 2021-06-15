using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;

namespace ServiceLayer
{
    class RandomCriterion : Icriterion
    {
        private readonly ApplicationDbContext context;
        Movie[] movies;

        public Movie[] Movies { get { return movies; } private set { movies = value; } }
        public RandomCriterion(ApplicationDbContext context)
        {
            this.context = context;
        }
        public string Name => "Random";

        public void ApplyCriterion(int n) 
        {
            Random rnd = new Random();

            List<Movie> movieList = context.Movie.ToList();
            if (movieList.Count <= n)
            {
                movieList.OrderBy(x => rnd.Next()).ToList();
                return;
            }
           movies=movieList.OrderBy(x => rnd.Next()).Take(n).ToArray();
        }
    }
}
