using Store.Data.Models;

namespace Store.Data.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        
            public ProductFilter Filter { get; }

            public ProductSpecification(ProductFilter filter)
            {
                Filter = filter;
            }

            // Здесь можно добавить методы для фильтрации, например, через IQueryable
       
    }
    
}
