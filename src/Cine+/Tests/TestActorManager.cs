using Xunit;
using ServiceLayer;
using RepositoryLayer;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tests
{
    public class TestActorManager
    {
        [Fact]
        public void AddActorToDB()
        {
            // Arrange
            Actor aniston = new Actor() { Id = 1, Name = "Jennifer Aniston" };

            var context = new AppContext();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            ActorRepository repo = new ActorRepository(context);
            ActorManager manager = new ActorManager(repo);

            // Act
            manager.AddActor(aniston);

            // Assert
            Assert.Single(manager.GetAllActors());

        }

    }

}
