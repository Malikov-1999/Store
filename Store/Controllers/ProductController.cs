using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.Data.Specifications;
using Store.ViewModels;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductCategory _allcategory;

        public ProductController(IAllProducts iallProducts, IProductCategory iProductcategory)
        {
            _allProducts = iallProducts;
            _allcategory = iProductcategory;
        }

        public ViewResult List(ProductFilter filter)
        {
            var spec = new ProductSpecification(filter);
            var products = _allProducts.GetFilteredProductsAsync(spec).Result;
            
            var model = new ProductListViewModel
            {
                AllProducts = products,
                CurrCategory = "Категория",
                Categories = _allcategory.AllCategories,
                Countries = _allProducts.GetAllCountries(),
                ProductTypes = Enum.GetValues(typeof(ProductType)).Cast<ProductType>(),
                Surfaces = _allProducts.GetAllSurfaces(),
                Materials = _allProducts.GetAllMaterials(),

                SelectedCategoryId = filter.CategoryId,
                MinPrice = filter.MinPrice,
                MaxPrice = filter.MaxPrice,
                CountryOfOrigin = filter.CountryOfOrigin,
                ProductType = filter.ProductType,
                Surface = filter.Surface,
                Material = filter.Material
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var product = _allProducts.getObjectProduct(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] ProductFilter filter)
        {
            var spec = new ProductSpecification(filter);
            var products = await _allProducts.GetFilteredProductsAsync(spec);

            return Ok(products);
        }
    }
}
