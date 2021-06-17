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
        public string SelectedCriteria => new ConfigRepository().Get("SelectedCriteria").Value;

        public  IEnumerable<(string, ICriterion)> GetCriterions()
        {
            var _criterios = new List<(string, ICriterion)>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICriterion))))
            {
                ICriterion _criterio = (ICriterion)Activator.CreateInstance(type, new MovieRepository(new ApplicationDbContext()));
                yield return (_criterio.Name, _criterio);
            }
        }

        public  ICriterion GetSelectedCriterion()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICriterion))))
            {
                ICriterion _criterio = (ICriterion)Activator.CreateInstance(type, new MovieRepository(new ApplicationDbContext()));
                if (_criterio.Name == SelectedCriteria)
                    return _criterio;
            }
            return null;
        }

        public  void UpdateSelected(ConfigRepository config, string selection)
        {
            config.Set("SelectedCriteria", selection);
        }

    }
}
