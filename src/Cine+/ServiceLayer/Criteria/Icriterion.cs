using System.Data;

namespace ServiceLayer.Criteria
{
    public interface ICriterion
    {
        public string Name { get; }
        public DataTable ApplyCriterion(int n);
    }
}
