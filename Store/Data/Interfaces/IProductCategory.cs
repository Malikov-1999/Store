using Store.Data.Models;

namespace Store.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
