using Store.Data.Models;
using Store.Data.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        Product getObjectProduct(int productId);

        // Метод для получения отфильтрованных продуктов
        Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductSpecification spec);
        IEnumerable<string> GetAllCountries();
        IEnumerable<string> GetAllSurfaces();
        IEnumerable<string> GetAllMaterials();
    }
}