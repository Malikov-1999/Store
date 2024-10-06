using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Models;

namespace Store.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContent _context;

        public ProductRepository(AppDBContent context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Variations)
                .Include(p => p.Details)
                .Include(p => p.Images)
                .ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Variations)
                .Include(p => p.Details)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == productId);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }


        // Реализация метода поиска
        public IEnumerable<Product> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Variations)
                    .Include(p => p.Details)
                    .Include(p => p.Images)
                    .ToList();
            }
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Variations)
                .Include(p => p.Details)
                .Include(p => p.Images)
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToList();
        }

    }
}