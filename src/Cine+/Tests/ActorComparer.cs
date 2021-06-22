using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using RepositoryLayer;

namespace Tests
{
    public class AppContext : ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=:memory:");
        }
    }
    internal class ActorComparer : IEqualityComparer<Actor>
    {
        public new bool Equals(Actor x, Actor y)
        {
            return x.Id == y.Id && x.Name.ToUpper() == y.Name.ToUpper();
        }

        public int GetHashCode([DisallowNull] Actor obj)
        {
            return obj.Id;
        }
    }
}