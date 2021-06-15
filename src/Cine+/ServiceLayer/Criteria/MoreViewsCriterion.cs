using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using DomainLayer;

namespace ServiceLayer
{   
    public class MoreViewsCriterion : Icriterion
    {
        private readonly ApplicationDbContext context;
        Movie[] movies;
        int[] viewsMovies;
        public MoreViewsCriterion(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string Name { get => "More Views"; }
        public Movie[] Movies { get; private set; }
        public int[] Views { get { return viewsMovies; } private set { viewsMovies=value} }

        public void ApplyCriterion(int n)
        {
            Dictionary<Movie, int> dictMovie = new Dictionary<Movie, int>();
            List<Batch> batches = context.Batch.ToList();
            foreach (Batch batch in batches)
            {
                int cinemaId = batch.CinemaId;
                Movie movie = batch.Movie;
                DateTime startTime = batch.ScheduleStartTime;
                DateTime endTime = batch.ScheduleEndTime;

                int count = context.TicketPurchase.Count(x => (x.SeatId == cinemaId && x.BatchScheduleStartTime.CompareTo(startTime) == 0 &&  
                x.BatchScheduleEndTime.CompareTo(endTime) == 0));

                if (!dictMovie.ContainsKey(movie))
                    dictMovie[movie] = count;
                else dictMovie[movie] += count;
            }
            if (dictMovie.Count <= n)
            {
                dictMovie.Keys.OrderByDescending(x => dictMovie[x]).ToList();
                return;
            }


             dictMovie.Keys.OrderByDescending(x=>dictMovie[x]).Take(n).ToList();
        }
    }
}
