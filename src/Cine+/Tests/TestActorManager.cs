using Xunit;
using ServiceLayer;
using RepositoryLayer;
using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TestActorManager
    {
        [Fact]
        public void AddActorToDB()
        {
            Actor aniston = new Actor() { Id = 1, Name = "Jennifer Aniston" };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Data Source=Cine+.db").Options;
            using (var context = new ApplicationDbContext(options)) 
            {
                ActorManager actorManager = new ActorManager(new ActorRepository(context));
                actorManager.AddActor(aniston);

            }

            using (var dbcontext = new ApplicationDbContext(options))
            {
                ActorManager actorManager = new ActorManager(new ActorRepository(new ApplicationDbContext()));
                Actor testAniston = actorManager.FindById(1);
                Assert.Equal(aniston, testAniston, new ActorComparer());
            }

        }
    }
}
