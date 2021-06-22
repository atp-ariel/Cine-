using DomainLayer;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tests
{
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