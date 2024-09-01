using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.ViewModels;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllProducts _productRepository;

        public ProductController(IAllProducts productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult List(int? productId, int? selectedSizeId, string anchor = null)
        {
            var products = _productRepository.GetAllProducts().ToList();
            var model = new ProductListViewModel
            {
                Products = products
            };

            // Инициализируем выбранные вариации
            foreach (var product in products)
            {
                Variation selectedVariation = null;

                // Если есть данные из запроса и они соответствуют текущему продукту
                if (productId.HasValue && selectedSizeId.HasValue && product.Id == productId.Value)
                {
                    selectedVariation = product.Variations.FirstOrDefault(v => v.Id == selectedSizeId.Value);
                }

                // Если вариация не найдена, выбираем первую по умолчанию
                if (selectedVariation == null)
                {
                    selectedVariation = product.Variations.FirstOrDefault();
                }

                if (selectedVariation != null)
                {
                    model.SelectedVariations[product.Id] = selectedVariation;
                }
            }

            // Если передан анкор (ID продукта), добавим его для прокрутки
            if (!string.IsNullOrEmpty(anchor))
            {
                ViewBag.Anchor = anchor;
            }

            return View(model);
        }


        public IActionResult Details(int id, int? selectedSizeId)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            Variation selectedVariation = null;

            if (selectedSizeId.HasValue)
            {
                selectedVariation = product.Variations.FirstOrDefault(v => v.Id == selectedSizeId.Value);
            }

            if (selectedVariation == null)
            {
                selectedVariation = product.Variations.FirstOrDefault();
            }

            var model = new ProductListViewModel
            {
                SelectedProduct = product,
                SelectedVariations = new Dictionary<int, Variation> { { product.Id, selectedVariation } }
            };

            return View(model);
        }




    }
}
