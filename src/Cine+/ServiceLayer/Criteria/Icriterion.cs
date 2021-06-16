using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ServiceLayer
{
    public interface Icriterion
    {
        public string Name { get; }
        public void ApplyCriterion(int n);
    }
}
