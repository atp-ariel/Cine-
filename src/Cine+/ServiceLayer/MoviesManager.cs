using DomainLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class MoviesManager
    {
        #region Fields
        public readonly CountryManager country;
        public readonly ActorManager actors;
        public readonly GenreManager genres;
        private readonly IRepository<Movie> MovieRepository;
        private IRepository<Rating> ratings;
        #endregion

        #region Constructor
        public MoviesManager(IRepository<Movie> repository, IRepository<Country> country, IRepository<Actor> actors, IRepository<Genre> genres, IRepository<Rating> r)
        {
            this.country = new CountryManager(country);
            this.actors = new ActorManager( actors);
            this.genres = new GenreManager(genres);
            this.ratings = r;
            this.MovieRepository = repository;
            GetAllMovies();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all the Movies on database
        /// </summary>
        public IEnumerable<Movie> GetAllMovies() => this.MovieRepository.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Movie"></param>
        public void AddMovie(Movie Movie)
        {
            this.MovieRepository.Insert(Movie);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="MovieID"></param>
        /// <returns></returns>
        public Movie FindById(int MovieID)
        {
            return MovieRepository.Get(MovieID);
        }

        /// <summary>
        /// Update Movie 
        /// </summary>
        /// <param name="Movie"></param>
        public void UpdateMovie(Movie Movie)
        {
            this.MovieRepository.Update(Movie);
        }

        public void DeleteMovie(int MovieID)
        {
            this.MovieRepository.Delete(MovieRepository.Get(MovieID));
        }

        public void UpdateRelations(Movie movie, int rating, TimeSpan duration, int[] countries = null, int[] genres = null, int[] actors = null)
        {
            if (rating != 0)
            {
                Rating auxRating = ratings.Get(rating);
                auxRating.Movies.Add(movie);
                movie.RatingId = rating;
                movie.Rating = auxRating;
            }
            if (countries != null)
                foreach (var countryID in countries)
                {
                    var _country = country.FindById(countryID);
                    movie.Countries.Add(_country);
                    _country.Movies.Add(movie);
                }


            if (genres != null)
                foreach (var genreID in genres)
                {
                    var _genre = this.genres.FindById(genreID);
                    movie.Genres.Add(_genre);
                    _genre.Movies.Add(movie);
                }

            if (actors != null)
                foreach (var actorID in actors)
                {
                    var _actor = this.actors.FindById(actorID);
                    movie.Actors.Add(_actor);
                    _actor.Movies.Add(movie);
                }

            movie.DurationTime = duration;
        }

        public void AddBatchMovie(Movie movie)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            foreach (var batch in movie.Batches)
                _context.Batch.Add(batch);
        }
        #endregion
    }
}
