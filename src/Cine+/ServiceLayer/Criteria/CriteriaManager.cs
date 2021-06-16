using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RepositoryLayer;
using Microsoft.Extensions.Configuration;

namespace ServiceLayer.Criteria
{
    public  class CriteriaManager
    {
        public ICriterion SelectedCriteria;

        public static IEnumerable<(string, ICriterion)> GetCriterions()
        {
            var _criterios = new List<(string, ICriterion)>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICriterion))))
            {
                ICriterion _criterio = (ICriterion)Activator.CreateInstance(type, new MovieRepository(new ApplicationDbContext()));
                yield return (_criterio.Name, _criterio);
            }
        }

        public static ICriterion GetSelectedCriterion(string criterioName)
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICriterion))))
            {
                ICriterion _criterio = (ICriterion)Activator.CreateInstance(type, new MovieRepository(new ApplicationDbContext()));
                if (_criterio.Name == criterioName)
                    return _criterio;
            }
            return null;
        }

        public static void UpdateSelected(IConfiguration configuration, string selection)
        {
            configuration["SelectedCriteria"] = selection;
        }

    }
}
