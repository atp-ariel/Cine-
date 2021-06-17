using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace RepositoryLayer.Seed
{
    public static class Sower
    {
        public static void SowSeeds(IApplicationBuilder app)
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ISeed))))
                ((ISeed)Activator.CreateInstance(type)).EnsurePopulated(app);
        }
    }
}
