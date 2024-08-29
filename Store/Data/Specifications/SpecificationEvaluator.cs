using System.Linq;

namespace Store.Data.Specifications
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, BaseSpecification<T> specification)
        {
            // Применяем критерии из спецификации к исходному запросу
            var query = specification.Apply(inputQuery);

            // Возвращаем отфильтрованный запрос
            return query;
        }
    }
}