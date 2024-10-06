using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.ViewModels;
using System.Linq;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllProducts _productRepository;
        private readonly IProductCategory _categoryRepository;

        public ProductController(IAllProducts productRepository, IProductCategory categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Логика фильтрации, сортировки и поиска
        public IActionResult List(int? productId, int? selectedSizeId, int? categoryId, string productType, string material, string country, string group, decimal? priceMin, decimal? priceMax, string sortOrder = "default", string searchTerm = null, string anchor = null)
        {
            // Очистка строки поиска на стороне сервера
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim(); // Убираем пробелы
                if (string.IsNullOrEmpty(searchTerm))
                {
                    searchTerm = null; // Если после очистки строка пустая, сбрасываем поиск
                }
            }

            // Получаем продукты из базы данных
            var products = _productRepository.GetAllProducts().AsQueryable();

            // Фильтрация по ключевым словам (поиск по имени, описанию, материалу, стране, группе, категории, типу товара, SKU и вариациям)
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p =>
                    (p.Name != null && p.Name.Contains(searchTerm)) ||
                    (p.Description != null && p.Description.Contains(searchTerm)) ||
                    (p.Material != null && p.Material.Contains(searchTerm)) ||
                    (p.Country != null && p.Country.Contains(searchTerm)) ||
                    (p.Group != null && p.Group.Contains(searchTerm)) ||
                    (p.Category != null && p.Category.Name.Contains(searchTerm)) ||
                    (p.SKU != null && p.SKU.Contains(searchTerm)) || // Поиск по артикулу (SKU)
                    (p.ProductTypeTypes.ToString().Contains(searchTerm)) || // Поиск по типу товара
                    (p.Variations.Any(v => v.Size.Contains(searchTerm))) || // Поиск по размеру вариаций
                    (p.Variations.Any(v => v.Price.ToString().Contains(searchTerm)))); // Поиск по цене вариаций
            }

            // Получаем данные для фильтров
            var categories = _categoryRepository.GetAllCategories();
            var materials = products.Where(p => p.Material != null).Select(p => p.Material).Distinct().ToList();
            var countries = products.Where(p => p.Country != null).Select(p => p.Country).Distinct().ToList();
            var groups = products.Where(p => p.Group != null).Select(p => p.Group).Distinct().ToList(); // Фильтрация по группе

            // Фильтрация по категории
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            // Фильтрация по типу продукта
            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(p => p.ProductTypeTypes.ToString() == productType);
            }

            // Фильтрация по материалу
            if (!string.IsNullOrEmpty(material))
            {
                products = products.Where(p => p.Material == material);
            }

            // Фильтрация по стране
            if (!string.IsNullOrEmpty(country))
            {
                products = products.Where(p => p.Country == country);
            }

            // Фильтрация по группе
            if (!string.IsNullOrEmpty(group))
            {
                products = products.Where(p => p.Group == group);
            }

            // Фильтрация по цене с учетом скидок
            if (priceMin.HasValue)
            {
                products = products.Where(p => p.Variations.Any(v =>
                    (v.DiscountedPrice.HasValue ? v.DiscountedPrice.Value : v.Price) >= priceMin.Value));
            }

            if (priceMax.HasValue)
            {
                products = products.Where(p => p.Variations.Any(v =>
                    (v.DiscountedPrice.HasValue ? v.DiscountedPrice.Value : v.Price) <= priceMax.Value));
            }

            // Сортировка по цене с учетом скидок
            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Variations.Min(v =>
                        v.DiscountedPrice.HasValue ? v.DiscountedPrice.Value : v.Price));
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Variations.Max(v =>
                        v.DiscountedPrice.HasValue ? v.DiscountedPrice.Value : v.Price));
                    break;
                default:
                    break;
            }

            // Создание модели представления
            var model = new ProductListViewModel
            {
                Products = products.ToList(),
                Categories = categories,
                Materials = materials,
                Countries = countries,
                Groups = groups, // Передаем группы в модель
                SelectedCategoryId = categoryId,
                SelectedProductType = productType,
                SelectedMaterial = material,
                SelectedCountry = country,
                SelectedGroup = group, // Добавляем выбранную группу
                PriceMin = priceMin,
                PriceMax = priceMax,
                SortOrder = sortOrder, // Инициализация SortOrder
                SearchTerm = searchTerm // Передаем строку поиска в модель
            };

            // Обработка выбранных вариаций
            foreach (var product in model.Products)
            {
                Variation selectedVariation = null;

                if (productId.HasValue && selectedSizeId.HasValue && product.Id == productId.Value)
                {
                    selectedVariation = product.Variations.FirstOrDefault(v => v.Id == selectedSizeId.Value);
                }

                if (selectedVariation == null)
                {
                    selectedVariation = product.Variations.FirstOrDefault();
                }

                if (selectedVariation != null)
                {
                    model.SelectedVariations[product.Id] = selectedVariation;
                }
            }

            // Установка якоря для прокрутки
            if (!string.IsNullOrEmpty(anchor))
            {
                ViewBag.Anchor = anchor;
            }

            return View(model);
        }

        // Метод для асинхронного получения цены через AJAX
        [HttpGet]
        public IActionResult GetPrice(int productId, int sizeId)
        {
            var product = _productRepository.GetProductById(productId);
            var variation = product.Variations.FirstOrDefault(v => v.Id == sizeId);

            if (variation != null)
            {
                return Json(new
                {
                    originalPrice = variation.Price.ToString("N2"),
                    discountedPrice = variation.DiscountedPrice?.ToString("N2")
                });
            }

            return NotFound();
        }

        // Метод для отображения деталей продукта
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