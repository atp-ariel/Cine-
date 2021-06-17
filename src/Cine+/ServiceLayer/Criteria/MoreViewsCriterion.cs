using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryLayer;
using DomainLayer;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Criteria
{
    public class MoreViewsCriterion : ICriterion
    {
        private readonly ApplicationDbContext context;
        public MoreViewsCriterion(ApplicationDbContext context)
        {
            this.context = context;
        }
        public MoreViewsCriterion(IRepository<Movie> movies) : this(new ApplicationDbContext())
        {
        }
        public string Name { get => "More Views"; }

        public DataTable ApplyCriterion(int n)
        {
            Dictionary<Movie, int> dictMovie = new Dictionary<Movie, int>();
            IList<Batch> batches = context.Batch.Include(b => b.Movie).ToList();
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

            List<Movie> _movies = dictMovie.Keys.OrderByDescending(x => dictMovie[x]).Take(n).ToList();
            int[] _views = new int[_movies.Count];
            int j = 0;
            _movies.ForEach(i => { _views[j] = dictMovie[i]; j++; });

            DataTable _table = new DataTable();
            _table.Columns.Add("Movies", typeof(Movie));
            _table.Columns.Add("Views", typeof(int));

            for (int i = 0; i < _movies.Count; i++)
                _table.Rows.Add(_movies[i], _views[i]);

            return _table;
        }
    }
}
