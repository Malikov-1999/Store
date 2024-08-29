using Store.Data.Interfaces;
using Store.Data.Models;

namespace Store.Data.Repository
{
    public class CategoryRepository : IProductCategory
    {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Categories;
    }
}
