using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Models;

namespace Store.Data.Repository
{
    public class CategoryRepository : IProductCategory
    {

        private readonly AppDBContent _context;
        private readonly IProductCategory _categoryRepository;


        public CategoryRepository(AppDBContent context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories
                .Include(c => c.Products)
                .ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == categoryId);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
