using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.Data.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContent _context;

        public ProductRepository(AppDBContent context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products => _context.Products;

        public Product getObjectProduct(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductSpecification spec)
        {
            var query = _context.Products.AsQueryable();

            if (spec.Filter.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == spec.Filter.CategoryId.Value);

            if (spec.Filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= spec.Filter.MinPrice.Value);

            if (spec.Filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= spec.Filter.MaxPrice.Value);

            if (!string.IsNullOrEmpty(spec.Filter.CountryOfOrigin))
                query = query.Where(p => p.CountryOfOrigin == spec.Filter.CountryOfOrigin);

            if (spec.Filter.ProductType.HasValue)
                query = query.Where(p => p.ProductType == spec.Filter.ProductType.Value);

            if (!string.IsNullOrEmpty(spec.Filter.Surface))
                query = query.Where(p => p.Surface == spec.Filter.Surface);

            if (!string.IsNullOrEmpty(spec.Filter.Material))
                query = query.Where(p => p.Material == spec.Filter.Material);

            return await query.ToListAsync();
        }

        // Методы для получения списков стран, поверхностей и материалов
        public IEnumerable<string> GetAllCountries()
        {
            return _context.Products.Select(p => p.CountryOfOrigin).Distinct().ToList();
        }

        public IEnumerable<string> GetAllSurfaces()
        {
            return _context.Products.Select(p => p.Surface).Distinct().ToList();
        }

        public IEnumerable<string> GetAllMaterials()
        {
            return _context.Products.Select(p => p.Material).Distinct().ToList();
        }
    }
}