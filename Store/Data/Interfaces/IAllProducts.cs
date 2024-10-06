using Store.Data.Models;

namespace Store.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        // Новый метод для поиска
        IEnumerable<Product> SearchProducts(string searchTerm);
    }
}