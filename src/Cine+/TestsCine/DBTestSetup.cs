using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestsCine
{
    [SetUpFixture]
    public class DBTestSetup
    {
        [SetUp]
        public void Setup()
        {
            using (var context = new ApplicationDbContext())
                DbTools.CreateNewDatabase(context);
        }
    }
}
