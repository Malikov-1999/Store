using System.Linq.Expressions;

namespace Store.Data.Specifications
{
    public abstract class BaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> Criteria { get; } = new();

        protected void AddCriteria(Expression<Func<T, bool>> criterion)
        {
            Criteria.Add(criterion);
        }

        public IQueryable<T> Apply(IQueryable<T> query)
        {
            foreach (var criterion in Criteria)
            {
                query = query.Where(criterion);
            }
            return query;
        }
    }
}
